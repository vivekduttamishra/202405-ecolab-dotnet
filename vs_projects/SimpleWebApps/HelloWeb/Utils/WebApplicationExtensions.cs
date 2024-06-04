namespace HelloWeb.Utils
{
    public enum MatchType { Exact,StartsWith,Contains}
    public static  class WebApplicationExtensions
    {
        public static WebApplication UseOnUrl(this WebApplication app, 
                                    string uri, 
                                    Func<HttpContext,Task<object>> handler,
                                    MatchType matcher=MatchType.Exact)
        {
            app.Use(next =>
            {
                return async context =>
                {
                    var path = context.Request.Path.ToString().ToLower();
                    uri = uri.ToLower();
                    var match = matcher == MatchType.Exact ? path == uri
                               : matcher == MatchType.Contains ? path.Contains(uri)
                               : path.StartsWith(uri);
                    if (match)
                    {
                        var result = await handler(context);
                        if (result is string || result is ValueType)
                            await context.Response.WriteAsync(result.ToString());
                        else
                            await context.Response.WriteAsJsonAsync(result);
                    }
                    else
                    {
                        await next(context);
                    }

                };
            });

            return app;
        }

        public static WebApplication UseOnUrl(this WebApplication app, string uri,
                                            Func<HttpContext,object> syncHandler, MatchType matcher=MatchType.Exact)
        {
            return app.UseOnUrl(uri,  async context =>
            {
                //var result = Task.Factory.StartNew(() => syncHandler(context));
                await Task.CompletedTask;
                return syncHandler(context);
            },matcher);
        }
    
        
        public static WebApplication UseBefore(this WebApplication app, Func<HttpContext,Task> action)
        {
            app.Use(next =>
            {
                return async context =>
                {
                    await action(context);
                    await next(context);
                };
            });

            return app;
        }
    
        public static WebApplication UseBefore(this WebApplication app, Action<HttpContext> action)
        {
            return app.UseBefore(async context =>
            {
                action(context);
                await Task.CompletedTask;
            });
        }
    
    }
}
