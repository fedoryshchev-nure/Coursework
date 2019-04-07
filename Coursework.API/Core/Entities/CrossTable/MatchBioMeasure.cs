using Core.Entities.Origin;

namespace Core.Entities.CrossTable
{
    class MatchBioMeasure
    {
        public string MatchId { get; set; }
        public Match Match { get; set; }

        public string MeasureId { get; set; }
        public BioMeasure MeasureBio { get; set; }
    }
}
