using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System;
using Microsoft.VisualBasic;
using HttpClientApi.Services;

namespace HttpClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           
            return Ok(await _booksService.Get());                      
        }
    }
}

