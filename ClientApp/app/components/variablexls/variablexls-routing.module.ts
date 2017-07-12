import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { VariableFormComponent, UploadXlsFileComponent } from "./index";

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: "variablexls",
                component: VariableFormComponent
            },
            {
                path: "uploadxls",
                component:  UploadXlsFileComponent
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class VariableXlsRoutingModule { }