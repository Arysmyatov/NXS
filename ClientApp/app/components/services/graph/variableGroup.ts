
import { Variable } from "./variable";

export class VariableGroup {
    id: string;
    name: string;
    variables: Variable[]

    constructor(idValue: string, nameValue: string, variables: Variable[]) {
        this.id = idValue;
        this.name = nameValue;
        this.variables = variables;
    }
}