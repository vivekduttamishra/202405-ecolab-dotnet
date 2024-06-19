using ConceptArchitect.BookManagement;
using ConceptArchitect.BookManagement.EFRepository;
using ConceptArchitect.BookManagement.SqlRepository;
using ConceptArchitect.Web;
using ConceptArchitect.Utils;
using ConceptArchitect.Utils.Data;
using Microsoft.EntityFrameworkCore;
using ConceptArchitect.BookManagement.Services;
using ConceptArchitect.BookManagement.InMemoryServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using BooksWebV2.Services;

//dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
//dotnet add package Microsoft.IdentityModel.Tokens
//dotnet add package System.IdentityModel.Tokens.Jwt


namespace BooksWebV2
{
    public static class AppConfig
    {
        public static void ConfigureServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddControllersWithViews();

            //services.DevelopementTimeServices();




            //services.AddSqlAuthorRepository();


            services.AddTransient<IAuthorService, PersistentAuthorService>();
            services.AddTransient<IBookService, PersistentBookService>();
            services.AddTransient<IUserService, PersistentUserService>();
            services.AddTransient<IDataSeeder, BookDataSeeder>();
            
            services.AddEFRepository();

            
            

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var jwtSettings = configuration.GetSection("Jwt");
                var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero
                };
            });
            
            services.AddAuthorization();



            services.AddTransient<ITokenService, TokenService>();


        }

        private static void AddEFRepository(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Author, string>, EFAuthorRepository>();
            services.AddTransient<IRepository<Book, string>, EFBookRepository>();
            services.AddTransient<IRepository<User, string>, EFUserRepository>();
            services.AddDbContext<BooksContext>((services, options) =>
            {
                var config = services.GetService<IConfiguration>();
                var connectionString = config["ConnectionStrings:books_ef"];
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();
                options.UseLazyLoadingProxies();
                
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
            services.AddTransient<IDataSeeder, BookDataSeeder>();
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

            

            app.MapPost("/admin/seed/authors", async context =>
            {
                var seeder = context.RequestServices.GetService<IDataSeeder>();
                await seeder.SeedData();
                await context.Response.WriteAsync("Seeded Authors");
            });


            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });

            app.UseRouting(); //use Api Routing

            app.UseAuthentication();
            app.UseAuthorization();



            app.Use(next =>
            {
                return async context =>
                {
                    try
                    {
                        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                        var tokenService = context.RequestServices.GetService<ITokenService>();

                        if (token != null)
                        {
                            context.User = tokenService.Decode(token);
                            var name= context.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
                            var email = context.User.FindFirst(JwtRegisteredClaimNames.Email)?.Value;
                            //var roles = context.User.Claims.Where(c => c.Type == "role").Select(c => c.Value).ToList();
                            await Console.Out.WriteLineAsync($"User:{name},{email}");
                        }
                        else
                        {
                            Console.WriteLine($"No User Login Info found");
                        }

                    }
                    catch (Exception ex)
                    {
                        await Console.Out.WriteLineAsync("Token decode failed");
                    }

                    await next(context);
                };
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Authors}/{Action=Index}/{id?}");
        }
    }
}




