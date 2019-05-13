import { IModel } from './imodel';

export class Team implements IModel {
    constructor(
        public id?: string,
        public name?: string,
    ) {}

    public static mock(): Team {
        return new Team("Mock", "Mock");
    }
}