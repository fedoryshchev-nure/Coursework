import { IModel } from './imodel';
import { MatchResult } from './match-result-enum';

export class Match implements IModel {
    constructor(
        public id?: string,
        public date?: Date,
        public result?: MatchResult,
        public gameId?: string,
        public teamOneId?: string,
        public teamTwoId?: string
    ) {}

    public static mock(): Match {
        return new Match("Mock", new Date(), MatchResult.Tie, "Mock game", "Mock t1", "Mock t2");
    }
}