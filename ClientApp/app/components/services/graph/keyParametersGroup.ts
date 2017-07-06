import { KeyParameter } from "./keyParameter";

export class KeyParameterGroup {
    id: string;
    name: string;
    keyParameters: KeyParameter[]

    constructor(idValue: string, nameValue: string) {
        this.id = idValue;
        this.name = nameValue;
    }
}