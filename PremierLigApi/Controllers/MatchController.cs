using AutoMapper;
using BussinesLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLigApi.Dtos.MatchDtos;

namespace PremierLigApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IMapper _mapper;
        public MatchController(IMatchService matchService, IMapper mapper)
        {
            _matchService = matchService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult MatchList()
        {
            var matches = _matchService.GetList();
            return Ok(matches);

        }
        [HttpGet("{id}")]
        public IActionResult GetMatch(int id)
        {
            var value = _matchService.GetById(id);
            if (value == null)
                return NotFound("Maç  Bulunamadı");

            var result = _mapper.Map<GetByIdMatchDto>(value);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateMatch(CreateMatchDto createMatchDto)
        {
            var match = _mapper.Map<EntityLayer.Entities.Match>(createMatchDto);
            _matchService.Add(match);
            return Ok("Maç Eklendi");
        }
        [HttpPut()]
        public IActionResult UpdateMatch(UpdateMatchDto updateMatchDto)
        {
            var match = _mapper.Map<EntityLayer.Entities.Match>(updateMatchDto);
            _matchService.Update(match);
            return Ok("Maç Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMatch(int id)
        {
            var match = _matchService.GetById(id);
            if (match == null)
                return NotFound("Maç Bulunamadı");

            _matchService.Delete(match);
            return Ok("Maç Silindi");
        }
    }
}
