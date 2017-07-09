import { FormsModule } from '@angular/forms'; 
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { VariableFormComponent } from "./index";
import { VariableXlsRoutingModule } from "./variablexls-routing.module";


@NgModule({
    imports: [
        FormsModule,
        CommonModule,
        VariableXlsRoutingModule
    ],
    declarations: [
        VariableFormComponent
    ]
})
export class VariableXlsModule { }