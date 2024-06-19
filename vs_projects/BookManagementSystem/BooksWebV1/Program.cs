
namespace BooksWebV1
{
    public class Program
    { 
        static void Main(string[]args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.ConfigureServices();

            var app = builder.Build();
            
            app.ConfigureEnvironment(app.Services.GetService<IWebHostEnvironment>());
            app.ConfigureMiddlewares();


            app.Run();
        }
    }

}

