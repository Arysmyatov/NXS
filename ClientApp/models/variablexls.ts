export interface SaveVariableXls {
    id: number;
    variableGroupId: number,
    variableId: number;
    sheetName: string;
    code: string;
    yearBgRow: number;
    yearBgCol: number;
    yearEndRow: number;
    yearEndCol: number;
    dataBgRow: number;
    dataBgCol: number;
    dataEndRow: number;
    dataEndCol: number;
}