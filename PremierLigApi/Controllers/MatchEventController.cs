using AutoMapper;
using BussinesLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLigApi.Dtos.MatchEventDtos;

namespace PremierLigApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchEventController : ControllerBase
    {
        private readonly IMatchEventService _matchEventService;
        private readonly IMapper _mapper;

        public MatchEventController(IMatchEventService matchEventService, IMapper mapper)
        {
            _matchEventService = matchEventService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult MatchEventList()
        {
            var matchEvents = _matchEventService.GetList();
            var matchEventDtos = _mapper.Map<List<ResultMatchEventDto>>(matchEvents);
            return Ok(matchEventDtos);
        }
        [HttpGet("{id}")]
        public IActionResult GetMatchEvent(int id)
        {
            var matchEvent = _matchEventService.GetById(id);
            if (matchEvent == null)
            {
                return NotFound("Maç Olayı Bulunamadı");
            }
            var matchEventDto = _mapper.Map<GetByIdMatchEventDto>(matchEvent);
            return Ok(matchEventDto);
        }
        [HttpPost]
        public IActionResult AddMatchEvent([FromBody] CreateMatchEventDto createMatchEventDto)
        {
            var matchEvent = _mapper.Map<MatchEvent>(createMatchEventDto);
            _matchEventService.Add(matchEvent);
            return Ok("Maç olayı eklendi");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMatchEvent(int id, UpdateMatchEventDto updateMatchEventDto)
        {
            var value = _matchEventService.GetById(id);

            if (value == null)
                return NotFound("Maç olayı bulunamadı");

            value.MatchId = updateMatchEventDto.MatchId;
            value.TeamId = updateMatchEventDto.TeamId;
            value.Minute = updateMatchEventDto.Minute;
            value.ActionType = updateMatchEventDto.ActionType;
            value.Description = updateMatchEventDto.Description;

            _matchEventService.Update(value);

            return Ok("Maç olayı güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMatchEvent(int id)
        {
            var matchEvent = _matchEventService.GetById(id);
            if (matchEvent == null)
            {
                return NotFound("Maç Olayı Bulunamadı");
            }
            _matchEventService.Delete(matchEvent);
            return Ok("Maç Olayı Silindi");
        }
    }
}
