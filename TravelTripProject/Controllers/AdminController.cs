using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            // Set a default empty image so we don't get null reference errors later if it expects a string.
            p.BlogImage = "";
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("BlogResimEkle", new { id = p.ID });
        }

        [HttpGet]
        public IActionResult BlogResimEkle(int id)
        {
            ViewBag.BlogId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BlogResimEkle(int id, List<IFormFile> images)
        {
            var blog = c.Blogs.Find(id);
            if (images != null && images.Count > 0)
            {
                bool isFirst = true;
                foreach (var img in images)
                {
                    if (img.Length > 0)
                    {
                        var extension = Path.GetExtension(img.FileName);
                        var newImageName = Guid.NewGuid() + extension;
                        // Use wwwroot/images folder
                        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                        if (!Directory.Exists(imagePath))
                        {
                            Directory.CreateDirectory(imagePath);
                        }
                        
                        var location = Path.Combine(imagePath, newImageName);
                        using (var stream = new FileStream(location, FileMode.Create))
                        {
                            await img.CopyToAsync(stream);
                        }
                        
                        string url = "/images/" + newImageName;

                        if (isFirst && string.IsNullOrEmpty(blog.BlogImage))
                        {
                            blog.BlogImage = url;
                            isFirst = false;
                        }

                        c.BlogResims.Add(new BlogResim { BlogID = id, ImageUrl = url });
                    }
                }
                c.SaveChanges();
            }
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
            b.BlogDurum = p.BlogDurum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.Include(b => b.Blog).ToList();
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
            b.Okundu = p.Okundu;
            b.Yayinlandi = p.Yayinlandi;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}
