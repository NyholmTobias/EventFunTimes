using Microsoft.AspNetCore.Mvc;

namespace EventFunTimesUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
