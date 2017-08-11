import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { SignInComponent } from "./index";
import { SignUpComponent } from "./index";
import { UserProfileComponent } from "./index";

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: "signin", component: SignInComponent },
            { path: "signup", component: SignUpComponent },
            { path: "userprofile", component: UserProfileComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class RegistrationRoutingModule { }