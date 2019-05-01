using Core.Entities.Origin;
using Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
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
            MatchToMeasures(GetMatchesWithTeamsAndPlayers()
                .Where(match => match.MatchResult == Match.Result.FirstTeamWon ||
                    match.MatchResult == Match.Result.SecondTeamWon));

        public IEnumerable<IEnumerable<BioMeasure>> GetBioMeasureForPrediction(string matchId) =>
            MatchToMeasures(GetMatchesWithTeamsAndPlayers()
                .Where(match => match.MatchResult == Match.Result.None &&
                    match.Id == matchId));


        private IEnumerable<IEnumerable<BioMeasure>> MatchToMeasures(IEnumerable<Match> matches) =>
            matches.Select(match => match.TeamOne.Players
                .SelectMany(player => player.BioMeasures
                    .Where(measure => measure.MatchId == match.Id))
                .Concat(match.TeamOne.Players
                    .SelectMany(player => player.BioMeasures
                        .Where(measure => measure.MatchId == match.Id))));

        public IEnumerable<Match> GetMatchesWithTeamsAndPlayers() =>
            Set.Include(x => x.TeamOne)
                .ThenInclude(x => x.Players)
                    .ThenInclude(x => x.BioMeasures)
            .Include(x => x.TeamTwo)
                .ThenInclude(x => x.Players)
                    .ThenInclude(x => x.BioMeasures);
    }
}
