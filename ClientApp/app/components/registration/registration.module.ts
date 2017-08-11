import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignInComponent, SignUpComponent, UserProfileComponent } from "./index";
import { RegistrationRoutingModule } from "./index";

@NgModule({
    imports: [
        CommonModule, 
        RegistrationRoutingModule,
        FormsModule,                              
        ReactiveFormsModule          
    ],
    declarations: [SignInComponent, SignUpComponent, UserProfileComponent]
})
export class RegistrationModule { }