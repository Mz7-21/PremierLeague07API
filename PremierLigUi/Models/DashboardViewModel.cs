using DTOLayer.DashboardDtos;

namespace PremierLigUi.Models
{
    public class DashboardViewModel
    {

        public DashboardOverviewDto? Overview { get; set; }

        public List<DashboardLatestMatchDto>? LatestMatches { get; set; }

        public List<TopScoringTeamDto>? TopScoringTeams { get; set; }

        public List<TopFormTeamDto>? TopFormTeams { get; set; }
        public FeaturedMatchDto? FeaturedMatch { get; set; }
        public List<DashboardLatestMatchDto>? FinishedMatches { get; set; }
        public List<DashboardLatestMatchDto>? LiveMatches { get; set; }
        public List<DashboardLatestMatchDto>? UpcomingMatches { get; set; }
        public List<TopScorerDto>? TopScorer { get; set; }
        public List<TopStandingTeamDto>? TopStandingTeam { get; set; }
    }
}
