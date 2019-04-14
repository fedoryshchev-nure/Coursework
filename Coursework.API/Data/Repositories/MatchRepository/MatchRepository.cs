using Core.Entities.Origin;
using Data.Repositories.Generic;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.MatchRepository
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        public MatchRepository(ApplicationDBContext context) : base(context)
        {
        }

        public IEnumerable<IEnumerable<BioMeasure>> GetBioMeasuresForTraining() => 
            MatchToMeasures(Set
                .Where(match => match.MatchResult == Match.Result.FirstTeamWon ||
                    match.MatchResult == Match.Result.SecondTeamWon));

        public IEnumerable<IEnumerable<BioMeasure>> GetBioMeasureForPrediction(string matchId) =>
            MatchToMeasures(Set
                .Where(match => match.MatchResult == Match.Result.None &&
                    match.Id == matchId));


        private IEnumerable<IEnumerable<BioMeasure>> MatchToMeasures(IEnumerable<Match> matches) =>
            matches.Select(match => match.TeamOne.Players
                .SelectMany(player => player.BioMeasures
                    .Where(measure => measure.MatchId == match.Id))
                .Concat(match.TeamOne.Players
                    .SelectMany(player => player.BioMeasures
                        .Where(measure => measure.MatchId == match.Id))));
    }
}
