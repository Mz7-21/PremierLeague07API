using PremierLigUi.Models;

namespace PremierLigUi.Services
{
    public class AdminMatchEventService
    {
        private readonly HttpClient _httpClient;

        public AdminMatchEventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AdminMatchEventViewModel>?> GetEventsByMatchIdAsync(int matchId)
        {
            return await _httpClient.GetFromJsonAsync<List<AdminMatchEventViewModel>>(
                $"https://localhost:7251/api/MatchEvent/match/{matchId}");
        }

        public async Task CreateEventAsync(AdminMatchEventViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "https://localhost:7251/api/MatchEvent",
                model);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEventAsync(AdminMatchEventViewModel model)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"https://localhost:7251/api/MatchEvent/{model.MatchEventId}",
                model);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEventAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"https://localhost:7251/api/MatchEvent/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
