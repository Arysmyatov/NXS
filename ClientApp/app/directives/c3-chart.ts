import { Directive, ElementRef, Input, OnChanges } from '@angular/core';
require('d3');
require('jquery');
var c3 = require('c3');

@Directive({
    selector: '[c3chart]'
})

export class C3Chart implements OnChanges {
    public _element: any;
    @Input('chartType') public chartType: string;
    @Input('chartOptions') public chartOptions: Object;
    @Input('chartData') public chartData: Object;
    @Input('chartAxis') public chartAxis: Object;
    constructor(public element: ElementRef) {
        this._element = this.element.nativeElement;
    }
    ngOnChanges() {
        setTimeout(() => this.drawGraph(this.chartOptions, this.chartType, this.chartData, this.chartAxis, this._element), 500);
    }

    drawGraph(chartOptions, chartType, chartData, chartAxis, ele) {   
        var chart = c3.generate({
            bindto: ele,
            data: chartData,
            axis: chartAxis,
            grid: {
                x: {
                    show: true
                },
                y: {
                    show: true
                }
            }            
        });
    }
}