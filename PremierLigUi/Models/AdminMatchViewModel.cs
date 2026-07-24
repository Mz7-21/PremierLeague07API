namespace PremierLigUi.Models
{
    public class AdminMatchViewModel
    {
        public int MatchId { get; set; }

        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }

        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public string HomeTeamLogoUrl { get; set; }
        public string AwayTeamLogoUrl { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public DateTime MatchDate { get; set; }
        public int Week { get; set; }

        public string Stadium { get; set; }

        public int Status { get; set; }
    }
}
