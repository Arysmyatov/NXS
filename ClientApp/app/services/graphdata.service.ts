import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { AuthHttp } from "angular2-jwt/angular2-jwt";
import 'rxjs/add/operator/map';
import { SaveVariableXls } from "../../models/variablexls";

@Injectable()
export class GraphDataService {
  private readonly dataEndpoint = '/api/data';  
  private readonly variableXlsEndpoint = '/api/variablexls';  
  private readonly xlsRegionTypesEndpoint = '/api/xlsregiontypes';  

  constructor(private http: Http, private authHttp: AuthHttp) { }

  getRegions() {
    return this.authHttp.get('/api/regions')
      .map(res => res.json());
  }

  getScenarios() {
    return this.http.get('/api/scenarios')
      .map(res => res.json());
  }

  getVariables() {
    return this.http.get('/api/variables')
      .map(res => res.json());
  }

 getVariablesXls() {
    return this.http.get('/api/variablexls')
      .map(res => res.json());
  }  

  getVariableXls(filter) {
    return this.http.get(this.variableXlsEndpoint + '?' + this.toQueryString(filter))
      .map(res => res.json());
  } 

  getXlsRegionTypes() {
    return this.http.get(this.xlsRegionTypesEndpoint)
      .map(res => res.json());
  } 

  getKeyParameters() {
    return this.http.get('/api/keyparameters')
      .map(res => res.json());
  }

  getKeyParameterLevels() {
    return this.http.get('/api/keyparameterlevels')
      .map(res => res.json());
  }

  updateVariableXls(variableXls: SaveVariableXls) {
    return this.http.put('/api/variablexls/' + variableXls.id, variableXls)
      .map(res => res.json());
  }

  createVariableXls(variableXls) {
    return this.http.post('/api/variablexls', variableXls)
      .map(res => res.json());
  }
  
   getData(filter) {
    return this.http.get(this.dataEndpoint + '?' + this.toQueryString(filter))
      .map(res => res.json());
  } 

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
