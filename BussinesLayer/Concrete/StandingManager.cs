using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.StandingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class StandingManager:IStandingService
    {
        private readonly ITeamDal _teamDal;
        private readonly IMatchDal _matchDal;

        public StandingManager(ITeamDal teamDal, IMatchDal matchDal)
        {
            _teamDal = teamDal;
            _matchDal = matchDal;
        }

        public List<StandingDto> GetStandings()
        {
            var teams = _teamDal.GetList();
            var matches = _matchDal.GetList();

            var standings= new List<StandingDto>();

            foreach (var team in teams) 
            {

                var teamMatches = matches.Where(x =>
                   x.HomeTeamId == team.TeamId ||
                   x.AwayTeamId == team.TeamId).ToList();

                int played = 0;
                int won = 0;
                int drawn = 0;
                int lost = 0;
                int goalsFor = 0;
                int goalsAgainst = 0;
                int points = 0;
                string form = "";

                var lastFiveMatches = teamMatches
                    .OrderByDescending(x => x.MatchDate)
                    .Take(5)
                    .ToList();

                foreach (var match in teamMatches) 
                {
                 played++;
                    bool isHomeTeam = match.HomeTeamId == team.TeamId;

                    int teamGoals = isHomeTeam ? match.HomeScore : match.AwayScore;
                    int opponentGoals = isHomeTeam ? match.AwayScore : match.HomeScore;
                    goalsFor += teamGoals;
                    goalsAgainst += opponentGoals;

                    if (teamGoals > opponentGoals)
                    {
                        won++;
                        points += 3;
                    }
                    else if(teamGoals == opponentGoals)
                    {
                        drawn++;
                        points += 1;
                    }
                    else
                    {
                        lost++;
                    }
                   
                }
                foreach (var match in lastFiveMatches)
                {
                    bool isHomeTeam = match.HomeTeamId == team.TeamId;

                    int teamGoals = isHomeTeam ? match.HomeScore : match.AwayScore;
                    int opponentGoals = isHomeTeam ? match.AwayScore : match.HomeScore;

                    if (teamGoals > opponentGoals)
                        form += "G";
                    else if (teamGoals == opponentGoals)
                        form += "B";
                    else
                        form += "M";
                }
                standings.Add(new StandingDto
                {
                    TeamId = team.TeamId,
                    TeamName = team.Name,
                    Played = played,
                    Won = won,
                    Drawn = drawn,
                    Lost = lost,
                    GoalsFor = goalsFor,
                    GoalsAgainst = goalsAgainst,
                    GoalDifference = goalsFor - goalsAgainst,
                    Points = points,
                    Form = form
                });
            }
            standings= standings
                .OrderByDescending(x=> x.Points)
                .ThenByDescending(x=> x.GoalDifference)
                .ThenByDescending(x => x.GoalsFor)
                .ToList();
            for(int i =0; i < standings.Count; i++)
            {
                standings[i].Position = i + 1;
            }
            return standings;
        }
    }
}
