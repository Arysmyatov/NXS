import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from '@angular/router';
import { MenuRegistrationComponent, UserNameComponent, MenuComponent, HeaderComponent } from "./index";

@NgModule({
    imports: [
        CommonModule,
        RouterModule
    ],
    declarations: [
        MenuRegistrationComponent,
        UserNameComponent,
        MenuComponent,
        HeaderComponent
    ],
    exports: [
        MenuRegistrationComponent, 
        UserNameComponent,
        MenuComponent, 
        HeaderComponent
    ]
})
export class HeaderModule { }