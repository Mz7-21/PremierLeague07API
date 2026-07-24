using Microsoft.AspNetCore.Mvc;
using PremierLigUi.Models;
using PremierLigUi.Services;


namespace PremierLigUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly AdminTeamService _adminTeamService;

        public TeamController(AdminTeamService adminTeamService)
        {
            _adminTeamService = adminTeamService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _adminTeamService.GetTeamsAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminTeamViewModel model)
        {
            await _adminTeamService.CreateTeamAsync(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminTeamViewModel model)
        {
            await _adminTeamService.UpdateTeamAsync(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _adminTeamService.DeleteTeamAsync(id);
            return RedirectToAction("Index");
        }
    }
}
