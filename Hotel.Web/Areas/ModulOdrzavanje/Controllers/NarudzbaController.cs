using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulOdrzavanje.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Hotel.Web.Areas.ModulOdrzavanje.ViewModels.PrikaziNarudzbeVM;

namespace Hotel.Web.Areas.ModulOdrzavanje.Controllers
{
    [Area("ModulOdrzavanje")]
    public class NarudzbaController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DodajNarudzbu()
        {


            return View();
        }
        [HttpPost]
        public IActionResult DodajNarudzbu(DodajNarudzbuVM model)
        {

            Narudzba n = new Narudzba();
            n.DatumKreiranja = model.DatumKreiranja;
            n.Opis = model.Opis;
            n.Hitnost = model.Hitnost;
            n.ZaposlenikId = 2; // izmijenit da dobija iz sesije 



            db.Narudzba.Add(n);
            db.SaveChanges();


            return RedirectToAction("PrikaziNarudzbe");
        }

        public IActionResult Detalji(int NarudzbaID)
        {
            Row model = db.Narudzba.Include(x => x.Zaposlenik).Where(x => x.Id == NarudzbaID).Select(x => new Row
            {
                Id = x.Id,
                Hitnost = x.Hitnost,
                DatumKreiranja = x.DatumKreiranja,
                Opis = x.Opis,
                ImeZaposlenika = x.Zaposlenik.Ime + x.Zaposlenik.Prezime

            }).FirstOrDefault();

            return View(model);
        }
        public IActionResult PrikaziNarudzbe()
        {
            PrikaziNarudzbeVM narudzbe = new PrikaziNarudzbeVM();

            narudzbe.podaci = db.Narudzba.Include(x => x.Zaposlenik).Select(x => new PrikaziNarudzbeVM.Row
            {
                Id = x.Id,
                DatumKreiranja = x.DatumKreiranja,
                Hitnost = x.Hitnost,
                Opis = x.Opis,
                ImeZaposlenika = x.Zaposlenik.Ime
            }).ToList();

            return View(narudzbe);
        }

        public IActionResult ObrisiStavkeNarudzbe()
        {

            return RedirectToAction("PrikaziStavkeNarudzbe");
        }
        public IActionResult UrediNarudzbu(int id)
        {
            UrediNarudzbuVM model = new UrediNarudzbuVM();
            Narudzba n = new Narudzba();
            n = db.Narudzba.Where(x => x.Id == id).FirstOrDefault();

            model.Id = id;
            model.Hitnost = n.Hitnost;
            model.Opis = n.Opis;
            model.DatumKreiranja = n.DatumKreiranja;

            model.Zaposlenici = new SelectList(db.Zaposlenik, "Id", "Ime");

            return View(model);
        }
        [HttpPost]
        public IActionResult UrediNarudzbu(UrediNarudzbuVM model)
        {
            Narudzba n = new Narudzba();

            n = db.Narudzba.Where(x => x.Id == model.Id).FirstOrDefault();

            n.Hitnost = model.Hitnost;
            n.DatumKreiranja = model.DatumKreiranja;
            n.ZaposlenikId = model.zaposlenik.Id;

            db.Narudzba.Update(n);
            db.SaveChanges();


            return RedirectToAction("PrikaziNarudzbe");
        }
        public IActionResult ObrisiNarudzbu()
        {


            return View();
        }
        public IActionResult AjaxTestAction()
        {
            return PartialView("_AjaxTestView");
        }
    }
}