import { IModel } from './imodel';

export class Game implements IModel {
    constructor(
        public id?: string,
        public name?: string,
        public description?: string,
        public dateReleased?: Date,
    ) {}

    public static mock(): Game {
        return new Game("Mock", "Mock", "That's placeholder", new Date());
    }
}