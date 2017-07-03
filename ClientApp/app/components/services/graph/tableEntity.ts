export class TableEntity {
    region: string;
    scenario: string;
    variable: string;
    keyParameter: string;
    data: number[];
}

export class TableEntities {
    entities: TableEntity[];
    yearList: string[];

    constructor(years: string[]) {
        this.yearList = years;
    }
}