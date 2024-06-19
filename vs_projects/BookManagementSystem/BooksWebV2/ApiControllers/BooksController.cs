using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace BooksWebV2.ApiControllers
{
    [ApiController]
    [Route("/api/books")]
    public class BooksController:Controller
    {
        IBookService _bookService;
        IAuthorService _authorService;
        ILogger<BooksController> _logger;
        public BooksController(IBookService bookService, 
                                IAuthorService authorService,
                                ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _authorService = authorService;
            _logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books=await _bookService.GetAllBooks();
            _logger.LogInformation($"Returning {books.Count} books");
            return Ok(books);
        }

    }
}
