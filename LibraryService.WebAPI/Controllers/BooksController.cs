using System.Linq;
using System.Threading.Tasks;
using LibraryService.WebAPI.Data;
using LibraryService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = (await _booksService.Get(new[] { id }, null)).FirstOrDefault();
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll([FromQuery] Filters filters)
        {
            var books = await _booksService.Get(null, filters);

            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Book book)
        {
            await _booksService.Add(book);
            return Ok(book);
        }
    }
}
