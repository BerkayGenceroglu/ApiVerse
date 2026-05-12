using Microsoft.AspNetCore.Mvc;

namespace ApiVerse.UI.Controllers
{
    public class ApiVerseLayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
