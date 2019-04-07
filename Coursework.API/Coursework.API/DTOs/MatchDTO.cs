using System;

namespace Coursework.API.DTOs
{
    public class MatchDTO
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
        public string TeamOneId { get; set; }
        public string TeamTwoId { get; set; }
    }
}
