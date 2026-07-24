using Microsoft.AspNetCore.Mvc;
using PremierLigUi.Models;
using PremierLigUi.Services;

namespace PremierLigUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MatchController : Controller
    {
        private readonly AdminMatchService _adminMatchService;
        private readonly AdminTeamService _adminTeamService;

        public MatchController(AdminMatchService adminMatchService, AdminTeamService adminTeamService)
        {
            _adminMatchService = adminMatchService;
            _adminTeamService = adminTeamService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _adminMatchService.GetMatchesAsync();
            var teams = await _adminTeamService.GetTeamsAsync();

            ViewBag.Teams = teams;
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminMatchViewModel model)
        {
            await _adminMatchService.CreateMatchAsync(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(AdminMatchViewModel model)
        {
            await _adminMatchService.UpdateMatchAsync(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _adminMatchService.DeleteMatchAsync(id);
            return RedirectToAction("Index");
        }
    }
}
