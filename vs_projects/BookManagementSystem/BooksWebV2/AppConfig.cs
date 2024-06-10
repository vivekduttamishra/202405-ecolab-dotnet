using ConceptArchitect.BookManagement;
using ConceptArchitect.BookManagement.EFRepository;
using ConceptArchitect.BookManagement.SqlRepository;
using ConceptArchitect.Web;
using ConceptArchitect.Utils;
using ConceptArchitect.Utils.Data;
using Microsoft.EntityFrameworkCore;

namespace BooksWebV2
{
    public static class AppConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {

            services.AddControllersWithViews();

            //services.DevelopementTimeServices();

            services.AddTransient<IAuthorService, PersistentAuthorService>();
            services.AddTransient<IDataSeeder, DummyAuthorDataSeeder>();


            //services.AddSqlAuthorRepository();

            services.AddTransient<IRepository<Author, string>, EFAuthorRepository>();

            

            services.AddDbContext<BooksContext>((services, options) =>
            {
                var config = services.GetService<IConfiguration>();
                var connectionString = config["ConnectionStrings:books_ef"];
                options.UseSqlServer(connectionString);
            });


        }

        private static void AddSqlAuthorRepository(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Author, string>, SqlAuthorRepository>();
            services.AddTransient<DbManager>(s =>
            {
                var config = s.GetService<IConfiguration>();
                var connectionFactory = new DefaultConnectionFactory(config, "booksdb");
                return new DbManager(connectionFactory.Factory);
            });
        }

        private static void DevelopementTimeServices(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorService, InMemoryAuthorService>();
            services.AddTransient<IDataSeeder, DummyAuthorDataSeeder>();
        }

        public static void ConfigureEnvironment(this WebApplication app, IWebHostEnvironment environment) 
        {
            if(environment.IsDevelopment())
            {
                //IAuthorDataSeeder seeder = app.Services.GetService<IAuthorDataSeeder>();
                //seeder.SeedData().Wait();
            }
        }
        public static void ConfigureMiddlewares(this WebApplication app)
        {
            


            //app.UseExceptionMapper<InvalidEntityException>(404, opt =>
            //{
            //    opt.IncludeExceptionDetailsInResponse = true;
            //    //opt.ResponseBuilder = ExceptionResponseTypes.Html;
            //});

            app.UseStaticFiles();

            app.UseRouting();

            app.MapPost("/admin/seed/authors", async context =>
            {
                var seeder = context.RequestServices.GetService<IDataSeeder>();
                await seeder.SeedData();
                await context.Response.WriteAsync("Seeded Authors");
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Authors}/{Action=Index}/{id?}");
        }
    }
}
