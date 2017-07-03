class GraphEntities {
    entities: Array<GraphEntity>;
    data: any[];

    buildData(){
        this.data = [[]]; 
    }

    addEntity(entityVal: GraphEntity) {
        this.entities.push(entityVal);
    }
}