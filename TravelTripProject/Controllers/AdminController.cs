using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelTripProject.Models.Siniflar;
namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        [Authorize]
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
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();

            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
                var b = c.Yorumlars.Find(id);
                return View("YorumGetir", b);
        }
        public ActionResult YorumGuncelle(Yorumlar p)
        {
            var b = c.Yorumlars.Find(p.ID);
            b.KullaniciAdi = p.KullaniciAdi;
            b.Mail = p.Mail;
            b.Yorum = p.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}
