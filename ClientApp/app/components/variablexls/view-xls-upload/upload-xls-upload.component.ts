import { BrowserXhr } from '@angular/http';
import { ProgressService, BrowserXhrWithProgress } from '../../../services/progress.service';
import { Component, OnInit, ElementRef, NgZone, ViewChild } from '@angular/core';
import { GraphDataService } from "../../../services/graphdata.service";
import { XlsFileService } from "../../../services/xls-file.service";
import { ToastyService } from 'ng2-toasty';
import { Subscription } from "rxjs/Subscription";

@Component({
  selector: 'app-uploadxls-form',
  templateUrl: './upload-xls-upload.component.html',
  styleUrls: ['./upload-xls-upload.component.css'],
  providers: [
    { provide: BrowserXhr, useClass: BrowserXhrWithProgress },
    ProgressService
  ]
})
export class UploadXlsFileComponent implements OnInit {
  @ViewChild('fileInput') fileInput: ElementRef;
  regions: any[] = [];
  regionId: number = 0;
  scenarios: any[] = [];
  scenarioId: number = 0;
  keyParameters: any[] = [];
  keyParameterId: number = 0;
  keyParameterLevels: any[] = [];
  keyParameterLevelId: number = 0;
  xlsFiles: any[] = [];
  progress: any;
  busy: Subscription;

  constructor(private zone: NgZone,
    private toasty: ToastyService,
    private progressService: ProgressService,
    private browserXhr: BrowserXhr,
    private graphDataService: GraphDataService,
    private xlsFileService: XlsFileService) { }

  ngOnInit() {
    this.graphDataService.getScenarios().subscribe(
      scenarios => {
        this.scenarios = scenarios
      }
    );

    this.graphDataService.getKeyParameters().subscribe(
      keyParameters => {
        for (let keyParameter of keyParameters) {
          this.keyParameters = this.keyParameters.concat(keyParameter.keyParameters);
        }
      }
    );

    this.graphDataService.getKeyParameterLevels().subscribe(
      keyParameterLevels => {
        this.keyParameterLevels = keyParameterLevels
      }
    );

  }

  onRegionChange(region) {
    this.getXlsFiles();
  }

  onScenarioChange(region) {
    this.getXlsFiles();
  }

  onKeyParameterLevelChange(region) {
    this.getXlsFiles();
  }

  onKeyParameterChange(region) {
    this.getXlsFiles();
  }

  getXlsFiles() {
    if (!this.scenarioId || !this.keyParameterId || !this.keyParameterLevelId) return;

    this.xlsFileService.getXlsFiles(this.regionId, this.scenarioId, this.keyParameterId, this.keyParameterLevelId)
      .subscribe(xlsFiles => this.xlsFiles = xlsFiles);
  }

  warningSelectRegionOrlevel(message: string) {
    this.toasty.warning({
      title: 'Uploading file',
      msg: message,
      theme: 'bootstrap',
      showClose: true,
      timeout: 5000
    });

  }

  exportAllData() {
    this.busy = this.xlsFileService.exportAllDataFromXls()
      .subscribe(result => {
        this.toasty.success({
          title: "Export",
          msg: "All the data is exported from the lat uploaded xls files",
          theme: 'bootstrap',
          showClose: true,
          timeout: 5000
        });
      },
      err => {
        this.toasty.error({
          title: 'Error',
          msg: err.text(),
          theme: 'bootstrap',
          showClose: true,
          timeout: 5000
        });
      });
  }

  uploadXls() {
    if (!this.keyParameterLevelId) {
      this.warningSelectRegionOrlevel("Select the key parameter level");
      return;
    }

    this.progressService.startTracking()
      .subscribe(progress => {
        this.zone.run(() => {
          this.progress = progress;
        });
      },
      null,
      () => { this.progress = null; });

    var nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    var file = nativeElement.files[0];
    nativeElement.value = '';
    this.xlsFileService.upload(this.regionId, this.scenarioId, this.keyParameterId, this.keyParameterLevelId, file)
      .subscribe(xlsFile => {
        this.xlsFiles.push(xlsFile);
        this.toasty.success({
          title: 'Uploading file',
          msg: "The File is uploaded",
          theme: 'bootstrap',
          showClose: true,
          timeout: 5000
        });
      },
      err => {
        this.toasty.error({
          title: 'Error',
          msg: err.text(),
          theme: 'bootstrap',
          showClose: true,
          timeout: 5000
        });
      });
  }

}