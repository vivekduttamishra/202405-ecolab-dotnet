using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebV2.Controllers
{
    public class AuthorsController : Controller
    {
        IAuthorService authorService;
        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        public async Task<ViewResult> Index()
        {
            var authors = await authorService.GetAuthors();
            return View(authors);
        }

        public async Task<ViewResult> Info(string id)
        {
            var author = await authorService.GetAuthorById(id);
            return View(author);
        }

        public async Task<string> Details(string id, string details)
        {
            var author = await authorService.GetAuthorById(id);
            return $"{details} of {author.Name}";
        }
    }
}
