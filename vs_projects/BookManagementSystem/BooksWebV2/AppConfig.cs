using ConceptArchitect.BookManagement;
using ConceptArchitect.BookManagement.SqlRepository;
using ConceptArchitect.Utils;
using ConceptArchitect.Utils.Data;

namespace BooksWebV2
{
    public static class AppConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {

            services.AddControllersWithViews();

            //services.DevelopementTimeServices();

            services.AddTransient<IAuthorService,PersistentAuthorService>();
            services.AddTransient<IRepository<Author, string>, SqlAuthorRepository>();
            services.AddTransient<DbManager>(s =>
            {
                var config = s.GetService<IConfiguration>();
                var connectionFactory = new DefaultConnectionFactory(config, "booksdb");
                return new DbManager(connectionFactory.Factory);
            });
           
            services.AddTransient<IAuthorDataSeeder, DummyAuthorDataSeeder>();


        }

        private static void DevelopementTimeServices(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorService, InMemoryAuthorService>();
            services.AddTransient<IAuthorDataSeeder, DummyAuthorDataSeeder>();
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
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.MapPost("/admin/seed/authors", async context =>
            {
                var seeder = context.RequestServices.GetService<IAuthorDataSeeder>();
                await seeder.SeedData();
                await context.Response.WriteAsync("Seeded Authors");
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Authors}/{Action=Index}/{id?}");
        }
    }
}
