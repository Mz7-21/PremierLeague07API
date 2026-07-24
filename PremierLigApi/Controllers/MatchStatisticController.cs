using AutoMapper;
using BussinesLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLigApi.Dtos.MatchStatisticDtos;

namespace PremierLigApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchStatisticController : ControllerBase
    {
        private readonly IMatchStatisticService _matchStatisticService;
        private readonly IMapper _mapper;
        public MatchStatisticController(IMatchStatisticService matchStatisticService, IMapper mapper)
        {
            _matchStatisticService = matchStatisticService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult MatchStatisticList()
        {
            var matchStatistics = _matchStatisticService.GetList();
            var matchStatisticsDto = _mapper.Map<List<ResultMatchStatisticDto>>(matchStatistics);
            return Ok(matchStatisticsDto);
        }
        [HttpPost]
        public IActionResult AddMatchStatistic(CreateMatchStatisticDto createMatchStatisticDto)
        {
            var matchStatistic = _mapper.Map<MatchStatistic>(createMatchStatisticDto);
            _matchStatisticService.Add(matchStatistic);
            return Ok("Maç istatistiği eklendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetMatchStatistic(int id)
        {
            var value = _matchStatisticService.GetById(id);
            if(value==null)
                return NotFound("Maç istatistiği bulunamadı");
            var matchStatisticDto = _mapper.Map<GetByIdMatchStatisticDto>(value);
            return Ok(matchStatisticDto);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMatchStatistic(int id, UpdateMatchStatisticDto updateMatchStatisticDto)
        {
            var value = _matchStatisticService.GetById(id);

            if (value == null)
                return NotFound("Maç istatistiği bulunamadı");

            value.MatchId = updateMatchStatisticDto.MatchId;
            value.HomeFirstHalfGoals = updateMatchStatisticDto.HomeFirstHalfGoals;
            value.AwayFirstHalfGoals = updateMatchStatisticDto.AwayFirstHalfGoals;
            value.HomeSecondHalfGoals = updateMatchStatisticDto.HomeSecondHalfGoals;
            value.AwaySecondHalfGoals = updateMatchStatisticDto.AwaySecondHalfGoals;
            value.HomeYellowCards = updateMatchStatisticDto.HomeYellowCards;
            value.AwayYellowCards = updateMatchStatisticDto.AwayYellowCards;
            value.HomeRedCards = updateMatchStatisticDto.HomeRedCards;
            value.AwayRedCards = updateMatchStatisticDto.AwayRedCards;

            _matchStatisticService.Update(value);

            return Ok("Maç istatistiği güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMatchStatistic(int id)
        {
            var value = _matchStatisticService.GetById(id);
            if (value == null)
                return NotFound("Maç istatistiği bulunamadı");

            _matchStatisticService.Delete(value);
            return Ok("Maç istatistiği silindi");
        }
        [HttpGet("match/{matchId}")]
        public IActionResult GetStatisticByMatchId(int matchId)
        {
            var value = _matchStatisticService.GetList()
                .FirstOrDefault(x => x.MatchId == matchId);

            if (value == null)
                return NotFound("Bu maça ait istatistik bulunamadı.");

            var result = new
            {
                value.MatchStatisticId,
                value.MatchId,

                value.HomeFirstHalfGoals,
                value.AwayFirstHalfGoals,

                value.HomeSecondHalfGoals,
                value.AwaySecondHalfGoals,

                value.HomeYellowCards,
                value.AwayYellowCards,

                value.HomeRedCards,
                value.AwayRedCards
            };

            return Ok(result);
        }
    }
}
