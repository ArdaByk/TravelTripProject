using Microsoft.AspNetCore.Mvc;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers;

public class BlogController : Controller
{
    Context c = new Context();
    BlogYorum by = new BlogYorum();
    public IActionResult Index()
    {
        //var blogs = c.Blogs.ToList();
        by.Deger1 = c.Blogs.ToList();
        by.Deger3 = c.Blogs.Take(3).ToList();
        return View(by);
    }
    
    public IActionResult BlogDetay(int id)
    {

        //var blogBul = c.Blogs.Where(x => x.ID == id).ToList();
        by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
        by.Deger2 = c.Yorumlars.Where(x => x.BlogID == id).ToList();

        return View(by);
    }
}
