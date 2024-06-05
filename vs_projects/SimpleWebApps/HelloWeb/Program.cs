using HelloWeb.Services;
using HelloWeb.Utils;
using System.Net.Security;
using System.Text;
using System.Text.Json;
using MatchType = HelloWeb.Utils.MatchType;

namespace HelloWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Step #1 Create AppBuilder
            var builder = WebApplication.CreateBuilder(args);

            //Step #2. Add your Services here
            AddServices(builder);

            //Step #3. Create the App
            var app = builder.Build();

            //Step #4 Configure the Middlewares
            MiddlewareSet05(app);
            

            var hosting = app.Services.GetService<IWebHostEnvironment>();
            var logger = app.Services.GetService<ILogger<Program>>();

            logger.LogInformation($"My Hosting Enviornment is :{hosting.EnvironmentName}");

            //Step 5. Start the App
            app.Run();
        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            //builder.Services.AddSingleton<SimpleGreetService>();

            //when user asks for IGreetService, please provide SimpleGreetService
            
            //builder.Services.AddSingleton<IGreetService, SimpleGreetService>();


            builder.Services.AddSingleton<IStatsService,InMemoryStatsService>();

            //builder.Services.AddSingleton<IAuthorService,InMemoryAuthorService>();
            //builder.Services.AddTransient<IAuthorDataSeeder,DummyAuthorDataSeeder>();

            builder.Services.AddAuthorService();

            
            builder.Services.AddTransient<IGreetService,SimpleGreetService>();
            //The last one is the one that will be used by default.
            builder.Services.AddTransient<IGreetService, TimedGreetingService>();
            builder.Services.AddTransient<TimeName>();

            builder.Services.AddTransient<IGreetService, ConfigurableGreetService>();

            builder.Services.AddTransient<IGreetService, AdvancedConfigurableGreetService>();
        }

        private static void MiddlewareSet05(WebApplication app)
        {

            var hosting = app.Services.GetService<IWebHostEnvironment>();
            
            var authorSeeder = app.Services.GetService<IAuthorDataSeeder>();
            authorSeeder.SeedData().Wait(); //can't await in non-async function

            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            app.UseFileServer();

            if(!hosting.IsProduction())
            {
                //Call data seeder here.            
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionConcealer();
            }

            app.UseExceptionMapper<InvalidOperationException>(401,null,
                                        new ExceptionResponseOptions { IncludeExceptionDetailsInResponse = true });


            app.UseExceptionMapper<EntityNotFoundException>(404);


            if(hosting.EnvironmentName=="HarryPotter")
                app.UseOnUrl("/9-3/4", context => "Welcome To the Train to Hogwards");

            app
               .UseOnUrl("/error", context=> throw new ArgumentException("Some invalid error occured"))
               .UseOnUrl("/secured", context=>throw new InvalidOperationException("User Not Authenticated"))
               .UseOnUrl("/stats", async context =>
               {
                   var service = context.RequestServices.GetService<IStatsService>();
                   var stats = await service.GetStats();
                   var html = new StringBuilder();
                   html.Append($"<html><head><title>Visit Stats</title></head>");
                   html.Append($"<body><h1>Visit Stats</h1>" +
                           $"<table style='width:80%'>" +
                           $"<thead><tr><th style='width=80%'>Uri</th><th>Visits</th></thead>" +
                           $"<tbody>");

                   foreach(var item in stats)
                   {
                       html.Append($"<tr><td>{item.Key}</td><td>{item.Value}</td></tr>");
                   }

                   html.Append($"</tbody></table></body></html>");
                   return html;
                   
               })
               .UseBefore(async context =>
               {
                   var path = context.Request.Path.ToString();
                   var service = app.Services.GetService<IStatsService>();
                   await service.AddUrl(path);
               })
               .UseAuthorEndPoints()
               //.UseOnUrl("/authors", async context =>
               //{
               //    var service = context.RequestServices.GetRequiredService<IAuthorService>();
               //    var authors= await service.GetAllAuthors();
               //    return authors; //will be display as JSON
               //})
               //.UseOnUrl("/author", async context =>
               //{
               //    var pathFragments= context.Request.Path.ToString().ToLower().Split('/');
               //    if (pathFragments.Length > 2)
               //    {
               //        string id = pathFragments[pathFragments.Length - 1];

               //        var service = context.RequestServices.GetService<IAuthorService>();
               //        var author = await service.GetAuthor(id);

               //        if (author != null)
               //            return author;
               //        else
               //        {
               //            context.Response.StatusCode = 404;
               //            return new { Error = "Not Found", id = id };
               //        }

               //    }
               //    else
               //    {
               //        context.Response.StatusCode = 400;
               //        return new { Error = "Missing Id" };
               //    }


               //},matcher:MatchType.StartsWith)
               .UseOnUrl("/greeter", context =>
               {
                   var service = context.RequestServices.GetService<IGreetService>();
                   var name = context.Request.Query["name"].ToString();
                   if (string.IsNullOrEmpty(name))
                   {
                       name = "John Doe";
                   }
                   return service.Greet(name);
               })
               .UseOnUrl("/greet", context =>
                {
                    var service=app.Services.GetService<IGreetService>();
                    var name = "World";
                    var pathParts= context.Request.Path.ToString().Split('/');
                    if(pathParts.Length > 2 ) {
                        name = pathParts[pathParts.Length-1];
                    }
                    return service.Greet(name);
                }, matcher: MatchType.StartsWith)
               
               .UseOnUrl("/time", _ => DateTime.Now.ToLongTimeString())
               .UseOnUrl("/date",context=> DateTime.Now.ToLongDateString())
               .UseOnUrl("/", context => "Welcome to our Book's Server");
        }

        private static void MiddlewareSet04(WebApplication app)
        {

            

            app.Use(next =>
            {
                return async context =>
                {
                    if (context.Request.Path.StartsWithSegments("/greet"))
                    {
                        //var service = new SimpleGreetService();

                        //var service = app.Services.GetService<SimpleGreetService>();

                        var service = app.Services.GetService<IGreetService>();

                        var parts = context.Request.Path.ToString().Split('/');

                        string name = "World";

                        if (parts.Length > 2)
                            name = parts[parts.Length - 1];


                        var message = service.Greet(name.ToUpper());
                        await context.Response.WriteAsync(message);
                    }
                    else
                        await next(context);
                };
            });


            app.Use(next =>
            {
                return async context =>
                {
                    if (context.Request.Path == "/greeter2")
                    {
                        //var service = new SimpleGreetService();

                        //var service = context.RequestServices.GetService<SimpleGreetService>();

                        var service = context.RequestServices.GetService<IGreetService>();

                        var name = context.Request.Query["name"];
                        if (string.IsNullOrEmpty(name))
                            name = "World";
                        var message = service.Greet(name);
                        await context.Response.WriteAsync(message);
                    }
                    else
                        await next(context);
                };
            });


            app.Use(next =>
            {
                return async context =>
                {
                    if (context.Request.Path == "/greeter")
                    {
                        var service = new SimpleGreetService();

                        //var service = context.RequestServices.GetService<SimpleGreetService>();

                        var name = context.Request.Query["name"];
                        if (string.IsNullOrEmpty(name))
                            name = "World";
                        var message = service.Greet(name);
                        await context.Response.WriteAsync(message);
                    }
                    else
                        await next(context);
                };
            });


            app.Use(next =>
            {
                //Console.WriteLine("Date Middleware Created...");
                //actual middleware begins Here
                return async context =>
                {
                    if (context.Request.Path.ToString() == "/date")
                    {
                        //Console.WriteLine($"Date Middleware handled request: {context.Request.Path}");
                        await context.Response.WriteAsync(DateTime.Now.ToLongDateString());
                    }
                    else
                    {
                        //Console.WriteLine($"Date Middlware passed request:{context.Request.Path}");
                        await next(context); //call next middlware
                    }
                };
            });

            app.Use(next =>
            {
                //Console.WriteLine("Time Middleware Created...");
                //actual middleware begins Here
                return async context =>
                {
                    if (context.Request.Path.ToString() == "/time")
                    {
                        //Console.WriteLine($"Time Middleware handled request: {context.Request.Path}");
                        await context.Response.WriteAsync(DateTime.Now.ToLongTimeString());
                    }
                    else
                    {
                        //Console.WriteLine($"Time Middlware passed request:{context.Request.Path}");
                        await next(context); //call next middlware
                    }
                };
            });


            app.Use(next =>
            {
                return async context =>
                {
                    if (context.Request.Path.ToString() == "/")
                        await context.Response.WriteAsync("Welcome to Our Server");
                    else
                        await next(context);
                };
            });

            //Error 404
        }

        private static void MiddlewareSet03(WebApplication app)
        {

            app.Use(next =>
            {
                return async context =>
                {
                    if (context.Request.Path.StartsWithSegments("/greet"))
                    {
                        var parts = context.Request.Path.ToString().Split('/');

                        string name = "World";
                        
                        if (parts.Length > 2)
                            name = parts[parts.Length - 1];
                        
                        var service = new SimpleGreetService();
                        
                        var message = service.Greet(name.ToUpper());
                        await context.Response.WriteAsync(message);
                    }
                    else
                        await next(context);
                };
            });



            app.Use(next =>
            {
                return async context =>
                {
                    if (context.Request.Path == "/greeter")
                    {
                        var service = new SimpleGreetService();
                        var name = context.Request.Query["name"] ;
                        if (string.IsNullOrEmpty(name))
                            name = "World";
                        var message = service.Greet(name);
                        await context.Response.WriteAsync(message);
                    }
                    else
                        await next(context);
                };
            });


            app.Use(next =>
            {
                Console.WriteLine("Date Middleware Created...");
                //actual middleware begins Here
                return async context =>
                {
                    if (context.Request.Path.ToString() == "/date")
                    {
                        Console.WriteLine($"Date Middleware handled request: {context.Request.Path}");
                        await context.Response.WriteAsync(DateTime.Now.ToLongDateString());
                    }
                    else
                    {
                        Console.WriteLine($"Date Middlware passed request:{context.Request.Path}");
                        await next(context); //call next middlware
                    }
                };
            });

            app.Use(next =>
            {
                Console.WriteLine("Time Middleware Created...");
                //actual middleware begins Here
                return async context =>
                {
                    if (context.Request.Path.ToString() == "/time")
                    {
                        Console.WriteLine($"Time Middleware handled request: {context.Request.Path}");
                        await context.Response.WriteAsync(DateTime.Now.ToLongTimeString());
                    }
                    else
                    {
                        Console.WriteLine($"Time Middlware passed request:{context.Request.Path}");
                        await next(context); //call next middlware
                    }
                };
            });


            app.Run(context =>
            {
                Console.WriteLine($"Default Middleware handled request: {context.Request.Path}");
                return context.Response.WriteAsync("Welcome to Book's Server");

            });
        }

        private static void MiddlewareSet02(WebApplication app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync(DateTime.Now.ToString());
            });

            app.Run(context =>
            {
                return context.Response.WriteAsync("Welcome to Book's Server");

            });
        }

        private static void MiddlewareSet01(WebApplication app)
        {
            app.Run(context =>
            {
                var path = context.Request.Path.ToString().ToLower();
                if (path == "/")
                    return context.Response.WriteAsync($"Welcome to Book Server");
                else if (path == "/authors")
                    return context.Response.WriteAsync($"List of All Authors");
                else if (path == "/books")
                    return context.Response.WriteAsync($"List of Books");
                else
                {
                    context.Response.StatusCode = 404; //Not Found
                    return context.Response.WriteAsync($"Not Found:{path}");
                }
            });
        }
    }
}
