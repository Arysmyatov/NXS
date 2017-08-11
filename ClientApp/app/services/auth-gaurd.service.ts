import { CanActivate } from '@angular/router';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(protected auth: AuthService,
        private router: Router, ) { }

    canActivate() {
        if (this.auth.isLoggedIn())
            return true;
        this.router.navigate(['/signin']);
    }
}