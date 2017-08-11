import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import { SaveVariableXls } from "../../models/variablexls";
import { ConfigService } from "../shared/utils/config.service";
import { UserProfile } from "../shared/models/user.profile.interface";
import { BaseService } from "./base.service";

@Injectable()
export class UserProfileService extends BaseService {
  baseUrl: string = "";

  constructor(private http: Http, private configService: ConfigService) {
    super();  
    this.baseUrl = configService.getApiURI();
  }

  getProfile() {
    let headers = new Headers();
    let authToken = localStorage.getItem('auth_token');
    headers.append('Content-Type', 'application/json');
    headers.append('Authorization', `Bearer ${authToken}`);

    return this.http.get(this.baseUrl + "/account", { headers })
      .map(response => response.json())
  }

  updateProfile(userProfile: UserProfile) {
    let headers = new Headers();
    let authToken = localStorage.getItem('auth_token');
    headers.append('Content-Type', 'application/json');
    headers.append('Authorization', `Bearer ${authToken}`);

    return this.http.put(this.baseUrl + "/account", JSON.stringify(userProfile), { headers })
      .map(response => response.json())
      .catch(this.handleError);
  }

}
