import { ViewChild, ElementRef, AfterViewInit, Component } from "@angular/core";

declare var $: any;

@Component({
    selector: "nxs-header",
    templateUrl: "header.component.html",
}) export class HeaderComponent {
    @ViewChild("mainNav") nav: ElementRef;

    ngAfterViewInit() {
        $(this.nav.nativeElement).affix({
            offset: {
                top: 100
            }
        });
    }
}