using Microsoft.AspNetCore.Http;

namespace ConceptArchitect.Web
{
    public enum MatchType { Exact, StartsWith, Contains }
    public static class WebApplicationExtensions
    {
        public static WebApplication UseOnUrl(this WebApplication app,
                                    string uri,
                                    Func<HttpContext, Task<object>> handler,
                                    MatchType matcher = MatchType.Exact)
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
                                            Func<HttpContext, object> syncHandler, MatchType matcher = MatchType.Exact)
        {
            return app.UseOnUrl(uri, async context =>
            {
                //var result = Task.Factory.StartNew(() => syncHandler(context));
                await Task.CompletedTask;
                return syncHandler(context);
            }, matcher);
        }


        public static WebApplication UseBefore(this WebApplication app, Func<HttpContext, Task> action)
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


        public static WebApplication UseAfter(this WebApplication app, Func<HttpContext, Task> afterAction = null,
                                                                       Func<Exception, HttpContext, Task> exceptionHandler = null)
        {
            app.Use(next =>
            {
                return async context =>
                {
                    try
                    {
                        await next(context);  //first let other works
                        if (afterAction != null)
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





        public static WebApplication UseExceptionMapper<T>(this WebApplication app, int statusCode = 500,  Action<ExceptionResponseOptions> optionBuilder = null) where T : Exception
        {
            

            return app.UseAfter(exceptionHandler: async (ex, context) =>
            {
                var options = new ExceptionResponseOptions()
                {
                    ErrorMessage = $"Status Code: {context.Response.StatusCode}",
                    IncludeExceptionDetailsInResponse = false,
                    ResponseBuilder = ExceptionResponseTypes.Json,
                    Details = "Some Error Occured",
                    Title = "The problem has been reported",
                    Method = context.Request.Method,
                    Path = context.Request.Path,
                    Status=context.Response.StatusCode
                };
                if(optionBuilder != null)
                    optionBuilder(options);

                if (!(ex is T))
                    throw ex; //I can't handle this exception, so I must throw it back for others.


                if (options.IncludeExceptionDetailsInResponse)
                    options.Details = $"Details: {ex.Message}";

                context.Response.StatusCode = statusCode;
                await options.ResponseBuilder(context, options);

                

                

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



        public static WebApplication UseExceptionConcealer(this WebApplication app, Action<ExceptionResponseOptions> optionBuilder = null)
        {


            return app.UseExceptionMapper<Exception>(500, optionBuilder);
        }

    }

    public static class ExceptionResponseTypes
    {
        public static async Task Html(HttpContext context, ExceptionResponseOptions option)
        {
            await context.Response.WriteAsync(
                                              $"<html><head><title>{option.Title}</title></head>" +
                                              $"<body><h1>{option.Title}</h1>" +
                                              $"<ul>" +
                                              $"<li>Request:{option.Method} {option.Path}</li>" +
                                              $"<li>Error:{option.Status}</li>" +
                                              $"<ul>" +
                                              $"<p>{option.Details}</p>" +
                                              $"</body></html>");
        }

        public static async Task Json(HttpContext context, ExceptionResponseOptions option)
        {
            await context.Response.WriteAsJsonAsync(new
            {
                RequestMethod=option.Method,
                RequestUri=option.Path,
                Title=option.Title,
                StatusCode=option.Status,
                Details=option.Details
            });
        }
    }

    public class ExceptionResponseOptions
    {
        public string ErrorMessage { get; set; } = "Some Error Occured";
        public bool IncludeExceptionDetailsInResponse { get; set; } = false;
        public string Details { get; internal set; }
        public string Title { get; internal set; }
        public string Method { get; internal set; }
        public PathString Path { get; internal set; }
        public int Status { get; internal set; }
        public Func<HttpContext, ExceptionResponseOptions, Task> ResponseBuilder { get; internal set; }
    }
}
