using Microsoft.AspNetCore.Mvc;
using PremierLigUi.Models;
using PremierLigUi.Services;

namespace PremierLigUi.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DashboardService _dashboardService;

        public DashboardController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                Overview = await _dashboardService.GetDashboardOverviewAsync(),
                FeaturedMatch = await _dashboardService.GetFeaturedMatchAsync(),
                FinishedMatches = await _dashboardService.GetFinishedMatchesAsync(),
                LiveMatches = await _dashboardService.GetLiveMatchesAsync(),
                UpcomingMatches = await _dashboardService.GetUpcomingMatchesAsync(),
                TopScoringTeams = await _dashboardService.GetTopScoringTeamsAsync(),
                TopFormTeams = await _dashboardService.GetTopFormTeamsAsync(),
                TopStandingTeam = await _dashboardService.GetTopStandingTeamsAsync(),
                TopScorer = await _dashboardService.GetTopScorersAsync()
            };
            return View(model);
        }
    }
}
