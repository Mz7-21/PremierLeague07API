using BussinesLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLigApi.Mapping;

namespace PremierLigApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly MappingProfile _mappingProfile;

        public TeamController(ITeamService teamService, MappingProfile mappingProfile)
        {
            _teamService = teamService;
            _mappingProfile = mappingProfile;
        }
        [HttpGet]
        public IActionResult TeamList()
        {
            var teams = _teamService.GetList();
            return Ok(teams);
        }
        [HttpGet("{id}")]
        public IActionResult GetTeam(int id)
        {
            var team = _teamService.GetById(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            _teamService.TeamAdd(team);
            return Ok("Takım Eklendi..");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTeam(int id, Team team)
        {
            var value = _teamService.GetById(id);

            if (value == null)
            {
                return NotFound("Takım bulunamadı");
            }

            value.Name = team.Name;
            value.ShortName = team.ShortName;
            value.LogoUrl = team.LogoUrl;
            value.City = team.City;
            value.StadiumName = team.StadiumName;

            _teamService.TeamUpdate(value);
            return Ok("Takım güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            var team = _teamService.GetById(id);
            if (team == null)
            {
                return NotFound();
            }
            _teamService.TeamDelete(team);
            return Ok("Takım Silindi..");
        }
    }
}
