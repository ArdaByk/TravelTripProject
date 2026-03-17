using Microsoft.AspNetCore.Mvc;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers;

public class DefaultController : Controller
{
    Context c = new Context();
    public IActionResult Index()
    {
        var degerler = c.Blogs.ToList();
        return View(degerler);
    }

    public ActionResult About()
    {
        return View();
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
}
