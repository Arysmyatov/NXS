
import { NgModule, ErrorHandler } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { ToastyModule } from 'ng2-toasty';
import { AppErrorHandler } from './app.error-handler';
import { InMemoryWebApiModule } from "angular-in-memory-web-api";
import { RegionData } from "./components/services/inMemoryServer";
import { sharedConfig } from './app.module.shared';
import { GraphDataService } from "./services/graphdata.service";
import { ServicesModule } from "./components/services/index";
import { VariableXlsModule } from "./components/variablexls/index";
import { RegistrationModule } from "./components/registration/index";

@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations, 
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        ServicesModule,
        VariableXlsModule,
        RegistrationModule,
        //InMemoryWebApiModule.forRoot(RegionData),
        sharedConfig.imports
    ],
    exports: [BrowserModule, ToastyModule],    
    providers: [
        { provide: 'ORIGIN_URL', useValue: location.origin },
        { provide: ErrorHandler, useClass: AppErrorHandler },
        GraphDataService
    ],
})
export class AppModule {
}
