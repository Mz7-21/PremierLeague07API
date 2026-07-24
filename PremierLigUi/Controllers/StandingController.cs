using Microsoft.AspNetCore.Mvc;
using PremierLigUi.Models;
using PremierLigUi.Services;

namespace PremierLigUi.Controllers
{
    public class StandingController : Controller
    {
        private readonly StandingService _standingService;

        public StandingController(StandingService standingService)
        {
            _standingService = standingService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new StandingViewModel
            {
                Standings = await _standingService.GetStandingsAsync()
            };

            return View(model);
        }
    }
}
