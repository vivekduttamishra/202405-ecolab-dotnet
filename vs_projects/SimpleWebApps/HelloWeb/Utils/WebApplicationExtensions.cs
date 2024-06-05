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
    

        public static WebApplication UseAfter(this WebApplication app, Func<HttpContext,Task> afterAction=null, 
                                                                       Func<Exception,HttpContext,Task> exceptionHandler=null)
        {
            app.Use(next =>
            {
                return async context =>
                {
                    try
                    {
                        await next(context);  //first let other works
                        if(afterAction!=null)
                            await afterAction(context); //now it is your turn
                    }
                    catch (Exception ex)
                    {
                        if (exceptionHandler != null)
                        {
                            await exceptionHandler(ex, context);
                            
                        }
                    }
                };
            });

            return app;
        }



     
        
        public static WebApplication UseExceptionMapper<T>(this WebApplication app, int statusCode=500, Func<T,HttpContext,Task> exceptionHandler=null, ExceptionResponseOptions options=null) where T : Exception
        {
            return app.UseAfter(exceptionHandler: async (ex, context) =>
            {
                if (!(ex is T))
                    throw ex; //I can't handle this exception, so I must throw it back for others.

                context.Response.StatusCode = statusCode;

                if(exceptionHandler!=null)
                {
                    await exceptionHandler((T)ex, context);
                    return;
                }

                //default exception mapper
                string title = $"Error: {statusCode}";
                string details = $"We are looking into the problem";

                if (options!=null)
                {
                    title = options.ErrorMessage;
                    if (options.IncludeExceptionDetailsInResponse)
                        details = $"Details: {ex.Message}";

                }

                await context.Response.WriteAsync(
                                              $"<html><head><title>{title}</title></head>" +
                                              $"<body><h1>{title}</h1>" +
                                              $"<ul>" +
                                              $"<li>Request:{context.Request.Method} {context.Request.Path}</li>" +
                                              $"<li>Error:{statusCode}</li>" +
                                              $"<ul>" +
                                              $"<p>{details}</p>" +
                                              $"</body></html>");

            });
        }



        //public static WebApplication UseExceptionConcealer(this WebApplication app, string message="Some Error Occured!") 
        //{

        //    app.Use(next =>
        //    {
        //        return async context =>
        //        {
        //            try
        //            {
        //                await next(context);
        //            }
        //            catch (Exception ex)
        //            {
        //                context.Response.StatusCode = 500;
        //                await context.Response.WriteAsync(
        //                                        $"<html><head><title>{message}</title></head>" +
        //                                       $"<body><h1>{message}</h1>" +
        //                                       $"<p>It shouldn't have happened. We have notified our Teasm" +
        //                                       $"and we are working on it to fix As soon as possible</p>" +
        //                                       $"</body></html>"
        //                               );
        //            }
        //        };
        //    });

        //    return app;
        //}



        public static WebApplication UseExceptionConcealer(this WebApplication app, ExceptionResponseOptions option=null)
        {
            

            return app.UseExceptionMapper<Exception>(500, null, option);
        }

    }

    public class ExceptionResponseOptions
    {
        public string ErrorMessage { get; set; } = "Some Error Occured";
        public bool IncludeExceptionDetailsInResponse { get; set; } = false;
    }
}
