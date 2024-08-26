using HttpClientApi.Models;

namespace HttpClientApi.Services
{
    public interface IBirdsService
    {
        public Task<List<Bird>> Get();
    }
}