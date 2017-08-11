import { Component } from "@angular/core";
import { AuthService } from "../../../../services/auth.service";
import { Router } from "@angular/router";


@Component({
    selector: "nxs-user",
    templateUrl: "username.component.html",
    styleUrls: ["username.component.css"]
}) export class UserNameComponent {

    constructor(private authService: AuthService, private router: Router) {
        console.log(authService.baseUrl);
    }

    signout(){
        this.authService.logout();
        this.router.navigate(['/home']);
    }
}