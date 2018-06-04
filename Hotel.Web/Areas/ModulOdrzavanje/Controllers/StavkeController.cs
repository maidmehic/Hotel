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

namespace Hotel.Web.Areas.ModulOdrzavanje.Controllers
{
    [Area("ModulOdrzavanje")]
    public class StavkeController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index(int IdNarudzbe)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isCistacica == false)
            {
                TempData["error_poruka"] = "nemate pravo pristupa";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });

            }

            PrikaziStavkeNarudzbeVM model = new PrikaziStavkeNarudzbeVM();

            model.IdNarudzbe = IdNarudzbe;
            model.stavke = db.Stavke.Include(x => x.Proizvodi).Where(x => x.NarudzbaId == IdNarudzbe).Select(x => new PrikaziStavkeNarudzbeVM.Stavka
            {
                StavkaId = x.Id,
                Kolicina = x.Kolicina,
                NazivProizvoda = x.Proizvodi.Naziv,
                CijenaProizvoda=x.Proizvodi.Cijena.ToString() +" KM",
                CijenaStavke=x.Proizvodi.Cijena*x.Kolicina +" KM"
                
            }).ToList();
            return PartialView(model);
        }
        public IActionResult Dodaj(int NarudzbaId)
        {
            DodajStavkuVM model = new DodajStavkuVM();
            model.NarudzbaId = NarudzbaId;
            model.Proizvodi = new SelectList(db.Proizvod, "Id", "Naziv");

            return View(model);
        }
        [HttpPost]
        public IActionResult Dodaj(DodajStavkuVM model)
        {

            if (model.Kolicina == 0)
            {
                model.Proizvodi = new SelectList(db.Proizvod, "Id", "Naziv");
                ViewBag.Poruka = "kolicina mora biti veca od 0 ";
                return View("Dodaj", model);
            }

            Stavke stavka = new Stavke();

            stavka.Kolicina = model.Kolicina;
            stavka.ProizvodId = model.Proizvod.Id;
            stavka.NarudzbaId = model.NarudzbaId;

            db.Stavke.Add(stavka);
            db.SaveChanges();

            return RedirectToAction("Detalji", "Narudzba", new { NarudzbaID = model.NarudzbaId });
        }
        public IActionResult Obrisi(int StavkaId, int narudzbaID)
        {
            Stavke s = new Stavke();
            s = db.Stavke.Where(x => x.Id == StavkaId).FirstOrDefault();

            db.Stavke.Remove(s);
            db.SaveChanges();


            return RedirectToAction("Detalji", "Narudzba", new { NarudzbaID = narudzbaID });
        }
        public IActionResult ObrisiSveStavkeNarudzbe(int narudzbaID)
        {
            List<Stavke> s = new List<Stavke>();
            s = db.Stavke.Where(x => x.NarudzbaId == narudzbaID).ToList();

            db.Stavke.RemoveRange(s);
            db.SaveChanges();

            return RedirectToAction("Detalji", "Narudzba", new { NarudzbaID = narudzbaID });
        }

    }
}