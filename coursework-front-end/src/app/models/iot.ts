import { IModel } from './imodel';

export class IOT implements IModel {
    constructor(
        public pulse?: number,
        public pressure?: number,
        public dateMeasured: Date = new Date(),
        public playerId?: string,
        public matchId?: string,
        public id?: string,
    ) {}
}