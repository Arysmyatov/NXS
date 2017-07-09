import { Component, OnInit } from '@angular/core';
import { GraphDataService } from "../../services/graphdata.service";
import { Variable } from "../services/graph/variable";
import { ToastyService } from "ng2-toasty";
import { SaveVariableXls } from "../../../models/variablexls";

@Component({
    selector: 'app-variablexls-form',
    templateUrl: './variablexls-form.component.html',
    styleUrls: ['./variablexls-form.component.css']
})
export class VariableFormComponent implements OnInit {
    variables: any[];
    variableGroups: any[];
    selectedVariable: Variable;
    variableGroup: any = {};
    variableXls: SaveVariableXls =
    {
        id: 0,
        variableId: 0,
        variableGroupId: 0,
        sheetName: "",
        code: "",
        yearBgRow: 0,
        yearBgCol: 0,
        yearEndRow: 0,
        yearEndCol: 0,
        dataBgRow: 0,
        dataBgCol: 0,
        dataEndRow: 0,
        dataEndCol: 0
    };

    constructor(private graphDataService: GraphDataService,
        private toastyService: ToastyService) { }

    ngOnInit() {
        this.graphDataService.getVariables().subscribe(
            variables => {
                this.variableGroups = variables
            }
        );
    }

    onVariableGroupChange() {
        var selectedGroup = this.variableGroups.find(vg => vg.id == this.variableXls.variableGroupId);
        this.variables = selectedGroup ? selectedGroup.variables : [];
    }

    onVariableChange() {
        var selectedVariable = this.variables.find(vg => vg.id == this.variableXls.variableId);
        if (selectedVariable.variableXlsId == 0) {
            this.setVariableXlsDefault();
            return;
        }
        this.graphDataService.getVariableXls(selectedVariable.variableXlsId).subscribe(
            variableXls => this.setVariableXls(variableXls));
    }

    submit() {
        if (this.variableXls.id) {
            this.graphDataService.updateVariableXls(this.variableXls)
                .subscribe(x => {
                    this.toastyService.success({
                        title: 'Success',
                        msg: 'The variable xls was sucessfully updated.',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                });
        }
        else {
            this.graphDataService.createVariableXls(this.variableXls)
                .subscribe(x => {
                    this.toastyService.success({
                        title: 'Success',
                        msg: 'The variable xls was sucessfully saved.',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                    this.setVariableXls(x);
                    this.graphDataService.getVariables().subscribe(
                        variables => {
                            this.variableGroups = variables
                            this.onVariableGroupChange();
                        }
                    );
                });
        }
    }

    private setVariableXlsDefault() {
        this.variableXls.id = 0;
        this.variableXls.sheetName = "";
        this.variableXls.code = "";
        this.variableXls.yearBgRow = 0;
        this.variableXls.yearBgCol = 0;
        this.variableXls.yearEndRow = 0;
        this.variableXls.yearEndCol = 0;
        this.variableXls.dataBgRow = 0;
        this.variableXls.dataBgCol = 0;
        this.variableXls.dataEndRow = 0;
        this.variableXls.dataEndCol = 0;
    }

    private setVariableXls(v: SaveVariableXls) {
        this.variableXls.id = v.id;
        this.variableXls.variableId = v.variableId;
        this.variableXls.sheetName = v.sheetName;
        this.variableXls.code = v.code;
        this.variableXls.yearBgRow = v.yearBgRow;
        this.variableXls.yearBgCol = v.yearBgCol;
        this.variableXls.yearEndRow = v.yearEndRow;
        this.variableXls.yearEndCol = v.yearEndCol;
        this.variableXls.dataBgRow = v.dataBgRow;
        this.variableXls.dataBgCol = v.dataBgCol;
        this.variableXls.dataEndRow = v.dataEndRow;
        this.variableXls.dataEndCol = v.dataEndCol;
    }

}
