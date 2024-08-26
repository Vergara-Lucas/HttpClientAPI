using HttpClientApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace HttpClientApi.Services
{
    public class BooksService : IBooksService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BooksService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Book>> Get()
        {
            var client = _httpClientFactory.CreateClient("Books");
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            List<Book> BooksList = new List<Book>();
            if (response.IsSuccessStatusCode) {
                var result = response.Content.ReadAsStringAsync().Result;
                BooksList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Book>>(result);
                return BooksList;
            }
            return BooksList;


        }

    }
}