import { Injectable } from '@angular/core';
 
@Injectable()
export class ConfigService {
    _apiURI : string;
    readonly endpoints = {
        region: "",
        scenario: "",
        parentregions: "",
        variable: "",
        variablexls: "",
        regiontype: "",
        keyparameter: "",
        keyparameterlevel: ""        
    };
 
    constructor() {
        //this._apiURI = "http://theresourcenexus.co.uk/api";
        // this._apiURI = "http://localhost:5000/api";
        this._apiURI = "http://nxs.azurewebsites.net/api";
        this.endpoints = {
            region: `${this._apiURI}/regions`,
            parentregions: `${this._apiURI}/parentregions`,
            scenario: `${this._apiURI}/scenarios`,
            variable: `${this._apiURI}/variables`,
            variablexls: `${this._apiURI}/variablexls`,
            regiontype: `${this._apiURI}/xlsregiontypes`,
            keyparameter: `${this._apiURI}/keyparameters`,
            keyparameterlevel: `${this._apiURI}/keyparameterlevels`
        }
     }
 
     getApiURI() {
         return this._apiURI;
     }    
}