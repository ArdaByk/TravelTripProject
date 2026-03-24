using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TravelTripProject.Models;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Blogs.Take(10).ToList();
            return View(degerler);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public PartialViewResult Partial1()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial2()
        {
            var degerler = c.Blogs.Where(x => x.ID == 1).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial3()
        {
            var deger = c.Blogs.ToList();

            return PartialView(deger);
        }
        public PartialViewResult Partial4()
        {
            var deger = c.Blogs.Take(3).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial5()
        {
            var deger = c.Blogs.Take(3).OrderByDescending(x => x.ID).ToList();
            return PartialView(deger);
        }
    }
}
