import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class XlsFileService {

    constructor(private http: Http) { }

    upload(parentRegionId, scenarioId, keyParameterId, keyParameterLevelId, xlsFile) {
        var formData = new FormData();
        formData.append('parentRegion', parentRegionId);
        formData.append('scenario', scenarioId);
        formData.append('keyParameter', keyParameterId);
        formData.append('keyParameterLevel', keyParameterLevelId);
        formData.append('file', xlsFile);

        return this.http.post("/api/uploadxls", formData)
            .map(res => res.json());
    }

    getXlsFiles(regionId, scenarioId, keyParameterId, keyParameterLevelId) {
        return this.http.get(`/api/region/${regionId}/scenario/${scenarioId}/keyparameter/${keyParameterId}/keyparameterlevel/${keyParameterLevelId}/xls`)
            .map(res => res.json());
    }

    importAllDataFromXls() {
        return this.http.post('api/importData/xlsimportdata', {});
    }
}