using Microsoft.AspNetCore.Mvc;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers;

public class BlogController : Controller
{
    Context c = new Context();
    public IActionResult Index()
    {
        var blogs = c.Blogs.ToList();
        return View(blogs);
    }
    public IActionResult BlogDetay(int id)
    {
        var blogBul = c.Blogs.Where(x => x.ID == id).ToList();
        return View(blogBul);
    }
}
