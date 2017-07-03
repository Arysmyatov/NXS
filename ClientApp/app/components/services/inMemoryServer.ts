import { InMemoryDbService } from "angular-in-memory-web-api";

export class RegionData implements InMemoryDbService {
    createDb() {
        let regions = [
            { id: 1, name: 'BNL' },
            { id: 2, name: 'DEU' },
            { id: 3, name: 'EEN' },
            { id: 4, name: 'EES' },
            { id: 5, name: 'FRA' },
            { id: 6, name: 'IAM' },
            { id: 7, name: 'IBE' },
            { id: 8, name: 'FRA' },
            { id: 9, name: 'SDF' },
            { id: 10, name: 'UKI' },
            { id: 11, name: 'SWZ' },
            { id: 12, name: 'NOI' }
        ];

        let variableGroups = [
            { id: 1, name: "Primary Energy" },
            { id: 2, name: "Final Energy Consumption" },
            { id: 3, name: "Electricity" },
            { id: 4, name: "Emissiones" },
            { id: 5, name: "Transport" },
            { id: 6, name: "Industry" },
            { id: 7, name: "Residential" },
            { id: 8, name: "Commercial" },
            { id: 9, name: "Agriculture" }
        ];

        let variables = [
            { id: 1, group: '0', name: 'GDP	' },
            { id: 2, group: '0', name: 'Population	' },
            { id: 3, group: '1', name: 'Primary Energy:	Production' },
            { id: 4, group: '1', name: 'Primary Energy:	Imports/Exports' },
            { id: 5, group: '2', name: 'Final Energy Consumption	:	By fuel' },
            { id: 6, group: '2', name: 'Final Energy Consumption	:	By sector' },
            { id: 7, group: '3', name: '	Generation' },
            { id: 8, group: '3', name: '	CO2 intensity' },
            { id: 9, group: '3', name: '	Consumption by sector' },
            { id: 10, group: '3', name: '	Capacity' },
            { id: 11, group: '3', name: '	Annualised investment costs' },
            { id: 12, group: '4', name: '	CO2 emissions by sector' },
            { id: 13, group: '4', name: '	Non-CO2 emissions by sector' },
            { id: 14, group: '4', name: '	CO2 emissions by region' },
            { id: 15, group: '4', name: '	GHG emissions by region' },
            { id: 16, group: '00', name: 'Carbon price	' },
            { id: 17, group: '00', name: 'System costs	' },
            { id: 18, group: '5', name: '	Fuel consumption by technology' },
            { id: 19, group: '6', name: '	Fuel consumption by technology' },
            { id: 20, group: '7', name: '	Fuel consumption by technology' },
            { id: 21, group: '8', name: '	Fuel consumption by technology' },
            { id: 22, group: '9', name: '	Fuel consumption by technology' }
        ];

        let scenarios = [
            { id: 1, name: 'Low Carbon' }
        ];

        let keyParameterGroups = [
            { id: 1, name: "Fossil fuel prices" },
        ]

        let keyParameters = [
            { id: 1, group: 1, name: "Oil" },
            { id: 2, group: 1, name: "Gas" },
            { id: 3, group: 1, name: "Coal" },
            { id: 4, group: 0, name: "Discount rates" },
            { id: 5, group: 0, name: "GDP" },
            { id: 6, group: 0, name: "Population" }
        ]

        let graphData = [
            {
                region: 10, scenario: 1, variable: 3, keyParameter: 1, data: [
                    { year: '2010', value: 10576.3865363018 },
                    { year: '2015', value: 8760.87680129955 },
                    { year: '2020', value: 8618.84542569341 },
                    { year: '2025', value: 8732.35797119228 },
                    { year: '2030', value: 9031.58027888817 },
                    { year: '2035', value: 8706.14663678399 },
                    { year: '2040', value: 8615.78089929309 },
                    { year: '2045', value: 8091.98219093777 },
                    { year: '2050', value: 7317.13645459373 }
                ]
            },
            {
                region: 10, scenario: 1, variable: 3, keyParameter: 3, data: [
                    { year: '2010', value: 1461.37508764513 },
                    { year: '2015', value: 2105.08366783295 },
                    { year: '2020', value: 2066.09256884458 },
                    { year: '2025', value: 2076.19380467366 },
                    { year: '2030', value: 1861.68000063548 },
                    { year: '2035', value: 1631.92709468634 },
                    { year: '2040', value: 1513.89982373514 },
                    { year: '2045', value: 1444.16291626322 },
                    { year: '2050', value: 1415.68103183605 }
                ]
            },
            {
                // Primary Energy - Production, GAS
                region: 10, scenario: 1, variable: 3, keyParameter: 2, data: [
                    { year: '2010', value: 4890.09960402282	},
                    { year: '2015', value: 7363.77118163425 },
                    { year: '2020', value: 9541.40964807824 },
                    { year: '2025', value: 5919.65757360678 },
                    { year: '2030', value: 3559.94513749039 },
                    { year: '2035', value: 2244.35587971705 },
                    { year: '2040', value: 1562.01456589144 },
                    { year: '2045', value: 1415.68103183605 },
                    { year: '2050', value: 1562.01456589144 },
                ]             
            }
        ]

        return {
            regions,
            scenarios,
            variableGroups,
            variables,
            keyParameterGroups,
            keyParameters,
            graphData
        };
    }
}