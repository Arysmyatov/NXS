import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ChartModule } from "angular2-chartjs";
import { VariablePipe } from "../../pipes/variablePipe";
import { KeyParameterPipe } from "../../pipes/keyParametersPipe";
import { C3Chart } from '../../directives/c3-chart';
import { AccordionModule} from "ngx-accordion";
import { ServicesComponent, GraphComponent, ServicesRoutingModule } from "./index";

@NgModule({
    imports: [
        CommonModule,
        ChartModule,
        ServicesRoutingModule,
        AccordionModule
    ],
    declarations: [
        ServicesComponent,
        GraphComponent,
        VariablePipe,
        KeyParameterPipe,
        C3Chart
    ]
})
export class ServicesModule { }