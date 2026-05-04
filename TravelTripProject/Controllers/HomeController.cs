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
            ViewBag.Partial1 = c.Blogs.Where(x => x.BlogDurum == 1).OrderByDescending(x => x.ID).Take(2).ToList();
            ViewBag.Partial2 = c.Blogs.Where(x => x.ID == 1 && x.BlogDurum == 1).ToList();
            ViewBag.Partial3 = c.Blogs.Where(x => x.BlogDurum == 1).Take(10).ToList();
            ViewBag.Partial4 = c.Blogs.Where(x => x.BlogDurum == 1).Take(3).ToList();
            ViewBag.Partial5 = c.Blogs.Where(x => x.BlogDurum == 1).OrderByDescending(x => x.ID).Take(3).ToList();

            var degerler = c.Blogs.Where(x => x.BlogDurum == 1).Take(3).ToList();
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
            var degerler = c.Blogs.Where(b => b.BlogDurum == 1).OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial2()
        {
            var degerler = c.Blogs.Where(b => b.BlogDurum == 1).Where(x => x.ID == 1).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial3()
        {
            var deger = c.Blogs.Where(b => b.BlogDurum == 1).Take(10).ToList();

            return PartialView(deger);
        }
        public PartialViewResult Partial4()
        {
            var deger = c.Blogs.Where(b => b.BlogDurum == 1).Take(3).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial5()
        {
            var deger = c.Blogs.Where(b => b.BlogDurum == 1).Take(3).OrderByDescending(x => x.ID).ToList();
            return PartialView(deger);
        }
    }
}
