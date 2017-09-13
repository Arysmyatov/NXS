import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { AuthHttp } from "angular2-jwt/angular2-jwt";
import { ConfigService } from "../shared/utils/config.service";
import { BaseService } from "./base.service";
import 'rxjs/add/operator/map';
import { SaveVariableXls } from "../../models/variablexls";

@Injectable()
export class GraphDataService extends BaseService {
  baseUrl: string = "";
  private readonly dataEndpoint = '/api/data';  

  constructor(private http: Http, private authHttp: AuthHttp, private configService: ConfigService) { 
    super();
    this.baseUrl = configService.getApiURI();    
  }

  getRegions() {
    return this.authHttp.get(this.configService.endpoints.region)
      .map(res => res.json());
  }

  getScenarios() {
    return this.http.get(this.configService.endpoints.scenario)
      .map(res => res.json());
  }

  getVariables() {
    return this.http.get(this.configService.endpoints.variable)
      .map(res => res.json());
  }

 getVariablesXls() {
    return this.http.get(this.configService.endpoints.variablexls)
      .map(res => res.json());
  }  

  getVariableXls(filter) {
    return this.http.get(this.configService.endpoints.variablexls + '?' + this.toQueryString(filter))
      .map(res => res.json());
  } 

  getXlsRegionTypes() {
    return this.http.get(this.configService.endpoints.variablexls)
      .map(res => res.json());
  } 

  getKeyParameters() {
    return this.http.get(this.configService.endpoints.keyparameter)
      .map(res => res.json());
  }

  getKeyParameterLevels() {
    return this.http.get(this.configService.endpoints.keyparameterlevel)
      .map(res => res.json());
  }

  updateVariableXls(variableXls: SaveVariableXls) {
    return this.http.put(this.configService.endpoints.variablexls + variableXls.id, variableXls)
      .map(res => res.json());
  }

  createVariableXls(variableXls) {
    return this.http.post(this.configService.endpoints.variablexls, variableXls)
      .map(res => res.json());
  }

  getData(filter) {
    return this.http.post(this.dataEndpoint, filter)
      .map(res => res.json());
  } 

  //  getData(filter) {
  //   return this.http.get(this.dataEndpoint + '?' + this.toQueryString(filter))
  //     .map(res => res.json());
  // } 

  toQueryString(obj) {
    var parts = [];
    for (var property in obj) {
      var value = obj[property];
      if (value != null && value != undefined) 
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
    }

    return parts.join('&');
  }
  
}
