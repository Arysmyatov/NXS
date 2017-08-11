import { Component } from "@angular/core";
import { Observable } from 'rxjs/Observable';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserRegistration } from '../../../shared/models/user.registration.interface';
import { AuthService } from '../../../services/auth.service';

@Component({
    selector: "nxs-signup-form",
    templateUrl: "signup.component.html",
    styleUrls: ["signup.component.css"]
}) export class SignUpComponent {
    signupData: UserRegistration = {
        email: "",
        password: "",
        repassword: "",
        firstName: "",
        lastName: ""
    };

    errors: string;
    isRequesting: boolean;
    submitted: boolean = false;

    constructor(private authService: AuthService, private router: Router) {
        console.log(authService.baseUrl);
    }

    submit() {
        this.submitted = true;
        this.isRequesting = true;
        this.errors = '';
        this.authService.register(this.signupData)
            .finally(() => this.isRequesting = false)
            .subscribe(
            result => {
                if (result) {
                    this.router.navigate(['/signin'], { queryParams: { brandNew: true, email: this.signupData.email } });
                }
            },
            errors => this.errors = errors);
    }
}