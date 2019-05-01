using System;

namespace Coursework.API.DTOs
{
    public class BioMeasureDTO
    {
        public string Id { get; set; }

        public int Pulse { get; set; }
        public int Pressure { get; set; }
        public DateTime DateMeasured { get; set; }

        public string PlayerId { get; set; }
        public string MatchId { get; set; }
    }
}
