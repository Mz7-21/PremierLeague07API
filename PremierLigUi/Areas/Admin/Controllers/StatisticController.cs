using Microsoft.AspNetCore.Mvc;
using PremierLigUi.Models;
using PremierLigUi.Services;

namespace PremierLigUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly AdminStatisticService _statisticService;
        private readonly AdminMatchService _matchService;

        public StatisticController(AdminStatisticService statisticService,AdminMatchService matchService)
        {
            _statisticService = statisticService;
            _matchService = matchService;
        }

        public async Task<IActionResult> Index(int matchId = 1)
        {
            var matches = await _matchService.GetMatchesAsync();
            var statistic = await _statisticService.GetStatisticByMatchIdAsync(matchId);

            ViewBag.Matches = matches;
            ViewBag.SelectedMatchId = matchId;

            return View(statistic);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminStatisticViewModel model)
        {
            await _statisticService.UpdateStatisticAsync(model);
            return RedirectToAction("Index", new { matchId = model.MatchId });
        }
    }
}
