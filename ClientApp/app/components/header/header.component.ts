import { ViewChild, ElementRef, AfterViewInit, Component } from "@angular/core";
import { AuthService } from "../../services/auth.service";

var $ = require('jquery');

@Component({
    selector: "nxs-header",
    templateUrl: "header.component.html",
})
export class HeaderComponent {
    @ViewChild("mainNav") nav: ElementRef;

    constructor(private auth: AuthService) { }

    ngAfterViewInit() {
        $(this.nav.nativeElement).affix({
            offset: {
                top: 100
            }
        });
    }
}