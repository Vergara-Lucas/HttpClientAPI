using HttpClientApi.Models;

namespace HttpClientApi.Services
{
    public class BeerService : IBeerService
    {
       private readonly IHttpClientFactory _httpClientFactory;

        public BeerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<IEnumerable<Beer>>Get()
        {
            var client = _httpClientFactory.CreateClient("Beers");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            List<Beer> BeersList = new List<Beer>();
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                BeersList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Beer>>(result);
                return BeersList;
            }
            return BeersList;
        }

        public async Task<Beer?> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient("Beers");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            Beer beer = new Beer();
            if (response.IsSuccessStatusCode) {
                var result = response.Content.ReadAsStringAsync().Result;
                List<Beer> BeersList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Beer>>(result);
                beer = BeersList.FirstOrDefault(b=>b.Id == id);
                if (beer != null) {

                    return beer;
                }
            }
            return beer;

        }
    }
}
