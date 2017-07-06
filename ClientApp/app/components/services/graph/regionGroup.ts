import { Region } from "./region";

class RegionGroup {
    id: string;
    name: string;
    regions: Region[];

    constructor(idValue: string, nameValue: string) {
        this.id = idValue;
        this.name = nameValue;
    }
}