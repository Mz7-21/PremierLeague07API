namespace PremierLigUi.Models
{
    public class AdminMatchEventViewModel
    {
        public int MatchEventId { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }

        public string TeamName { get; set; }
        public string TeamLogoUrl { get; set; }

        public int ActionType { get; set; }

        public string? PlayerName { get; set; }

        public string Description { get; set; }

        public int Minute { get; set; }
    }
}
