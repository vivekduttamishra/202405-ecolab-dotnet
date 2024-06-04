using HelloWeb.Utils;
using MatchType = HelloWeb.Utils.MatchType;

namespace HelloWeb.Services
{

    public class Author
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
    }


    public interface IAuthorService
    {
        Task<Author> AddAuthor(Author author);
        Task<IList<Author>> GetAllAuthors();
        Task<Author> GetAuthor(string id);
    }

    public class InMemoryAuthorService : IAuthorService
    {
        Dictionary<string, Author> authors = new Dictionary<string, Author>();

        public async Task<Author> AddAuthor(Author author)
        {
            var key = author.Id.ToLower();
            authors[key] = author;
            await Task.CompletedTask;
            return author;
        }

        public async Task<IList<Author>> GetAllAuthors()
        {
            await Task.CompletedTask;
            return authors.Values.ToList();
        }

        public async Task<Author> GetAuthor(string id)
        {
            await Task.CompletedTask;
            var key = id.ToLower();
            if (authors.ContainsKey(key))
                return authors[key];
            else
                return null;
        }
    }



    public interface IAuthorDataSeeder
    {
        Task SeedData();        
    }

    public class DummyAuthorDataSeeder: IAuthorDataSeeder
    {

        IAuthorService authorService;

        public DummyAuthorDataSeeder(IAuthorService service)
        {
            this.authorService = service;
        }
        public async Task SeedData()
        {
            await authorService.AddAuthor(new Author { Id = "vivek", Name = "Vivek Dutta Mishra", Biography = "The Author of The Lost Epic Series" });
            await authorService.AddAuthor(new Author { Id = "dinkar", Name = "Ramdhari Singh Dinkar", Biography = "The National Poet of India" });
            await authorService.AddAuthor(new Author { Id = "gandhi", Name = "Mahatma Gandhi", Biography = "Father of the Nation, Freedom fighter, Social reformer" });
            await authorService.AddAuthor(new Author { Id = "archer", Name = "Jeffrey Archer", Biography = "Contemporary Bestseller Brithish author" });
            await authorService.AddAuthor(new Author { Id = "grisham", Name = "John Grisham", Biography = "Leading Author of legal fiction" });
        }
    }


    public static class AuthorFeatures
    { 
        public static IServiceCollection AddAuthorService(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorService, InMemoryAuthorService>();
            services.AddTransient<IAuthorDataSeeder, DummyAuthorDataSeeder>();
            return services;
        }
    
        public static WebApplication UseAuthorEndPoints(this WebApplication app)
        {
            return app
                .UseOnUrl("/authors", async context =>
             {
                 var service = context.RequestServices.GetRequiredService<IAuthorService>();
                 var authors = await service.GetAllAuthors();
                 return authors; //will be display as JSON
             })
               .UseOnUrl("/author", async context =>
               {
                   var pathFragments = context.Request.Path.ToString().ToLower().Split('/');
                   if (pathFragments.Length > 2)
                   {
                       string id = pathFragments[pathFragments.Length - 1];

                       var service = context.RequestServices.GetService<IAuthorService>();
                       var author = await service.GetAuthor(id);

                       if (author != null)
                           return author;
                       else
                       {
                           context.Response.StatusCode = 404;
                           return new { Error = "Not Found", id = id };
                       }

                   }
                   else
                   {
                       context.Response.StatusCode = 400;
                       return new { Error = "Missing Id" };
                   }


               }, matcher: MatchType.StartsWith);
        }

    }


}
