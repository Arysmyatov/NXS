import { Component } from "@angular/core";
import { TableEntities } from './tableEntity';
import { TableEntity } from './tableEntity';
import { bootstrap } from "bootstrap";
import { AccordionModule } from "ngx-accordion";
import { GraphDataService } from "../../../services/graphdata.service";
import { Region } from "./region";
import { Scenario } from "./scenario";
import { Variable } from "./variable";
import { GraphEntity } from "./graphEntity";
import { KeyParameter } from "./keyParameter";
import { VariableGroup } from "./variableGroup";
import { KeyParameterLevel } from "./KeyParameterLevel";
import { KeyParameterGroup } from "./keyParametersGroup";
import { Data } from "./data";
import { ToastyService } from "ng2-toasty";
import { KeyParameterData } from "./keyParameterData";

@Component({
    selector: "graph-service",
    templateUrl: "graphservice.component.html",
    styleUrls: ["graphservice.component.css"]
})
export class GraphComponent {
    query: any = {
        regionId: null
    };

    selectedRegion: Region;
    selectedScenario: Scenario;
    selectedVariableGroup: string;
    selectedVariable: Variable;
    selectedKeyParameter: KeyParameter;
    selectedKeyParameterLevel: KeyParameterLevel;

    selectedKeyParameters: KeyParameter[];
    keyParameterData: KeyParameterData[];

    variableGroup: number;
    graphData: GraphEntity[];
    graphColumns: any[];
    tableEntities: TableEntities;

    regions: Region[];
    scenarios: Scenario[];
    variableGroups: any[];
    variables: VariableGroup[];
    variablesTop: Variable[];
    variablesBottom: Variable[];
    keyParameters: any[];
    keyParametersBottom: KeyParameter[];
    keyParameterLevels: KeyParameterLevel[];
    data: Data[];

    public c3_ChartData = {
        x: 'x',
        xFormat: '%Y',
        columns: this.graphColumns,
        type: 'spline'
    };

    public c3_axis = {
        x: {
            type: 'timeseries',
            tick: {
                format: '%Y'
            }
        },
        y: {
            label: {
                text: '',
                position: 'outer-middle'
            }
        }
    };

    constructor(private graphDataService: GraphDataService,
        private toasty: ToastyService) {
        this.variableGroup = 1;

        this.builHeadGraphColumns();
        this.initQueryColumns();
    }

    ngOnInit() {
        this.graphDataService.getRegions().subscribe(
            regions => this.regions = regions
        );

        this.graphDataService.getScenarios().subscribe(
            scenarios => this.scenarios = scenarios
        );

        this.graphDataService.getVariables().subscribe(
            variables => this.filterVariables(variables)
        );

        this.graphDataService.getKeyParameters().subscribe(
            keyParameters => this.filterKeyParameters(keyParameters)
        );

        this.graphDataService.getKeyParameterLevels().subscribe(
            keyParameterLevels => this.keyParameterLevels = keyParameterLevels
        );

        this.graphDataService.getKeyParameterLevels().subscribe(
            keyParameterLevels => {
                this.keyParameterLevels = keyParameterLevels;
            }
        );
    }

    filterKeyParameters(keyParametersAll: KeyParameterGroup[]) {
        let keyParametersGroupBottom: KeyParameterGroup[] = keyParametersAll.filter(item => item.name == "Bottom");

        this.keyParameters = keyParametersAll;
        this.keyParametersBottom = keyParametersGroupBottom[0].keyParameters;
    }

    filterVariables(variables: VariableGroup[]) {
        this.variables = variables.filter(item => item.name != "Top" && item.name != "Bottom");
        this.filterVariablesTop(variables);
        this.filterVariablesBottom(variables);
    }

    filterVariablesTop(variables: VariableGroup[]) {
        let variablesGroupTop: VariableGroup[] = variables.filter(item => item.name == "Top");
        this.variablesTop = variablesGroupTop[0].variables;
    }

    filterVariablesBottom(variables: VariableGroup[]) {
        let variablesGroupBottom: VariableGroup[] = variables.filter(item => item.name == "Bottom");
        this.variablesBottom = variablesGroupBottom[0].variables;
    }

    openVg(vg) {
        this.variableGroup = vg.id;
    }

    selectRegion(region: Region) {
        this.query.regionId = region.id;
        this.selectedRegion = region;
        this.builGraph();
    }

    selectScenario(scenario: Scenario) {
        this.query.scenarioId = scenario.id;
        this.selectedScenario = scenario;
        this.builGraph();
    }

    selectVariable(variable: Variable) {
        this.query.variableId = variable.id;
        this.selectedVariable = variable;
        this.c3_axis.y.label.text = variable.name;
        this.builGraph();
    }

    selectKeyParameter(keyParameter: KeyParameter, keyParameterLevelId: number) {
        keyParameter.keyParameterLevelId = keyParameterLevelId;
        if (this.selectedKeyParameters == null) {
            this.selectedKeyParameters = [];
        }

        var idOfkeyParam = this.selectedKeyParameters.findIndex(item => item.id == keyParameter.id);
        if (idOfkeyParam >= 0) {
            this.selectedKeyParameters.splice(idOfkeyParam, 1);
        }
        this.selectedKeyParameters.push(keyParameter);

        this.query.KeyParameterResources = this.selectedKeyParameters;

        this.builGraph();
    }

    isCurrentKeyParameterSelted(parameterId: number, levelId: number): boolean {
        if (!this.selectedKeyParameters || this.selectedKeyParameters.length <= 0) {
            return false;
        }

        var idOfkeyParam = this.selectedKeyParameters.findIndex(item => item.id == parameterId && item.keyParameterLevelId == levelId);
        return idOfkeyParam >= 0;
    }


    builGraph() {
        if (!this.query.regionId ||
            !this.query.scenarioId ||
            !this.query.variableId ||
            !this.selectedKeyParameters ||
            this.selectedKeyParameters.length <= 0) {
            this.builHeadGraphColumns();
            return;
        }
        this.builHeadGraphColumns();

        this.graphDataService.getData(this.query).subscribe(
            data => {
                if (!data || data.length == 0) {
                    return;
                }
                this.addData(data);
                this.addDataItemsToGraph(data);
            });
    }

    riseNoDataMessage() {
        this.toasty.warning({
            title: 'Loading data',
            msg: 'there is no data for such parameters',
            theme: 'bootstrap',
            showClose: true,
            timeout: 3000
        });
    }

    addData(data: KeyParameterData[]) {
        this.keyParameterData = data;
    }

    addDataItemsToGraph(data1: Data) {
        let itemIndex = 0;
        if (!this.keyParameterData || this.keyParameterData.length <= 0) {
            return;
        }

        let years = [];
        for (let keyParamData of this.keyParameterData) {
            if (keyParamData.years == null || keyParamData.years.length <= 0) {
                continue;
            }
            years = keyParamData.years;
            break;
        }

        this.graphColumns = [];
        this.graphColumns.push(['x']);
        this.graphColumns[itemIndex] = this.graphColumns[0].concat(years);
        this.tableEntities.yearList = years;

        for (let data of this.keyParameterData) {
            if (!data.subVariables || data.subVariables.length == 0) continue;

            let currentKeyParameter = this.getKeyParameterById(data.keyParameterId);
            let currentKeyParameterLevel = this.getKeyParameterLevelById(data.keyParameterLevelId);

            for (let subVariable of data.subVariables) {
                this.graphColumns.push([subVariable]);
                itemIndex++;
                let graphData: number[] = data.values[itemIndex - 1];
                this.graphColumns[itemIndex] = this.graphColumns[itemIndex].concat(graphData);

                this.addItemToQuerieList(this.selectedRegion.name,
                    this.selectedScenario.name,
                    subVariable,
                    currentKeyParameter.name + " - " + currentKeyParameterLevel.name,
                    graphData);
            }
        }

        this.c3_ChartData = {
            x: 'x',
            xFormat: '%Y',
            columns: this.graphColumns,
            type: 'spline'
        };
    }

    getKeyParameterById(id: number): KeyParameter {
        let keyParams = this.selectedKeyParameters.filter(kp => kp.id == id);
        return keyParams[0];
    }

    getKeyParameterLevelById(id: number): KeyParameterLevel {
        let keyParamLevel = this.keyParameterLevels.filter(kp => kp.id == id);
        return keyParamLevel[0];
    }


    builHeadGraphColumns() {
        this.graphColumns = [];
        this.graphColumns.push(['x', '2010', '2015', '2020', '2025', '2030', '2035', '2040', '2045', '2050']);

        if (this.tableEntities && this.tableEntities.entities) {
            this.tableEntities.entities = [];
        }

        this.c3_ChartData = {
            x: 'x',
            xFormat: '%Y',
            columns: this.graphColumns,
            type: 'spline'
        };
    }

    initQueryColumns() {
        this.tableEntities = new TableEntities(['2010', '2015', '2020', '2025', '2030', '2035', '2040', '2045', '2050']);
    }

    addItemToQuerieList(region: string, scenario: string, variable: string, keyParameter: string, data: number[]) {
        let tebaleEntity = new TableEntity();
        tebaleEntity.region = region;
        tebaleEntity.scenario = scenario;
        tebaleEntity.variable = variable;
        tebaleEntity.keyParameter = keyParameter;
        tebaleEntity.data = [];
        if (!this.tableEntities.entities) {
            this.tableEntities.entities = [];
        }

        for (var index = 0; index < data.length; index++) {
            tebaleEntity.data.push(Math.round(data[index]));
        }

        this.tableEntities.entities.push(tebaleEntity);
    }
}