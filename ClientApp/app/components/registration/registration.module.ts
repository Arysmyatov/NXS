import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { SignInComponent, SignUpComponent } from "./index";
import { RegistrationRoutingModule } from "./index";

@NgModule({
    imports: [
        CommonModule, 
        RegistrationRoutingModule
    ],
    declarations: [SignInComponent, SignUpComponent]
})
export class RegistrationModule { }