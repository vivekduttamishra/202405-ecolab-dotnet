using HelloWeb.Services;
using System.Net.Security;

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
            MiddlewareSet04(app);
            

            //Step 5. Start the App
            app.Run();
        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            //builder.Services.AddSingleton<SimpleGreetService>();

            //when user asks for IGreetService, please provide SimpleGreetService
            builder.Services.AddSingleton<IGreetService, SimpleGreetService>();
        
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
