import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component'
import { MenuComponent } from './components/menu/menu.component';
import { ToastyModule } from 'ng2-toasty';
import { MenuRegistrationComponent } from './components/menu/registration/registration.component';
import { HeaderComponent } from './components/header/header.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { ContactusComponent } from './components/contactus/contactus.component';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent, AboutItemComponent } from "./components/about/index";
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { PublicationsComponent } from "./components/publications/index";
import { PublicationsModule } from "./components/publications/index";
import { SignInComponent } from "./components/registration/index";
import { SignUpComponent } from "./components/registration/index";

export const sharedConfig: NgModule = {
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        MenuComponent,
        MenuRegistrationComponent,
        HeaderComponent,
        ContactsComponent,
        ContactusComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        AboutComponent,
        AboutItemComponent,
    ],
    imports: [
        ToastyModule.forRoot(),        
        PublicationsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'about', component: AboutComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'publications', component: PublicationsComponent },
            { path: 'contactus', component: ContactusComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
};
