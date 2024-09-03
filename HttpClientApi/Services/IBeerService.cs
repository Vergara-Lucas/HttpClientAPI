
using HttpClientApi.Models;

namespace HttpClientApi.Services
{
    public interface IBeerService
    {
        public Task<IEnumerable<Beer>> Get();
        public Task<Beer?> GetById(int id);
    }
}
