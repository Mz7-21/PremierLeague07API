using DTOLayer.StandingDtos;
using System.Net.Http.Json;

namespace PremierLigUi.Services
{
    public class StandingService
    {
        private readonly HttpClient _httpClient;

        public StandingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<StandingDto>?> GetStandingsAsync() 
        {
            return await _httpClient.GetFromJsonAsync<List<StandingDto>>(
                "https://localhost:7251/api/Standing");
        }
    }
}
