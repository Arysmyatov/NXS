import { Component, OnInit, OnDestroy } from "@angular/core";
import { Observable } from 'rxjs/Observable';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../../../services/auth.service';
import { Credentials } from "../../../shared/models/credentials.interface";

@Component({
    selector: "nxs-signin-form",
    templateUrl: "signin.component.html",
    styleUrls: ["signin.component.css"]
}) export class SignInComponent implements OnInit, OnDestroy {
    signinData: Credentials = {
        userName: "",
        password: ""
    };
    private subscription: Subscription;
    brandNew: boolean;
    errors: string;
    isRequesting: boolean;
    submitted: boolean = false;

    constructor(private userService: AuthService, private router: Router, private activatedRoute: ActivatedRoute) { }

    ngOnInit() {
        // subscribe to router event
        this.subscription = this.activatedRoute.queryParams.subscribe(
            (param: any) => {
                this.brandNew = param['brandNew'];
                this.signinData.userName = param['email'];
            });
    }

    ngOnDestroy() {
        // prevent memory leak by unsubscribing
        this.subscription.unsubscribe();
    }

    signIn({ value, valid }: { value: Credentials, valid: boolean }) {
        this.submitted = true;
        this.isRequesting = true;
        this.errors = '';
        if (valid) {
            this.userService.login(value)
                .finally(() => this.isRequesting = false)
                .subscribe(
                result => {
                    if (result) {
                        this.router.navigate(['/services']);
                    }
                },
                error => this.errors = error);
        }
    }

}