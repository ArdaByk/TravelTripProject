using Microsoft.AspNetCore.Mvc;
using TravelTripProject.Models.Siniflar;
namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
    }
}
