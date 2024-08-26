using HttpClientApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        private readonly IBirdsService _birdsService;

        public BirdsController(IBirdsService birdsService) => _birdsService = birdsService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _birdsService.Get());
        }
    }
}