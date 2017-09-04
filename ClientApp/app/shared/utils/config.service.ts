import { Injectable } from '@angular/core';
 
@Injectable()
export class ConfigService {
     
    _apiURI : string;
 
    constructor() {
        this._apiURI = "http://theresourcenexus.co.uk/api";
     }
 
     getApiURI() {
         return this._apiURI;
     }    
}