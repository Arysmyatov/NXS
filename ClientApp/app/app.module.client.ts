
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RegistrationModule } from "./components/registration/index";
import { InMemoryWebApiModule } from "angular-in-memory-web-api";
import { RegionData } from "./components/services/inMemoryServer";
import { ServicesModule } from "./components/services/index";
import { sharedConfig } from './app.module.shared';
import { GraphDataService } from "./services/graphdata.service";

@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        RegistrationModule,
        ServicesModule,
        //InMemoryWebApiModule.forRoot(RegionData),
        ...sharedConfig.imports
    ],
    providers: [
        { provide: 'ORIGIN_URL', useValue: location.origin },
        GraphDataService
    ]
})
export class AppModule {
}
