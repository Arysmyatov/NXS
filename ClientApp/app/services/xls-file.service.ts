import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class XlsFileService {

    constructor(private http: Http) { }

    upload(regionId, scenarioId, keyParameterLevelId, xlsFile) {
        var formData = new FormData();
        formData.append('file', xlsFile);
        return this.http.post(`/api/region/${regionId}/scenario/${scenarioId}/keyparameterlevel/${keyParameterLevelId}/xls`, formData)
            .map(res => res.json());
    }

    getXlsFiles(regionId, scenarioId, keyParameterLevelId) {
        return this.http.get(`/api/region/${regionId}/scenario/${scenarioId}/keyparameterlevel/${keyParameterLevelId}/xls`)
            .map(res => res.json());
    }

    exportAllDataFromXls() {
        return this.http.post('api/ExportData/xlsdata', {});
    }
}