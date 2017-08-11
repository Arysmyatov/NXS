import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastyModule } from 'ng2-toasty';
import { BrowserXhrWithProgress, ProgressService } from './services/progress.service';
import { HttpModule } from '@angular/http';
//import { InMemoryWebApiModule } from "angular-in-memory-web-api";
import { RegionData } from "./components/services/inMemoryServer";
//import { sharedConfig } from './app.module.shared';
import { ErrorHandler } from '@angular/core';
import { AppErrorHandler } from './app.error-handler';
import { ServicesModule } from "./components/services/index";
import { VariableXlsModule } from "./components/variablexls/index";
import { RegistrationModule } from "./components/registration/index";
import { ConfigService } from './shared/utils/config.service';
import { GraphDataService } from "./services/graphdata.service";
import { XlsFileService } from "./services/xls-file.service";
import { AuthService } from "./services/auth.service";
import { HomeComponent } from './components/home/home.component';
import { AboutComponent, AboutItemComponent } from "./components/about/index";
import { PublicationsComponent } from "./components/publications/index";
import { ContactusComponent } from './components/contactus/contactus.component';
import { sharedConfig } from './app.module.shared';

@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,    
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        ServicesModule,
        VariableXlsModule,
        RegistrationModule,        
        ...sharedConfig.imports
        //InMemoryWebApiModule.forRoot(RegionData),
    ],
    providers: [
        { provide: 'ORIGIN_URL', useValue: location.origin },
        { provide: ErrorHandler, useClass: AppErrorHandler },
        AuthService,
        ConfigService,
        GraphDataService,
        XlsFileService,
       ...sharedConfig.providers
    ]
})
export class AppModule {
}
