import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastyModule } from 'ng2-toasty';
import { AppComponent } from './components/app/app.component'
import { ContactsComponent } from './components/contacts/contacts.component';
import { ContactusComponent } from './components/contactus/contactus.component';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent, AboutItemComponent } from "./components/about/index";
import { PublicationsComponent } from "./components/publications/index";
import { HeaderModule } from './components/header/index';
import { ConfigService } from './shared/utils/config.service';
import { AuthService } from "./services/auth.service";
import { PublicationsModule } from "./components/publications/index";
import { AUTH_PROVIDERS } from "angular2-jwt/angular2-jwt";
import { UserProfileService } from "./services/userprofile.service";
import { ContactUsService } from "./services/contactus.service";

export const sharedConfig: NgModule = {
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
        ToastyModule.forRoot(),
        HeaderModule,
        PublicationsModule,
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
        ConfigService,
        AuthService,
        UserProfileService,
        ContactUsService,
        AUTH_PROVIDERS
    ]
};
