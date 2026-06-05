using BussinesLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PremierLigApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingController : ControllerBase
    {
        private readonly IStandingService _standingService;

        public StandingController(IStandingService standingService)
        {
            _standingService = standingService;
        }
        [HttpGet]
        public IActionResult GetStandings()
        {
            var standings = _standingService.GetStandings();
            return Ok(standings);
        }
    }
}
