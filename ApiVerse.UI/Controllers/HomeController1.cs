using Microsoft.AspNetCore.Mvc;

namespace ApiVerse.UI.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
