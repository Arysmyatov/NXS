import { Component } from "@angular/core";
import { Http } from "@angular/http";
import { TableEntities } from './tableEntity';
import { TableEntity } from './tableEntity';
import { bootstrap } from "bootstrap";
import { AccordionModule } from "ngx-accordion";

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
    variableGroup: number;
    graphData: GraphEntity[];
    graphColumns: any[];
    tableEntities: TableEntities;

    regions: Region[];
    scenarios: Scenario[];
    variableGroups: any[];
    variables: any[];
    keyParameterGroups: any[];
    keyParameters: any[];

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

    constructor(private http: Http) {
        this.variableGroup = 1;

        this.http.get("app/regions").subscribe(
            result => this.regions = result.json().data,
            error => console.log(error.statusText)
        );
        this.http.get("app/scenarios").subscribe(
            result => this.scenarios = result.json().data,
            error => console.log(error.statusText)
        );
        this.http.get("app/variableGroups").subscribe(
            result => this.variableGroups = result.json().data,
            error => console.log(error.statusText)
        );
        this.http.get("app/variables").subscribe(
            result => this.variables = result.json().data,
            error => console.log(error.statusText)
        );
        this.http.get("app/keyParameterGroups").subscribe(
            result => this.keyParameterGroups = result.json().data,
            error => console.log(error.statusText)
        );
        this.http.get("app/keyParameters").subscribe(
            result => this.keyParameters = result.json().data,
            error => console.log(error.statusText)
        );

        this.builHeadGraphColumns();
        this.initQueryColumns();
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

    selectKeyParameter(keyParameter: KeyParameter) {
        if (this.isKeyParametersContainsObj(keyParameter)) {
            // remove from the list
            var index = this.selectedKeyParameters.indexOf(keyParameter, 0);
            if (index > -1) {
                this.selectedKeyParameters.splice(index, 1);
            }
        } else {
            if (!this.selectedKeyParameters) {
                this.selectedKeyParameters = [];
            }
            this.selectedKeyParameters.push(keyParameter);
        }
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


    builGraph() {
        this.builHeadGraphColumns();

        if (!this.selectedRegion ||
            !this.selectedScenario ||
            !this.selectedVariable ||
            !this.selectedKeyParameters ||
            this.selectedKeyParameters.length == 0) {
            return;
        }

        // get Graph data
        this.http.get("app/graphData").subscribe(
            // build columns
            result => this.setGraphColumns(result.json().data),
            error => console.log(error.statusText)
        );
    }


    setGraphColumns(graphData: GraphEntity[]) {
        let filteredData: GraphEntity[] = this.filterByVariabes(graphData);
                
        this.tableEntities.entities = [];

        if (!filteredData ||
            filteredData.length === 0) {
            return;
        }

        for (let keyParameter of this.selectedKeyParameters) {
            let dataItemByKeyParameter = filteredData.filter(
                item => item.keyParameter === keyParameter.id);
            this.addItemToGraph(keyParameter.name, dataItemByKeyParameter);

            this.addItemToQuerieList(this.selectedRegion.name,
                this.selectedScenario.name,
                this.selectedVariable.name,
                keyParameter.name,
                dataItemByKeyParameter[0].data);
        }
    }


    filterByVariabes(graphData: GraphEntity[]): GraphEntity[] {
        let filteredData: GraphEntity[] = [];

        if (!graphData || graphData.length == 0 ||
            !this.selectedVariable) {
            return filteredData;
        }

        filteredData = graphData.filter(
            item => item.region === this.selectedRegion.id &&
                item.scenario === this.selectedScenario.id &&
                item.variable === this.selectedVariable.id
        );
        return filteredData;
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

        this.c3_ChartData.columns = this.graphColumns;
    }

    addItemToQuerieList(region: string, scenario: string, variable: string, keyParameter: string, data: GraphEntityData[]) {
        let tebaleEntity = new TableEntity();
        tebaleEntity.region = region;
        tebaleEntity.scenario = scenario;
        tebaleEntity.variable = variable;
        tebaleEntity.keyParameter = keyParameter;
        tebaleEntity.data = [];
        if(!this.tableEntities.entities) {
            this.tableEntities.entities = [];
        }

        for (var index = 0; index < data.length; index++) {
            tebaleEntity.data.push(Math.round(data[index].value));
        }

        this.tableEntities.entities.push(tebaleEntity);
    }

    builHeadGraphColumns() {
        this.graphColumns = [];
        this.graphColumns.push(['x', '2010', '2015', '2020', '2025', '2030', '2035', '2040', '2045', '2050']);

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
}