using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DashboardDtos;
using EntityLayer.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PremierLigApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IMatchService _matchService;
        private readonly IStandingService _standingService;
        private readonly IMatchEventService _matchEventService;

        public DashboardController(ITeamService teamService, IMatchService matchService, IStandingService standingService, IMatchEventService matchEventService)
        {
            _teamService = teamService;
            _matchService = matchService;
            _standingService = standingService;
            _matchEventService = matchEventService;
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
    
        [HttpGet("featuredmatch")]
        public IActionResult FeaturedMatch()
        {
            var leader = _standingService.GetStandings().FirstOrDefault();

            if (leader == null)
                return NotFound("Lider takım bulunamadı");

            var match = _matchService.GetMatchesWithTeams()
                .Where(x => x.HomeTeam.Name == leader.TeamName ||
                            x.AwayTeam.Name == leader.TeamName)
                .OrderByDescending(x => x.MatchDate)
                .FirstOrDefault();

            if (match == null)
                return NotFound("Lider takımın maçı bulunamadı");

            var value = new FeaturedMatchDto
            {
                MatchId = match.MatchId,
                HomeTeamLogoUrl = match.HomeTeam?.LogoUrl ?? "",
                AwayTeamLogoUrl = match.AwayTeam?.LogoUrl ?? "",
                HomeTeam = match.HomeTeam?.Name ?? "-",
                AwayTeam = match.AwayTeam?.Name ?? "-",
                HomeScore = match.HomeScore,
                AwayScore = match.AwayScore,
                MatchDate = match.MatchDate,
                Stadium = match.Stadium,
                Week = match.Week
            };

            return Ok(value);
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
                        HomeTeamLogoUrl = x.HomeTeam?.LogoUrl ?? "",
                        AwayTeamLogoUrl = x.AwayTeam?.LogoUrl ?? "",
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
        [HttpGet("finishedmatches")]
        public IActionResult FinishedMatches()
        {
            var allMatches = _matchService.GetMatchesWithTeams();

            var lastFinishedWeek = allMatches
                .Where(x => x.Status == MatchStatus.Finished)
                .Max(x => x.Week);

            var values = allMatches
                .Where(x => x.Status == MatchStatus.Finished && x.Week == lastFinishedWeek)
                .OrderBy(x => x.MatchDate)
                .Select(x => new DashboardLatestMatchDto
                {
                    MatchId = x.MatchId,
                    HomeTeamLogoUrl = x.HomeTeam?.LogoUrl ?? "",
                    AwayTeamLogoUrl = x.AwayTeam?.LogoUrl ?? "",
                    HomeTeam = x.HomeTeam?.Name ?? "-",
                    AwayTeam = x.AwayTeam?.Name ?? "-",
                    HomeScore = x.HomeScore,
                    AwayScore = x.AwayScore,
                    MatchDate = x.MatchDate,
                    Week = x.Week,
                    Stadium = x.Stadium
                })
                .ToList();

            return Ok(values);
        }
        [HttpGet("livematches")]
        public IActionResult LiveMatches()
        {
            var values = _matchService.GetMatchesWithTeams()
                .Where(x => x.Status == MatchStatus.Live)
                .OrderBy(x => x.MatchDate)
                .Select(x => new DashboardLatestMatchDto
                {
                    MatchId = x.MatchId,
                    HomeTeamLogoUrl = x.HomeTeam?.LogoUrl ?? "",
                    AwayTeamLogoUrl = x.AwayTeam?.LogoUrl ?? "",
                    HomeTeam = x.HomeTeam.Name,
                    AwayTeam = x.AwayTeam.Name,
                    HomeScore = x.HomeScore,
                    AwayScore = x.AwayScore,
                    MatchDate = x.MatchDate,
                    Week = x.Week,
                    Stadium = x.Stadium
                }).ToList();

            return Ok(values);
        }
        [HttpGet("upcomingmatches")]
        public IActionResult UpcomingMatches()
        {
            var values = _matchService.GetMatchesWithTeams()
                .Where(x => x.Status == MatchStatus.NotPlayed)
                .OrderBy(x => x.MatchDate)
                .Take(5)
                .Select(x => new DashboardLatestMatchDto
                {
                    MatchId = x.MatchId,
                    HomeTeamLogoUrl = x.HomeTeam?.LogoUrl ?? "",
                    AwayTeamLogoUrl = x.AwayTeam?.LogoUrl ?? "",
                    HomeTeam = x.HomeTeam.Name,
                    AwayTeam = x.AwayTeam.Name,
                    HomeScore = x.HomeScore,
                    AwayScore = x.AwayScore,
                    MatchDate = x.MatchDate,
                    Week = x.Week,
                    Stadium = x.Stadium
                }).ToList();

            return Ok(values);
        }
        [HttpGet("topscorers")]
        public IActionResult TopScorers()
        {
            var matches = _matchService.GetMatchesWithTeams();
            var events = _matchEventService.GetList();

            var values = events
                .Where(x => x.ActionType == MatchActionType.Goal && !string.IsNullOrEmpty(x.PlayerName))
                .Join(matches,
                    e => e.MatchId,
                    m => m.MatchId,
                    (e, m) => new
                    {
                        e.PlayerName,
                        TeamName = e.TeamId == m.HomeTeamId ? m.HomeTeam.Name : m.AwayTeam.Name,
                        TeamLogoUrl = e.TeamId == m.HomeTeamId ? m.HomeTeam.LogoUrl : m.AwayTeam.LogoUrl
                    })
                .GroupBy(x => new { x.PlayerName, x.TeamName, x.TeamLogoUrl })
                .Select(g => new TopScorerDto
                {
                    PlayerName = g.Key.PlayerName,
                    TeamName = g.Key.TeamName,
                    TeamLogoUrl = g.Key.TeamLogoUrl,
                    GoalCount = g.Count()
                })
                .OrderByDescending(x => x.GoalCount)
                .Take(5)
                .ToList();

            return Ok(values);
        }
        [HttpGet("topstandingteams")]
        public IActionResult TopStandingTeams()
        {
            var values = _standingService.GetStandings()
                .OrderBy(x => x.Position)
                .Take(5)
                .Select(x => new TopStandingTeamDto
                {
                    Position = x.Position,
                    TeamName = x.TeamName,
                    LogoUrl = x.LogoUrl,
                    Points = x.Points
                })
                .ToList();

            return Ok(values);
        }
    }
}
