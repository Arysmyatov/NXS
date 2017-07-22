import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { SaveVariableXls } from "../../models/variablexls";

@Injectable()
export class GraphDataService {
  private readonly dataEndpoint = '/api/data';  

  constructor(private http: Http) { }

  getRegions() {
    return this.http.get('/api/regions')
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

  getVariableXls(id) {
    return this.http.get('/api/variablexls/' + id)
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

  getData_(region: number, scenario: number, variable: number, keyparameter: number, keyparameterlevel: number) {
    let url: string = '/api/data/region/' + region
      + '/scenario/' + scenario 
      + '/variable/' + variable 
      + '/keyparameter/' + keyparameter 
      + '/level/' + keyparameterlevel;

    return this.http.get(url)
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
