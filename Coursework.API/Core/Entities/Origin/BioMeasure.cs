using Core.Models;
using System;

namespace Core.Entities.Origin
{
    public class BioMeasure : IEntity
    {
        public string Id { get; set; }

        public int Pulse { get; set; }
        public int Pressure { get; set; }
        public DateTime DateMeasured { get; set; }

        public string PlayerId { get; set; }
        public Player Player { get; set; }

        public string MatchId { get; set; }
        public Match Match { get; set; }
    }
}
