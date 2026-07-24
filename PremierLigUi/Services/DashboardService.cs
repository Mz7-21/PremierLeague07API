using DTOLayer.DashboardDtos;
using System.Net.Http.Json;

namespace PremierLigUi.Services
{
    public class DashboardService
    {
        private readonly HttpClient _httpClient;

        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<DashboardOverviewDto?> GetDashboardOverviewAsync()
        {
            return await _httpClient.GetFromJsonAsync<DashboardOverviewDto>
                    ("https://localhost:7251/api/Dashboard/overview");
        }
        public async Task<List<DashboardLatestMatchDto>?> GetLatestMatchesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<DashboardLatestMatchDto>>(
                "https://localhost:7251/api/Dashboard/latestmatch");
        }
        public async Task<List<TopScoringTeamDto>?> GetTopScoringTeamsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TopScoringTeamDto>>(
                "https://localhost:7251/api/Dashboard/topscoringteams");
        }
        public async Task<List<TopFormTeamDto>?> GetTopFormTeamsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TopFormTeamDto>>(
                "https://localhost:7251/api/Dashboard/topformteams");
        }
        public async Task<FeaturedMatchDto?> GetFeaturedMatchAsync()
        {
            return await _httpClient.GetFromJsonAsync<FeaturedMatchDto>(
                "https://localhost:7251/api/Dashboard/featuredmatch");
        }
       
        public async Task<List<DashboardLatestMatchDto>?> GetFinishedMatchesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<DashboardLatestMatchDto>>(
                "https://localhost:7251/api/Dashboard/finishedmatches");
        }

        public async Task<List<DashboardLatestMatchDto>?> GetLiveMatchesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<DashboardLatestMatchDto>>(
                "https://localhost:7251/api/Dashboard/livematches");
        }

        public async Task<List<DashboardLatestMatchDto>?> GetUpcomingMatchesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<DashboardLatestMatchDto>>(
                "https://localhost:7251/api/Dashboard/upcomingmatches");
        }
        public async Task<List<TopStandingTeamDto>?> GetTopStandingTeamsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TopStandingTeamDto>>(
                "https://localhost:7251/api/Dashboard/topstandingteams");
        }

        public async Task<List<TopScorerDto>?> GetTopScorersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TopScorerDto>>(
                "https://localhost:7251/api/Dashboard/topscorers");
        }
    }
}
