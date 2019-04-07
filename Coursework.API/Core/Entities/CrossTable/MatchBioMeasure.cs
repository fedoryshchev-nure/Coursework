using Core.Entities.Origin;

namespace Core.Entities.CrossTable
{
    public class MatchBioMeasure
    {
        public string MatchId { get; set; }
        public Match Match { get; set; }

        public string BioMeasureId { get; set; }
        public BioMeasure BioMeasure { get; set; }
    }
}
