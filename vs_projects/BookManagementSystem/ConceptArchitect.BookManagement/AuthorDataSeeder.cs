using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{

    public interface IDataSeeder
    {
        Task SeedData();
    }


    public class DummyAuthorDataSeeder : IDataSeeder
    {

        IAuthorService authorService;

        public DummyAuthorDataSeeder(IAuthorService service)
        {
            this.authorService = service;
        }
        public async Task SeedData()
        {
            await authorService.AddAuthor(new Author { Id = "vivek", Name = "Vivek Dutta Mishra", Biography = "The Author of The Lost Epic Series", Photograph= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCFlHW7IBctOZc9PQG0fojV04Rzt4iHzxE8A&s" });
            await authorService.AddAuthor(new Author { Id = "dinkar", Name = "Ramdhari Singh Dinkar", Biography = "The National Poet of India",Photograph= "https://pbs.twimg.com/profile_images/1269658848777785345/2bY35KV0_400x400.jpg" });
            await authorService.AddAuthor(new Author { Id = "gandhi", Name = "Mahatma Gandhi", Biography = "Father of the Nation, Freedom fighter, Social reformer", Photograph = "https://pbs.twimg.com/profile_images/185517358/mahatmagandhi_400x400.jpg" });
            await authorService.AddAuthor(new Author { Id = "archer", Name = "Jeffrey Archer", Biography = "Contemporary Bestseller Brithish author", Photograph = "https://pbs.twimg.com/profile_images/3751745623/11bd5e198e1f0f7de40ffdf08f556293_400x400.jpeg" });
            await authorService.AddAuthor(new Author { Id = "grisham", Name = "John Grisham", Biography = "Leading Author of legal fiction", Photograph = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQthaeZGsdX1MTIqZTSqsTZrHoDBI35vPrssg&s" });
        }
    }

  
}
