using ConceptArchitect.BookManagement;
using ConceptArchitect.BookManagement.InMemoryServices;

namespace BooksWebV1
{
    public static class AppConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddMvc(options=>
            {
                options.EnableEndpointRouting = false;
            });

            services.AddSingleton<IAuthorService,InMemoryAuthorService>();
            services.AddTransient<IDataSeeder, BookDataSeeder>();

        }

        public static void ConfigureEnvironment(this WebApplication app, IWebHostEnvironment environment) 
        {
            if(environment.IsDevelopment())
            {
                IDataSeeder seeder = app.Services.GetService<IDataSeeder>();
                seeder.SeedData().Wait();
            }
        }
        public static void ConfigureMiddlewares(this WebApplication app)
        {
            app.UseFileServer();

            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute("Details", "{controller=Home}/{action=Index}/{id?}/{details?}");
            });
        }
    }
}
