using Microsoft.AspNetCore.Mvc;
using PremierLigUi.Models;
using PremierLigUi.Services;

namespace PremierLigUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MatchEventController : Controller
    {
        private readonly AdminMatchEventService _eventService;
        private readonly AdminMatchService _matchService;

        public MatchEventController(AdminMatchEventService eventService,AdminMatchService matchService)
        {
            _eventService = eventService;
            _matchService = matchService;
        }

        public async Task<IActionResult> Index(int matchId = 1)
        {
            var matches = await _matchService.GetMatchesAsync();
            var events = await _eventService.GetEventsByMatchIdAsync(matchId);

            ViewBag.Matches = matches;
            ViewBag.SelectedMatchId = matchId;

            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminMatchEventViewModel model)
        {
            await _eventService.CreateEventAsync(model);
            return RedirectToAction("Index", new { matchId = model.MatchId });
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminMatchEventViewModel model)
        {
            await _eventService.UpdateEventAsync(model);
            return RedirectToAction("Index", new { matchId = model.MatchId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int matchId)
        {
            await _eventService.DeleteEventAsync(id);
            return RedirectToAction("Index", new { matchId });
        }
    }
}

