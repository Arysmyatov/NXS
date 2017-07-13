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
    selectedRegion: Region;
    selectedScenario: Scenario;
    selectedVariableGroup: string;
    selectedVariable: Variable;
    selectedKeyParameters: KeyParameter[];
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
        this.selectedRegion = region;
        this.builGraph();
    }

    selectScenario(scenario: Scenario) {
        this.selectedScenario = scenario;
        this.builGraph();
    }

    selectVariable(variable: Variable) {
        this.selectedVariable = variable;
        this.c3_axis.y.label.text = this.selectedVariable.name;
        this.builGraph();
    }

    selectKeyParameter(keyParameter: KeyParameter, keyParameterLevel: number) {
        if (!this.isKeyParametersContainsObj(keyParameter)) {
            if (!this.selectedKeyParameters) {
                this.selectedKeyParameters = [];
            }            
            keyParameter.level = keyParameterLevel;
            this.selectedKeyParameters.push(keyParameter);

            // // remove from the list
            // var index = this.selectedKeyParameters.indexOf(keyParameter, 0);
            // if (index > -1) {
            //     this.selectedKeyParameters.splice(index, 1);
            // }
        }

        let curentKeyParameter = this.selectedKeyParameters.filter(item => item.id == keyParameter.id);
        curentKeyParameter[0].level = keyParameterLevel;
        
        this.builGraph();
    }

    isKeyParametersContainsObj(obj: KeyParameter): boolean {
        if (!this.selectedKeyParameters ||
            this.selectedKeyParameters.length == 0) {
            return false;
        }

        let i: number;
        for (i = 0; i < this.selectedKeyParameters.length; i++) {
            if (this.selectedKeyParameters[i] === obj) {
                return true;
            }
        }
        return false;
    }

    isCurrentKeyParameterSelted(parameterId: number, levelId: number): boolean {
        if(!this.selectedKeyParameters || this.selectedKeyParameters.length == 0){
            return false;
        }
        let curentKeyParameter = this.selectedKeyParameters.filter(item => item.id == parameterId && item.level == levelId);
        return curentKeyParameter.length > 0;
    }


    builGraph() {
        if (!this.selectedRegion ||
            !this.selectedScenario ||
            !this.selectedVariable ||
            !this.selectedKeyParameters ||
            this.selectedKeyParameters.length == 0) {
            this.builHeadGraphColumns();
            return;
        }
        this.builHeadGraphColumns();

        for (let keyParameter of this.selectedKeyParameters) {
            this.buildGraphForKeyParameter(keyParameter);
        }
    }

    buildGraphForKeyParameter(keyParameter: KeyParameter) {
        // get Graph data
        this.graphDataService.getData(this.selectedRegion.id,
            this.selectedScenario.id,
            this.selectedVariable.id,
            keyParameter.id,
            this.selectedKeyParameterLevel.id).subscribe(
            data => {
                if(!data || data.length == 0){
                    //this.riseNoDataMessage();
                    return;
                }
                this.addDataItemsToGraph(data, keyParameter);
            });

            // ,
            // err => {
            //     this.toasty.warning({
            //         title: 'Loading data',
            //         msg: 'there is no data for such parameters',
            //         theme: 'bootstrap',
            //         showClose: true,
            //         timeout: 5000
            //     });
            // });
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

    addDataItemsToGraph(data: Data[], keyParameter: KeyParameter) {
        let graphData: any[] = [];

        let years = ['2010', '2015', '2020', '2025', '2030', '2035', '2040', '2045', '2050'];

        graphData.push(keyParameter.name);

        for (let year of years) {
            let dataItemByYear = data.filter(
                item => item.year === year
            );
            graphData.push(Math.round(dataItemByYear[0].value));
        }


        this.addItemToQuerieList(this.selectedRegion.name,
            this.selectedScenario.name,
            this.selectedVariable.name,
            keyParameter.name,
            graphData);



        this.graphColumns.push(graphData);
    }


    addItemToGraph(paramName: string, graphData: GraphEntity[]) {
        if (!this.selectedVariable ||
            !this.selectedKeyParameters ||
            this.selectedKeyParameters.length == 0 ||
            !graphData ||
            graphData.length === 0) {
            return;
        }

        let graphItem = [];
        let years = ['2010', '2015', '2020', '2025', '2030', '2035', '2040', '2045', '2050'];

        graphItem.push(paramName);

        for (let year of years) {
            let dataItemByYear = graphData[0].data.filter(
                item => item.year === year
            );
            graphItem.push(Math.round(dataItemByYear[0].value));
        }

        this.graphColumns.push(graphItem);
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

        for (var index = 1; index < data.length; index++) {
            tebaleEntity.data.push(Math.round(data[index]));
        }

        this.tableEntities.entities.push(tebaleEntity);
    }

}