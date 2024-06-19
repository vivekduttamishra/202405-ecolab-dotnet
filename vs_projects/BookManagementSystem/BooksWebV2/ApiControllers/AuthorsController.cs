using BooksWebV2.Utils;
using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebV2.ApiControllers
{

    [ApiController]
    [Route("/api/authors")]
    [ExceptionMapper(typeof(InvalidEntityException),404,ShowExceptionDetails = true)]
    public class AuthorsController : Controller
    {
        IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]  // /api/authors
        [Authorize]
        public async Task<IList<Author>> GetAllAuthors()
        {
            return await _authorService.GetAuthors();
        }

        [HttpPost] // /api/authors
        [ExceptionMapper(typeof(DuplicateIdException), 400, ShowExceptionDetails = true)]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            var result = await _authorService.AddAuthor(author);
            return Created(Url.Link("author_route", new { Id = author.Id }), author);
        }



        [HttpGet("{id}",Name ="author_route")]  // /api/authors/{id}
        public async Task<IActionResult> GetAuthorById(string id)
        {
            var author = await _authorService.GetAuthorById(id);
            return Ok(author);
        }


        [HttpGet("{id}/v2")]  // /api/authors/{id}
        public async Task<IActionResult> GetAuthorByIdV2(string id)
        {
            try
            {
                var author = await _authorService.GetAuthorById(id);
                return Ok(author); //200
            }
            catch(InvalidEntityException ex)
            {
                return NotFound(new {Error=404, Message=$"Invalid Author Id", Id=id}); //404
            }
        }


        [HttpGet("{id}/v1")]  // /api/authors/{id}
        public async Task<Author> GetAuthorByIdV1(string id)
        {
            var author = await _authorService.GetAuthorById(id);
            return author;
        }

       

        [HttpPut("{id}")]
        public async Task<Author> UpdateAuthor(string id, Author author)
        {
            return await _authorService.UpdateAuthor(author);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(string id)
        {
            await _authorService.DeleteAuthor(id);
            return NoContent();
        }
    }
}
