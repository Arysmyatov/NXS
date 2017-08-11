import { Component } from "@angular/core";
import { Router } from '@angular/router';
import { AuthService } from "../../services/auth.service";

@Component({
    selector: "services",
    templateUrl: "services.component.html"
})
export class ServicesComponent {

    constructor(private router: Router,
        protected auth: AuthService,
    ) { }

    redirect() {
        this.router.navigate(['/services/1']);
    }

}