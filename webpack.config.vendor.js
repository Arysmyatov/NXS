const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const merge = require('webpack-merge');

module.exports = (env) => {
    const extractCSS = new ExtractTextPlugin('vendor.css');
    const isDevBuild = !(env && env.prod);
    const sharedConfig = {
        stats: {
            modules: false
        },
        resolve: {
            extensions: ['.js']
        },
        module: {
            rules: [{
                test: /\.(jpg|png|woff|woff2|eot|ttf|svg)(\?|$)/,
                use: 'url-loader?limit=100000'
            }]
        },
        entry: {
            vendor: [
                '@angular/animations',
                '@angular/common',
                '@angular/compiler',
                '@angular/core',
                '@angular/forms',
                '@angular/http',
                '@angular/platform-browser',
                '@angular/platform-browser-dynamic',
                '@angular/router',
                'angular2-chartjs',
                'angular2-jwt',
                'ng2-toasty',
                'ng2-toasty/bundles/style-bootstrap.css',
                'chart.js',
                'angular2-busy',
                'angular2-busy/build/style/busy.css',
                'bootstrap',
                'bootstrap/dist/css/bootstrap.css',
                'font-awesome/css/font-awesome.css',
                'es6-shim',
                'es6-promise',
                'event-source-polyfill',
                'jquery',
                'd3',
                'c3',
                'c3/c3.css',
                'zone.js'
            ]
        },
        output: {
            publicPath: '/dist/',
            filename: '[name].js',
            library: '[name]_[hash]'
        },
        plugins: [
            new webpack.ProvidePlugin({
                $: 'jquery',
                jQuery: 'jquery'
            }), // Maps these identifiers to the jQuery package (because Bootstrap expects it to be a global variable)
            new webpack.ProvidePlugin({
                c3: 'c3'
            }), // Maps these identifiers to the c3 package
            new webpack.ContextReplacementPlugin(/\@angular\b.*\b(bundles|linker)/, path.join(__dirname, './ClientApp')), // Workaround for https://github.com/angular/angular/issues/11580
            new webpack.ContextReplacementPlugin(/angular(\\|\/)core(\\|\/)@angular/, path.join(__dirname, './ClientApp')), // Workaround for https://github.com/angular/angular/issues/14898
            new webpack.IgnorePlugin(/^vertx$/) // Workaround for https://github.com/stefanpenner/es6-promise/issues/100
        ]
    };

    const clientBundleConfig = merge(sharedConfig, {
        output: {
            path: path.join(__dirname, 'wwwroot', 'dist')
        },
        module: {
            rules: [{
                    test: /\.css(\?|$)/,
                    use: extractCSS.extract({
                        use: isDevBuild ? 'css-loader' : 'css-loader?minimize'
                    })
                },
                {
                    test: /\.less(\?|$)/,
                    use: extractCSS.extract({
                        use: [{
                            loader: "css-loader"
                        }, {
                            loader: "less-loader"
                        }],
                        fallback: "style-loader"
                    })
                }
            ]
        },
        plugins: [
            extractCSS,
            new webpack.DllPlugin({
                path: path.join(__dirname, 'wwwroot', 'dist', '[name]-manifest.json'),
                name: '[name]_[hash]'
            })
        ].concat(isDevBuild ? [] : [
            new webpack.optimize.UglifyJsPlugin()
        ])
    });

    const serverBundleConfig = merge(sharedConfig, {
        target: 'node',
        resolve: {
            mainFields: ['main']
        },
        output: {
            path: path.join(__dirname, 'ClientApp', 'dist'),
            libraryTarget: 'commonjs2',
        },
        module: {
            rules: [{
                test: /\.css(\?|$)/,
                use: ['to-string-loader', isDevBuild ? 'css-loader' : 'css-loader?minimize']
            }]
        },
        entry: {
            vendor: ['aspnet-prerendering']
        },
        plugins: [
            new webpack.DllPlugin({
                path: path.join(__dirname, 'ClientApp', 'dist', '[name]-manifest.json'),
                name: '[name]_[hash]'
            })
        ]
    });

    return [clientBundleConfig, serverBundleConfig];
}