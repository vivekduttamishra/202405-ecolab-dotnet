using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebV2.ApiControllers
{

    [ApiController]
    [Route("/api/authors")]
    public class AuthorsController : Controller
    {
        IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]  // /api/authors
        public async Task<IList<Author>> GetAllAuthors()
        {
            return await _authorService.GetAuthors();
        }

        [HttpGet("{id}")]  // /api/authors/{id}
        public async Task<Author> GetAuthorById(string id)
        {
            var author= await _authorService.GetAuthorById(id);
            return author;
        }

        [HttpPost] // /api/authors
        public async Task<IActionResult> AddAuthor(Author author)
        {
           var result =await _authorService.AddAuthor(author);
            return Ok(result); //Ok means status 200
        }

        [HttpPut("{id}")]
        public async Task<Author> UpdateAuthor(string id, Author author)
        {
            return await _authorService.UpdateAuthor(author);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAuthor(string id)
        {
            await _authorService.DeleteAuthor(id);
        }
    }
}
