import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { VariableFormComponent, UploadXlsFileComponent, AdminHomeComponent } from "./index";

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
                component: AdminHomeComponent
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class VariableXlsRoutingModule { }