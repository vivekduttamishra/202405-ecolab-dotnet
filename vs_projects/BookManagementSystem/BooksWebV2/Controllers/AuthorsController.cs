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

        public async Task<ActionResult> Delete(string id)
        {
            await authorService.DeleteAuthor(id);
            //return View();
            return RedirectToAction("Index");
        }

        public async Task<string> Details(string id, string details)
        {
            var author = await authorService.GetAuthorById(id);
            return $"{details} of {author.Name}";
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(Author author)
        {

            await authorService.AddAuthor(author);

            //return View("info",author);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Save(Author author)
        {
            
            await authorService.AddAuthor(author);

            return View("info",author);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Save1(string id, string name, string biography, string photograph)
        {
            var author = new Author()
            {
                Id = id,
                Name = name,
                Biography = biography,
                Photograph =photograph
            };
            await authorService.AddAuthor(author);

            //return View("info",author);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Save0()
        {
            var author = new Author()
            {
                Id = Request.Form["Id"],
                Name = Request.Form["Name"],
                Biography = Request.Form["Biography"],
                Photograph = Request.Form["Photograph"]
            };
            await authorService.AddAuthor(author);

            //return View("info",author);
            return RedirectToAction("Index");
        }
    }
}
