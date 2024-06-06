using ConceptArchitect.BookManagement;

namespace BooksWebV2
{
    public static class AppConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            
            services.AddControllersWithViews();
            services.AddSingleton<IAuthorService,InMemoryAuthorService>();
            services.AddTransient<IAuthorDataSeeder, DummyAuthorDataSeeder>();

        }

        public static void ConfigureEnvironment(this WebApplication app, IWebHostEnvironment environment) 
        {
            if(environment.IsDevelopment())
            {
                IAuthorDataSeeder seeder = app.Services.GetService<IAuthorDataSeeder>();
                seeder.SeedData().Wait();
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
