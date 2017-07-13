import { FormsModule } from '@angular/forms';
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BusyModule, BusyConfig } from 'angular2-busy';
import { VariableFormComponent, UploadXlsFileComponent, AdminHomeComponent } from "./index";
import { VariableXlsRoutingModule } from "./variablexls-routing.module";


@NgModule({
    imports: [
        FormsModule,
        CommonModule,
        VariableXlsRoutingModule,
        BrowserAnimationsModule,
        BusyModule.forRoot(
            new BusyConfig({
                message: 'Don\'t panic!',
                delay: 200,
                minDuration: 600,
                wrapperClass: 'wrapper-busy'
            }))        
    ],
    declarations: [
        VariableFormComponent,
        UploadXlsFileComponent,
        AdminHomeComponent
    ]
})
export class VariableXlsModule { }