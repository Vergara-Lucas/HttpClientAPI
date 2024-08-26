using HttpClientApi.Models;

namespace HttpClientApi.Services
{
    public class BirdsService : IBirdsService
    {
        private readonly HttpClient _httpClient;

        public BirdsService(HttpClient httpClient) => (_httpClient) = (httpClient);

        public async Task<List<Bird>> Get()
        {
            var listBirds = await _httpClient.GetFromJsonAsync<List<Bird>>(_httpClient.BaseAddress);

            return listBirds;
        }
    }
}