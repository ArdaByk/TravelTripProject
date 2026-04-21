using Microsoft.AspNetCore.Mvc;

namespace TravelTripProject.Controllers
{
    public class GirisYapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}
