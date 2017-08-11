import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { ErrorHandler } from '@angular/core';
import { AppErrorHandler } from './app.error-handler';
import { ToastyModule } from 'ng2-toasty';
import { AppComponent } from './components/app/app.component'
import { ServicesModule } from "./components/services/index";
import { VariableXlsModule } from "./components/variablexls/index";
import { RegistrationModule } from "./components/registration/index";
import { ContactsComponent } from './components/contacts/contacts.component';
import { ContactusComponent } from './components/contactus/contactus.component';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent, AboutItemComponent } from "./components/about/index";
import { PublicationsComponent } from "./components/publications/index";
import { HeaderModule } from './components/header/index';
import { ConfigService } from './shared/utils/config.service';
import { AuthService } from "./services/auth.service";
import { GraphDataService } from "./services/graphdata.service";
import { XlsFileService } from "./services/xls-file.service";
import { PublicationsModule } from "./components/publications/index";

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        ContactsComponent,
        ContactusComponent,
        HomeComponent,
        AboutComponent,
        AboutItemComponent
    ],
    imports: [
        FormsModule,
        BrowserModule,
        ReactiveFormsModule,
        HttpModule,
        ServicesModule,
        VariableXlsModule,
        RegistrationModule,        
        HeaderModule,
        PublicationsModule,
        ToastyModule.forRoot(),        
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'about', component: AboutComponent },
            { path: 'publications', component: PublicationsComponent },
            { path: 'contactus', component: ContactusComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        { provide: 'ORIGIN_URL', useValue: location.origin },
        { provide: ErrorHandler, useClass: AppErrorHandler },
        AuthService,
        ConfigService,
        GraphDataService,
        XlsFileService,        
        ConfigService,
        AuthService
    ]
})
export class AppModule {
}
