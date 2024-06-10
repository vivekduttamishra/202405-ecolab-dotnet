using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebV2.Controllers
{
    public class AdminController
    {
        IDataSeeder seeder;
        IAuthorService authorService;
        public AdminController(IDataSeeder seeder, IAuthorService authorService)
        {
            this.seeder = seeder;
            this.authorService = authorService;

        }

        [HttpPost]
        public async Task<IList<Author>> SeedAuthors()
        {
            await seeder.SeedData();
            return await authorService.GetAuthors();
        }
    }
}
