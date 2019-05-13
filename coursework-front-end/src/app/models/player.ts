import { IModel } from './imodel';

export class Player implements IModel{
    constructor(
        public id?: string,
        public nickname?: string, 
        public firstName?: string,
        public lasttName?: string,
        public dateOfBirth?: Date,
        public teamId?: string,
    ) { }

    public static mock(): Player {
        return new Player("Mock", "Mocky", "Mo", "Ck", new Date(), "Some Team Id");
    }
}