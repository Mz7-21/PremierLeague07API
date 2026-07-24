using Microsoft.AspNetCore.Mvc;
using PremierLigUi.Models;
using PremierLigUi.Services;

namespace PremierLigUi.Controllers
{
    public class FixtureController : Controller
    {
        private readonly FixtureService _fixtureService;

        public FixtureController(FixtureService fixtureService)
        {
            _fixtureService = fixtureService;
        }

        public async Task<IActionResult> Index(int week = 11)
        {
            if (week < 1) week = 1;
            if (week > 38) week = 38;

            var model = new FixtureViewModel
            {
                CurrentWeek = week,
                Matches = await _fixtureService.GetMatchesByWeekAsync(week)
            };

            return View(model);
        }
    }
}
