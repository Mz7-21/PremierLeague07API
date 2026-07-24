using DTOLayer.DashboardDtos;

namespace PremierLigUi.Services
{
    public class FixtureService
    {
        private readonly HttpClient _httpClient;

        public FixtureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DashboardLatestMatchDto>?> GetMatchesByWeekAsync(int week)
        {
            return await _httpClient.GetFromJsonAsync<List<DashboardLatestMatchDto>>(
                $"https://localhost:7251/api/Match/week/{week}");
        }
    }
}
