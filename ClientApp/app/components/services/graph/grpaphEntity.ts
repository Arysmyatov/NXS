class GraphEntity {
    region: string;   
    scenario: string;   
    variable: string;   
    keyParameter: string;
    data: GraphEntityData[];
}

class GraphEntityData {
    year: string;
    value: number;
}