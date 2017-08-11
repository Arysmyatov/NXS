import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { VariableFormComponent, UploadXlsFileComponent, AdminHomeComponent } from "./index";
import { AuthGuard } from "../../services/auth-gaurd.service";

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: "variablexls",
                component: VariableFormComponent
            },
            {
                path: "uploadxls",
                component: UploadXlsFileComponent
            },
            {
                path: "admin",
                component: AdminHomeComponent,
                canActivate: [ AuthGuard ] 
            }
        ])
    ],
    exports: [
        RouterModule
    ],
    providers: [
        AuthGuard
    ]
})
export class VariableXlsRoutingModule { }