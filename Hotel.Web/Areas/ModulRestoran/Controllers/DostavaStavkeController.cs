using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRestoran.ViewModels;
using Microsoft.EntityFrameworkCore;
using Hotel.Web.Helper;

namespace Hotel.Web.Areas.ModulRestoran.Controllers
{
    [Area("ModulRestoran")]
    public class DostavaStavkeController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PrikaziStavkeZaDostavu(int DostavaId)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isKuhar == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }
            PrikaziStavkeDostaveVM Model = new PrikaziStavkeDostaveVM();
            Model.StavkeDostave = db.DostavaStavke.Include(x => x.Proizvod).Include(x=>x.Dostava).Where(x => x.DostavaId == DostavaId).ToList();
            return View(Model);
        }
        public IActionResult IsporuciDostavu(int DostavaId)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isKuhar == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }
            Dostava d = new Dostava();
            d = db.Dostava.Find(DostavaId);

            List<DostavaStavke> ds = new List<DostavaStavke>();
            ds = db.DostavaStavke.Include(x=>x.Proizvod).Include(x=>x.Dostava).Where(x => x.DostavaId == DostavaId).ToList();

            bool greska = false;
            string poruka;
            poruka = " ";
            foreach(DostavaStavke temp in ds)
            {
                if (temp.Kolicina > temp.Proizvod.Kolicina)
                {
                    greska = true;
                    poruka += temp.Proizvod.Naziv + "-- NARUČENO: "+temp.Kolicina+", NA STANJU: "+temp.Proizvod.Kolicina+"<br />";
                }
            }
            if (greska == true)
            {
                poruka += "<br />Molimo provjerite zalihe i napravite novu narudžbu proizvoda.";
                return RedirectToAction("PrikaziDostave", "Dostava", new { poruka = poruka });
            }
            foreach(DostavaStavke temp in ds)
            {
                temp.Proizvod.Kolicina -= temp.Kolicina; //Smanjujemo kolicinu na zalihama
            }

            d.Zavrsena = true;

            db.SaveChanges();
            return RedirectToAction("PrikaziDostave", "Dostava");
        }
    }
}