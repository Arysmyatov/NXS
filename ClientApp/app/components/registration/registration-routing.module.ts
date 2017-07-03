import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { SignInComponent } from "./index";
import { SignUpComponent } from "./index";

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: "signin", component: SignInComponent },
            { path: "signup", component: SignUpComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class RegistrationRoutingModule { }