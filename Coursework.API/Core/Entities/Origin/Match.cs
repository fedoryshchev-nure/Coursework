using Core.Models;
using System;

namespace Core.Entities.Origin
{
    class Match : IEntity
    {
        public enum Result
        {
            FirstTeamWon,
            SecondTeamWon,
            Tie,
            None
        }

        public string Id { get; set; }

        public DateTime Date { get; set; }
        public Result MatchResult { get; set; } = Result.None;

        public string GameId { get; set; }
        public Game Game { get; set; }

        public string TeamOneId { get; set; }
        public Team TeamOne { get; set; }

        public string TeamTwoId { get; set; }
        public Team TeamTwo { get; set; }
    }
}
