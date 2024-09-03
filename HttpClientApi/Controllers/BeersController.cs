using HttpClientApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly IBeerService _beerService;
        public BeersController(IBeerService beerService)
        {
            _beerService = beerService;
        }
        [HttpGet]
        public async Task<IActionResult> Get() {
            return Ok(await _beerService.Get());
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id) {
            return Ok(await _beerService.GetById(id));
        }

    }
}
