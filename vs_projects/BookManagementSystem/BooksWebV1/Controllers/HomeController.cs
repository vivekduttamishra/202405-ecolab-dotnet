using Microsoft.AspNetCore.Mvc;

namespace BooksWebV1.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }
    }
}
