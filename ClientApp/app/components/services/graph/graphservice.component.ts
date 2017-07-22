import { Component, OnInit } from "@angular/core";
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
            regionGroups => this.regions = regionGroups[0].regions
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
            keyParameterLevels => {
                this.keyParameterLevels = keyParameterLevels;
                this.selectedKeyParameterLevel = this.keyParameterLevels[0];
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
        this.query.keyParameterId = keyParameter.id;
        this.query.keyParameterLevelId = keyParameterLevelId;

        this.selectedKeyParameter = keyParameter;
        this.selectedKeyParameterLevel = new KeyParameterLevel(keyParameterLevelId, "");

        this.builGraph();
    }

    isCurrentKeyParameterSelted(parameterId: number, levelId: number): boolean {
        if (!this.query.keyParameterId || !this.query.keyParameterLevelId) {
            return false;
        }

        return this.query.keyParameterId == parameterId &&
            this.query.keyParameterLevelId == levelId;
    }


    builGraph() {
        if (!this.query.regionId ||
            !this.query.scenarioId ||
            !this.query.variableId ||
            !this.query.keyParameterId ||
            !this.query.keyParameterLevelId) {
            this.builHeadGraphColumns();
            return;
        }
        this.builHeadGraphColumns();

        this.graphDataService.getData(this.query).subscribe(
            data => {
                if (!data ||
                    !data.years ||
                    data.years.length == 0) {
                    return;
                }
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

    addDataItemsToGraph(data: Data) {
        let itemIndex = 0;
        this.graphColumns = [];
        this.graphColumns.push(['x']);
        this.graphColumns[itemIndex] = this.graphColumns[0].concat(data.years);

        for (let subVariable of data.subVariables) {
            this.graphColumns.push([subVariable]);
            itemIndex++;
            let graphData = data.values[itemIndex - 1];
            this.graphColumns[itemIndex] = this.graphColumns[itemIndex].concat(graphData);

            this.addItemToQuerieList(this.selectedRegion.name,
                this.selectedScenario.name,
                subVariable,
                this.selectedKeyParameter.name + " - " + this.selectedKeyParameterLevel.name,
                graphData);
        }
        this.c3_ChartData.columns = this.graphColumns;
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

    addItemToQuerieList(region: string, scenario: string, variable: string, keyParameter: string, data: any[]) {
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