using PremierLigUi.Models;

namespace PremierLigUi.Services
{
    public class AdminTeamService
    {
        private readonly HttpClient _httpClient;

        public AdminTeamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AdminTeamViewModel>?> GetTeamsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<AdminTeamViewModel>>(
                "https://localhost:7251/api/Team");
        }
        public async Task CreateTeamAsync(AdminTeamViewModel model)
        {
            await _httpClient.PostAsJsonAsync(
                "https://localhost:7251/api/Team",
                model);
        }

        public async Task UpdateTeamAsync(AdminTeamViewModel model)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"https://localhost:7251/api/Team/{model.TeamId}",
                model);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteTeamAsync(int id)
        {
            await _httpClient.DeleteAsync(
                $"https://localhost:7251/api/Team/{id}");
        }
    }
}
