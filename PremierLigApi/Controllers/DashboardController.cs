using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLigApi.Dtos.DashboardDtos;

namespace PremierLigApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IMatchService _matchService;
        private readonly IStandingService _standingService;

        public DashboardController(ITeamService teamService, IMatchService matchService, IStandingService standingService)
        {
            _teamService = teamService;
            _matchService = matchService;
            _standingService = standingService;
        }
        [HttpGet("overview")]
        public IActionResult Overview()
        { 
            var teams = _teamService.GetList();
            var matches = _matchService.GetList();
            var standings = _standingService.GetStandings();

            var leader= standings.FirstOrDefault();

            var topScoringTeam = standings
                .OrderByDescending (x=> x.GoalsFor)
                .FirstOrDefault();
           
            var BestDefensiveTeam = standings
                .OrderBy(x => x.GoalsAgainst)
                .FirstOrDefault();
            
            var result = new DashboardOverviewDto
            {
                TotalTeams = teams.Count,
                TotalMatches = matches.Count,
                LeaderTeam = leader?.TeamName ?? "-",
                LeaderPoints = leader?.Points ?? 0,
                TopScoringTeam = topScoringTeam?.TeamName ?? "-",
                TopScoringGoals = topScoringTeam?.GoalsFor ?? 0,
                BestDefenseTeam = BestDefensiveTeam?.TeamName ?? "-",
                BestDefenseGoalsAgainst = BestDefensiveTeam?.GoalsAgainst ?? 0,
                
            };
            return Ok(result);
        }
        [HttpGet("latestmatch")]
        public IActionResult LatestMatch()
        {
            var matches = _matchService.GetMatchesWithTeams()
                    .OrderByDescending(x => x.MatchDate)
                    .Take(10)
                    .Select(x=> new DashboardLatestMatchDto
                    {
                        MatchId = x.MatchId,
                        HomeTeam = x.HomeTeam ?.Name ?? "-",
                        AwayTeam = x.AwayTeam?.Name ?? "-",
                        HomeScore = x.HomeScore,
                        AwayScore = x.AwayScore,
                        MatchDate = x.MatchDate,
                        Week = x.Week,
                        Stadium = x.Stadium

                    })
                    .ToList();
            return Ok(matches);
        }
        [HttpGet("topscoringteams")]
        public IActionResult TopScoringTeams()
        {
            var teams= _standingService.GetStandings()
                .OrderByDescending(x => x.GoalsFor)
                .Take(5)
                .Select(x => new TopScoringTeamDto
                {
                    TeamName = x.TeamName,
                    GoalsFor = x.GoalsFor
                })
                .ToList();
            
            return Ok(teams);
        }
        [HttpGet("topformteams")]
        public IActionResult TopFormTeams()
        {
            var team = _standingService.GetStandings()
                .Select(x => new TopFormTeamDto
                {
                    TeamName = x.TeamName,
                    Form = x.Form,
                    FormPoints = x.Form.Sum( f=>
                        f == 'G' ? 3:
                        f == 'B' ? 1:
                        0)

                })
                .OrderByDescending(x => x.FormPoints)
                .Take(5)
                .ToList();

            return Ok(team);
        }
      
    }
}
