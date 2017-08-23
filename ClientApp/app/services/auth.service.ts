import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { UserRegistration } from '../shared/models/user.registration.interface';
import { ConfigService } from '../shared/utils/config.service';

import { BaseService } from "./base.service";

import { Observable } from 'rxjs/Rx';
import { BehaviorSubject } from 'rxjs/Rx';

import '../rxjs-operators';
import { Credentials } from "../shared/models/credentials.interface";
import { UserProfile } from "../shared/models/user.profile.interface";
import { JwtHelper } from "angular2-jwt";

@Injectable()
export class AuthService extends BaseService {

  baseUrl: string = "";
  userName: string = "";
  role: string = "";

  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();

  private loggedIn = false;

  constructor(private http: Http,
              private configService: ConfigService) {
    super();
    this.loggedIn = !!localStorage.getItem('token');
    this.userName = localStorage.getItem('user_name');
    // ?? not sure if this the best way to broadcast the status but seems to resolve issue on page refresh where auth status is lost in
    // header component resulting in authed user nav links disappearing despite the fact user is still logged in
    this._authNavStatusSource.next(this.loggedIn);
    this.baseUrl = configService.getApiURI();
  }

  getUserFromLocalSorage() {
    let token = localStorage.getItem('token');
    this.loggedIn = !!token;
    this.userName = localStorage.getItem('user_name');
    this.getUserRole(token);
  }

  getUserRole(token: string) {
    if (token) {
      var jwtHelper = new JwtHelper();
      var decodedToken = jwtHelper.decodeToken(token);
      this.role = decodedToken["rol"] || "";
    }
  }

  register(userRegistration: UserRegistration): Observable<UserRegistration> {
    let body = JSON.stringify(userRegistration);
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });

    return this.http.post(this.baseUrl + "/account", body, options)
      .map(res => true)
      .catch(this.handleError);
  }

  login(credentials: Credentials) {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');

    return this.http
      .post(
      this.baseUrl + '/auth/login',
      JSON.stringify(credentials), { headers }
      )
      .map(res => res.json())
      .map(res => {
        localStorage.setItem('token', res.auth_token);
        this.loggedIn = true;
        this.setUserName(res.userName);
        this.getUserRole(res.auth_token);

        this._authNavStatusSource.next(true);
        return true;
      })
      .catch(this.handleError);
  }

  logout() {
    localStorage.removeItem('token');
    this.loggedIn = false;
    this._authNavStatusSource.next(false);
  }

  isLoggedIn() {
    return this.loggedIn;
  }

  setUserName(userName: string) {
    this.userName = userName;
    localStorage.setItem('user_name', userName);
  }

  public isInRole(roleName) {
    return this.role == roleName;
  }

}