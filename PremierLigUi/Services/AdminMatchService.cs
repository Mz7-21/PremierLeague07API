using PremierLigUi.Models;

namespace PremierLigUi.Services
{
    public class AdminMatchService
    {
        private readonly HttpClient _httpClient;

        public AdminMatchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AdminMatchViewModel>?> GetMatchesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<AdminMatchViewModel>>(
                "https://localhost:7251/api/Match/admin-list");
        }
     
        public async Task CreateMatchAsync(AdminMatchViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "https://localhost:7251/api/Match",
                model);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateMatchAsync(AdminMatchViewModel model)
        {
            var response = await _httpClient.PutAsJsonAsync(
                "https://localhost:7251/api/Match",
                model);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteMatchAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"https://localhost:7251/api/Match/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
