import { NgModule } from "@angular/core";
import { AboutComponent, AboutItemComponent } from "./index";

@NgModule({
    declarations: [
        AboutComponent,
        AboutItemComponent
    ],
    exports: [AboutComponent, AboutItemComponent]
})
export class AboutModule { }