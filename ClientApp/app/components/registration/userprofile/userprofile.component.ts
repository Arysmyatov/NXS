import { Component, OnInit } from "@angular/core";
import { Observable } from 'rxjs/Observable';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastyService } from "ng2-toasty";
import { UserRegistration } from '../../../shared/models/user.registration.interface';
import { AuthService } from '../../../services/auth.service';
import { UserProfile } from "../../../shared/models/user.profile.interface";
import { UserProfileService } from "../../../services/userprofile.service";

@Component({
    selector: "nxs-user-profile-form",
    templateUrl: "userprofile.component.html",
    styleUrls: ["userprofile.component.css"]
}) export class UserProfileComponent implements OnInit {
    userData: UserProfile = {
        firstName: "",
        lastName: "",
        email: ""
    };

    errors: string;
    isRequesting: boolean;
    submitted: boolean = false;

    constructor(private authService: AuthService,
        private userProfileService: UserProfileService,
        private router: Router,
        private toastyService: ToastyService) {
        console.log(authService.baseUrl);
    }

    ngOnInit() {
        this.userProfileService.getProfile()
            .subscribe(
            result => {
                this.userData = result;
            },
            errors => {
                this.errors = errors;
                this.toastyService.error({
                    title: 'Error',
                    msg: `The usere profile is not saved: ${errors}`,
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            });
    }

    submit() {
        this.submitted = true;
        this.isRequesting = true;
        this.errors = '';
        this.userProfileService.updateProfile(this.userData)
            .finally(() => this.isRequesting = false)
            .subscribe(
            result => {
                this.toastyService.success({
                    title: 'Success',
                    msg: 'The usere profile is updated.',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            },
            errors => {
                this.errors = errors;
                this.toastyService.error({
                    title: 'Error',
                    msg: `The usere profile is not saved: ${errors}`,
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            });
    }

    signOut() {
        this.authService.logout();
        this.router.navigate(['/home']);
    }
}