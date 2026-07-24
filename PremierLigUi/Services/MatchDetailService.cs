using DTOLayer.MatchDto;
using System.Net.Http.Json;

namespace PremierLigUi.Services
{
    public class MatchDetailService
    {
        private readonly HttpClient _httpClient;

        public MatchDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MatchDetailDto?> GetMatchDetailByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<MatchDetailDto>(
                $"https://localhost:7251/api/Match/detail/{id}");
        }
    }
}
