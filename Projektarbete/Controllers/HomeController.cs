using Microsoft.AspNetCore.Mvc;

namespace Projektarbete.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
