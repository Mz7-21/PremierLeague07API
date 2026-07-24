using Microsoft.AspNetCore.Mvc;
using PremierLigUi.Services;

namespace PremierLigUi.Controllers
{
    public class MatchDetailController : Controller
    {
        private readonly MatchDetailService _matchDetailService;

        public MatchDetailController(MatchDetailService matchDetailService)
        {
            _matchDetailService = matchDetailService;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var value = await _matchDetailService.GetMatchDetailByIdAsync(id);

            if (value == null)
                return NotFound();

            return View(value);
        }
    }
}
