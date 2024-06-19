using Microsoft.AspNetCore.Mvc;

namespace BooksWebV1.Controllers
{

    //can handle all urls like :   /Info/...
    public class InfoController : Controller
    {
       
        //default method. can be called using : /info
        public ViewResult Index()
        {
            return View();
        }


        //  /info/welcome
        public string Welcome()
        {
            return "Welcome to Book's Web";
        }




        public ContentResult Index2()
        {
            //Response.ContentType = "text/html";
            return Content (
                    $"<html><head><title>Welcome to MVC</title></head>" +
                    $"<body><h1>Welcome to MVC</h1></body>" +
                    $"</html>", "text/html"
                );
        }
    }
}
