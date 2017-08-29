import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import { ConfigService } from "../shared/utils/config.service";
import { BaseService } from "./base.service";
import { ContactUs } from "../shared/models/contactus.interface";

@Injectable()
export class ContactUsService extends BaseService {
  baseUrl: string = "";

  constructor(private http: Http,
              private configService: ConfigService) {
    super();
    this.baseUrl = configService.getApiURI();
  }

  sendMessage(contactUs: ContactUs) {
    return this.http.post(this.baseUrl + "/contactus", contactUs)
      .map(response => response.json())
  }
}
