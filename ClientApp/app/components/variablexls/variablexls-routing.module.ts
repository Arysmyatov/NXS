import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { VariableFormComponent } from "./index";

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: "variablexls",
                component: VariableFormComponent
            }  
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class VariableXlsRoutingModule { }