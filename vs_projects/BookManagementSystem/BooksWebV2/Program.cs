namespace BooksWebV2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.ConfigureServices();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.ConfigureEnvironment(app.Services.GetService<IWebHostEnvironment>());
            app.ConfigureMiddlewares();

            app.Run();
        }
    }
}
