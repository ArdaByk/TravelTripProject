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
        [HttpGet]
        public IActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var b = c.Blogs.Find(id);
            return View("BlogGetir", b);
        }
        public ActionResult BlogGuncelle(Blog p)
        {
            var b = c.Blogs.Find(p.ID);
            b.Aciklama = p.Aciklama;
            b.Baslik = p.Baslik;
            b.BlogImage = p.BlogImage;
            b.Tarih = p.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
