using Library.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using System.Collections.Generic;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("sorted-by-publisher")]
        public async Task<IActionResult> GetBooksSortedByPublisher()
        {
            var books = await _context.Books
                .OrderBy(b => b.Publisher)
                .ThenBy(b => b.AuthorLastName)
                .ThenBy(b => b.AuthorFirstName)
                .ThenBy(b => b.Title)
                .ToListAsync();

            return Ok(books);
        }

        [HttpGet("sorted-by-author")]
        public async Task<IActionResult> GetBooksSortedByAuthor()
        {
            var books = await _context.Books
                .OrderBy(b => b.AuthorLastName)
                .ThenBy(b => b.AuthorFirstName)
                .ThenBy(b => b.Publisher)
                .ThenBy(b => b.Title)
                .ToListAsync();

            return Ok(books);
        }

        [HttpGet("total-price")]
        public async Task<IActionResult> GetTotalPrice()
        {
            var totalPrice = await _context.Books.SumAsync(b => b.Price);
            return Ok(totalPrice);
        }

        [HttpPost("bulk-insert")]
        public async Task<IActionResult> BulkInsert([FromBody] List<Book> books)
        {
            await _context.Books.AddRangeAsync(books);
            await _context.SaveChangesAsync();
            return Ok("Books inserted successfully");
        }

        [HttpGet("sorted-by-publisher-sp")]
        public async Task<IActionResult> GetBooksSortedByPublisherSp()
        {
            var books = await _context.Books.FromSqlRaw("EXEC GetBooksSortedByPublisher").ToListAsync();
            return Ok(books);
        }

        [HttpGet("sorted-by-author-sp")]
        public async Task<IActionResult> GetBooksSortedByAuthorSp()
        {
            var books = await _context.Books.FromSqlRaw("EXEC GetBooksSortedByAuthor").ToListAsync();
            return Ok(books);
        }
    }
}
