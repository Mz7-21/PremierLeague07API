using Microsoft.AspNetCore.Mvc;
using PremierLigUi.Models;
using PremierLigUi.Services;

namespace PremierLigUi.Controllers
{
    public class LiveScoreController : Controller
    {
        private readonly DashboardService _dashboardService;

        public LiveScoreController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                Overview = await _dashboardService.GetDashboardOverviewAsync(),
                LatestMatches = await _dashboardService.GetLatestMatchesAsync(),
                TopScoringTeams = await _dashboardService.GetTopScoringTeamsAsync(),
                TopFormTeams = await _dashboardService.GetTopFormTeamsAsync(),
                FeaturedMatch = await _dashboardService.GetFeaturedMatchAsync(),
                FinishedMatches = await _dashboardService.GetFinishedMatchesAsync(),
                LiveMatches = await _dashboardService.GetLiveMatchesAsync(),
                UpcomingMatches = await _dashboardService.GetUpcomingMatchesAsync(),
                TopStandingTeam = await _dashboardService.GetTopStandingTeamsAsync(),
                TopScorer = await _dashboardService.GetTopScorersAsync()
            };

            return View(model);
        }
    }
}
