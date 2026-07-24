using EntityLayer.Enums;

namespace PremierLigApi.Dtos.MatchEventDtos
{
    public class ResultMatchEventDto
    {
        public int MatchEventId { get; set; }

        public int MatchId { get; set; }
        public int TeamId { get; set; }

        public string TeamName { get; set; }
        public string TeamLogoUrl { get; set; }

        public int Minute { get; set; }


        public MatchActionType ActionType { get; set; }
        public string? PlayerName { get; set; }

        public string Description { get; set; }
    }
}
