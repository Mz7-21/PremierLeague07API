using EntityLayer.Enums;

namespace PremierLigApi.Dtos.MatchDtos
{
    public class GetByIdMatchDto
    {
        public int MatchId { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public DateTime MatchDate { get; set; }

        public string Stadium { get; set; }

        public int Week { get; set; }

        public int HomeScore { get; set; }

        public int AwayScore { get; set; }

        public MatchStatus Status { get; set; }
    }
}
