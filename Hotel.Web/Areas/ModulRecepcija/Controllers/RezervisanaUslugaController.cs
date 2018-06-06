using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRecepcija.ViewModels;
using Hotel.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Web.Areas.ModulRecepcija.Controllers
{
    [Area("ModulRecepcija")]
    public class RezervisanaUslugaController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isRecepcioner == false)
            {
                TempData["error_poruka"] = "nemate pravo pristupa";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });

            }
            RezervisanaUslugaIndexVM model = new RezervisanaUslugaIndexVM();
         
            model.usluge = db.RezervisanaUsluga.Select(x => new RezervisanaUslugaIndexVM.Row{
                Id=x.Id,
                UslugeHotela = x.UslugeHotela.Naziv +"/"+ x.UslugeHotela.Opis + "/" +x.UslugeHotela.Cijena,
                CheckIN= x.CheckIN.Gost.Ime+" "+x.CheckIN.Gost.Prezime +"("+ x.CheckIN.DatumDolaska.ToShortDateString() +"-" + x.CheckIN.DatumOdlaska.ToShortDateString() + ")"



            }).ToList();

            return View(model);
        }
        public IActionResult UslugeOdabranogSmjestaja(int RezervisanSmjestajID)
        {
            RezervisanaUslugaUslugeOdabranogSmjestajaVM model = new RezervisanaUslugaUslugeOdabranogSmjestajaVM();

         
            // nadi rezervisan smjestaj
            RezervisanSmjestaj s = db.RezervisanSmjestaj.Where(x => x.Id == RezervisanSmjestajID).FirstOrDefault();
            //nadi rezervisane usluge za taj smjestaj
            model.lista = db.RezervisanaUsluga.Include(x=>x.UslugeHotela).Where(x => x.CheckINId == s.CheckINId).ToList();

            return View(model);
        }
        public IActionResult Dodaj(int RezervisanSmjestajID)
        {
            RezervisanaUslugaDodajVM model = new RezervisanaUslugaDodajVM();

            RezervisanSmjestaj sr = new RezervisanSmjestaj();
            sr = db.RezervisanSmjestaj.Include(x=>x.CheckIN.Gost).Include(x=>x.Gost).Where(x=>x.Id==RezervisanSmjestajID).Where(x => x.Id == RezervisanSmjestajID).FirstOrDefault();

            model.Rezervacija = sr.CheckIN.Gost.Ime + " "+ sr.CheckIN.Gost.Prezime;
            model.Datum ="Od: " + sr.CheckIN.DatumDolaska.ToShortDateString() + " do" + sr.CheckIN.DatumOdlaska.ToShortDateString();
            model.Gost = sr.Gost.Ime + " " + sr.Gost.Prezime;
            model.CheckINId = sr.CheckINId;

            var Usluge =
         db.UslugeHotela
        .Select(s => new
        {
            Id = s.Id,
            Polje = string.Format("Naziv: {0} Cijena: {1} Datum Pocetka: {2} Datum Zavrsetka:{3} ", s.Naziv, s.Cijena, s.DatumPocetka, s.DatumZavrsetka)
        })
 .ToList();


            model.UslugeHotela = new SelectList(Usluge, "Id", "Polje");
         
            return View(model);

        }

        [HttpPost]
        public IActionResult Dodaj(RezervisanaUslugaDodajVM model)
        {

            RezervisanaUsluga ru = new RezervisanaUsluga();
            ru.CheckINId = model.CheckINId;
            ru.UslugeHotelaId = model.Usluga.Id;

            db.RezervisanaUsluga.Add(ru);
            db.SaveChanges();

            return RedirectToAction("ProvjeriSlobodanSmjestaj","RezervisanSmjestaj");
        }
        public IActionResult Obrisi(int Id)
        {
            RezervisanaUsluga re = db.RezervisanaUsluga.Where(x => x.Id == Id).FirstOrDefault();

            db.RezervisanaUsluga.Remove(re);
            db.SaveChanges();



            return RedirectToAction("Index");
        }

    }

   
}