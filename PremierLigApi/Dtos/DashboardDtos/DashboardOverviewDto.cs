namespace PremierLigApi.Dtos.DashboardDtos
{
    public class DashboardOverviewDto
    {
        public int TotalTeams { get; set; }
        public int TotalMatches { get; set; }

        public string LeaderTeam { get; set; }
        public int LeaderPoints { get; set; }

        public string TopScoringTeam { get; set; }
        public int TopScoringGoals { get; set; }
        

        

        public string BestDefenseTeam { get; set; }
        
        public int BestDefenseGoalsAgainst { get; set; }
        
    }
}
