import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { AuthHttp } from "angular2-jwt/angular2-jwt";
import 'rxjs/add/operator/map';
import { SaveVariableXls } from "../../models/variablexls";
import { ConfigService } from "../shared/utils/config.service";
import { UserProfile } from "../shared/models/user.profile.interface";
import { BaseService } from "./base.service";

@Injectable()
export class UserProfileService extends BaseService {
  baseUrl: string = "";

  constructor(private http: Http,
              private authHttp: AuthHttp,
              private configService: ConfigService) {
    super();
    this.baseUrl = configService.getApiURI();
  }

  getProfile() {
    return this.authHttp.get(this.baseUrl + "/account")
      .map(response => response.json())
  }

  updateProfile(userProfile: UserProfile) {
    return this.authHttp.put(this.baseUrl + "/account", JSON.stringify(userProfile))
      .map(response => response.json())
      .catch(this.handleError);
  }

}
