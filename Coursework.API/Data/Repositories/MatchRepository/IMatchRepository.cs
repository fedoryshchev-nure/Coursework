using Core.Entities.Origin;
using Data.Repositories.Generic;
using System.Collections.Generic;

namespace Data.Repositories.MatchRepository
{
    public interface IMatchRepository : IGenericRepository<Match>
    {
        IEnumerable<IEnumerable<BioMeasure>> GetBioMeasuresForTraining();
        IEnumerable<IEnumerable<BioMeasure>> GetBioMeasureForPrediction(string matchId);
    }
}
