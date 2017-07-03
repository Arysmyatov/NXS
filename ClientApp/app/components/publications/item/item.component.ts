import { Component } from "@angular/core";

@Component({
    selector: "publication-item",
    templateUrl: "item.component.html",
    styleUrls: ["item.component.css"],
    inputs: ["date", "title", "author", "imgSrc", "publ-link"]
})
export class PublicationItemComponent { }