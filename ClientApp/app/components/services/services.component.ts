import { Component } from "@angular/core";
import { Router } from '@angular/router';

@Component({
    selector: "services",
    templateUrl: "services.component.html"
})
export class ServicesComponent { 

    constructor( private router: Router) { }

    redirect() {
        this.router.navigate(['/services/1']);
    }

}