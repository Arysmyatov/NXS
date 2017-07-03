import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { PublicationsComponent, PublicationItemComponent } from "./index";

@NgModule({
    imports: [CommonModule],
    declarations: [PublicationsComponent, PublicationItemComponent],
    exports: [PublicationsComponent, PublicationItemComponent],
    bootstrap: [ PublicationsComponent ],
})
export class PublicationsModule { }