using HttpClientApi.Models;

namespace HttpClientApi.Services
{
    public interface IBooksService
    {
        public Task<List<Book>> Get();
    }
}