using PremierLigApi.Dtos.MatchEventDtos;
using PremierLigApi.Dtos.MatchStatisticDtos;

namespace PremierLigApi.Dtos.MatchDtos
{
    public class GetMatchDetailDto
    {
        public int MatchId { get; set; }

        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public DateTime MatchDate { get; set; }

        public List<ResultMatchEventDto> Events { get; set; }

        public ResultMatchStatisticDto Statistics { get; set; }
    }
}
