using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SwapiController : Controller
    {
        public IActionResult Swapi()
        {
            return View();
        }
    }
}
