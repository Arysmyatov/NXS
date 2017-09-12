import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { AuthHttp } from "angular2-jwt/angular2-jwt";
import 'rxjs/add/operator/map';
import { ConfigService } from "../shared/utils/config.service";
import { BaseService } from "./base.service";

@Injectable()
export class ParentRegionsService extends BaseService {
  baseUrl: string = "";

  constructor(private http: Http,
              private authHttp: AuthHttp,
              private configService: ConfigService) {
    super();
  }

  getParentRegions() {
    return this.authHttp.get(this.configService.endpoints.parentregions)
      .map(response => response.json())
  }
}