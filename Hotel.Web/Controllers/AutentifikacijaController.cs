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
                TempData["error_poruka"] = "Pogresan username ili password.";
                return View("Index", input);
            }
            
            HttpContext.SetLogiraniKorisnik(zaposlenik);


            if (HttpContext.GetLogiraniKorisnik().isAdministrator)
            {
                return RedirectToAction("Index", "Index",new {Area="ModulAdministracija"});
            }

            if (HttpContext.GetLogiraniKorisnik().isKuhar)
            {
                return RedirectToAction("Index", "Index", new { Area = "ModulRestoran" });
            }
            if (HttpContext.GetLogiraniKorisnik().isRecepcioner)
            {
                return RedirectToAction("Index", "Index", new { Area = "ModulRecepcija" });
            }

            if (HttpContext.GetLogiraniKorisnik().isCistacica)
            {
                return RedirectToAction("Index", "Index", new { Area = "ModulOdrzavanje" });
            }
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


    }
}