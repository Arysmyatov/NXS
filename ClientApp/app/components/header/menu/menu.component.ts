import { Component } from "@angular/core";
import { AuthService } from "../../../services/auth.service";

@Component({
    selector: "nxs-menu",
    templateUrl: "menu.component.html",
    styleUrls: ["menu.component.css"]
}) export class MenuComponent {
    constructor(private auth: AuthService) { }
}