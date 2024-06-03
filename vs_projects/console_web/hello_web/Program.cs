var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run( context=> context.Response.WriteAsync("Hello World" ) );

app.Run();
