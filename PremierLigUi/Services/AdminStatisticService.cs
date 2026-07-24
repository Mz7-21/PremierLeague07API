using PremierLigUi.Models;

namespace PremierLigUi.Services
{
    public class AdminStatisticService
    {
        private readonly HttpClient _httpClient;

        public AdminStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AdminStatisticViewModel?> GetStatisticByMatchIdAsync(int matchId)
        {
            return await _httpClient.GetFromJsonAsync<AdminStatisticViewModel>(
                $"https://localhost:7251/api/MatchStatistic/match/{matchId}");
        }

        public async Task UpdateStatisticAsync(AdminStatisticViewModel model)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"https://localhost:7251/api/MatchStatistic/{model.MatchStatisticId}",
                model);

            response.EnsureSuccessStatusCode();
        }
    }
}
