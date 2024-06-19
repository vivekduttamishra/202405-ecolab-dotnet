using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebV2.Controllers
{
    public class AdminController:Controller
    {
        IDataSeeder seeder;
        IAuthorService authorService;
        public AdminController(IDataSeeder seeder, IAuthorService authorService)
        {
            this.seeder = seeder;
            this.authorService = authorService;

        }

        [HttpPost]
        public async Task<ActionResult> SeedData()
        {
            await seeder.SeedData();
            return RedirectToAction("Index", "Home");
        }
    }
}
