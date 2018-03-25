using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Data.Models;
using Hotel.Web.Models;
using Microsoft.AspNetCore.Http;
using Hotel.Web.Helper;

namespace Hotel.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        MojContext db = new MojContext();

        public IActionResult Index()
        {
            LoginVM Model = new LoginVM();
            Model.zapamtiPassword = true;
            return View(Model);
        }

        public IActionResult Login(LoginVM input)
        {
            Zaposlenik zaposlenik = db.Zaposlenik.SingleOrDefault(x => x.username == input.username && x.password == input.password);
            if (zaposlenik == null)
            {
                TempData["error_poruka"] = "pogresan username ili password";
                return View("Index", input);
            }
            
            HttpContext.SetLogiraniKorisnik(zaposlenik); 
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


    }
}