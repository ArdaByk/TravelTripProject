using Microsoft.AspNetCore.Mvc;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers;

public class AboutController : Controller
{
    Context c = new Context();

    public IActionResult Index()
    {
        var degerler = c.Hakkimizda.ToList();
        return View(degerler);
    }
}
