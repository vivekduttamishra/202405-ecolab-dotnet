using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BooksWebV2.Utils
{
    public class ExceptionMapperAttribute: ExceptionFilterAttribute
    {
        Type exceptionType;
        int statusCode;
        public bool ShowExceptionDetails { get; set; } = false;
        public string Title { get; set; }
        public string Details { get; set; }


        public ExceptionMapperAttribute(Type exceptionType, int statusCode) 
        { 
            this.exceptionType = exceptionType;
            this.statusCode = statusCode;
        }

        public override void OnException(ExceptionContext context)
        {
            if(exceptionType.IsAssignableFrom(context.Exception.GetType())) //if current exception is type of this exception
            {
                context.HttpContext.Response.StatusCode = statusCode;
                
                context.Result = new JsonResult(new
                {
                    Title= Title ?? $"Status: {statusCode}",
                    Details=string.IsNullOrEmpty(Details) 
                                                ?ShowExceptionDetails? context.Exception.Message : $"Some Error Occured"
                                                : Details,
                    HttpMethod=context.HttpContext.Request.Method,
                    HttpStatusCode=context.HttpContext.Response.StatusCode,
                    Url=context.HttpContext.Request.GetDisplayUrl()
                });
            }
            base.OnException(context);
        }
    }
}
