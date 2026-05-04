using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class GirisYapController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(Admin admin)
        {
            var bilgiler = c.Admins
    .FirstOrDefault(x => x.Kullanici == admin.Kullanici && x.Sifre == admin.Sifre);

            if (bilgiler != null)
            {
                var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, bilgiler.Kullanici)
    };

                var identity = new ClaimsIdentity(claims, "Login");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }

        }
        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "GirisYap");
        }
    }
}
