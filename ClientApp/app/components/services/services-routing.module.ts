import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { ServicesComponent } from "./index";
import { GraphComponent } from "./index";

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: "services",
                component: ServicesComponent
            },          
            {
                path: "services/:id",
                component: GraphComponent
            }  
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class ServicesRoutingModule { }