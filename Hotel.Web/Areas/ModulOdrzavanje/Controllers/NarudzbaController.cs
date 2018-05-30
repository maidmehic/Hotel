using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRecepcija.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Hotel.Web.Areas.ModulRecepcija.ViewModels.PrikaziNarudzbeVM;

namespace Hotel.Web.Areas.ModulOdrzavanje.Controllers
{
    [Area("ModulOdrzavanje")]
    public class NarudzbaController : Controller
    {
        MojContext db = new MojContext();
      

        public IActionResult Index()
        {
            return RedirectToAction("PrikaziNarudzbe");
        }
        public IActionResult DodajNarudzbu()
        {
            DodajNarudzbuVM model = new DodajNarudzbuVM();

            model.DatumKreiranja = DateTime.Now.Date.ToShortDateString();

            return PartialView(model);
        }
        [HttpPost]
        public IActionResult DodajNarudzbu(DodajNarudzbuVM model)
        {

            Narudzba n = new Narudzba();
            n.DatumKreiranja = Convert.ToDateTime(model.DatumKreiranja);
            n.Opis = model.Opis;
            n.Hitnost = model.Hitnost;
            n.ZaposlenikId = 2; //izmjenit da se dobija iz sesije



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
                DatumKreiranja = x.DatumKreiranja.ToShortDateString(),
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
                DatumKreiranja = x.DatumKreiranja.ToShortDateString(),
                Hitnost = x.Hitnost,
                Opis = x.Opis,
                ImeZaposlenika = x.Zaposlenik.Ime
            }).ToList();

            return View(narudzbe);
        }

        public IActionResult ObrisiStavkeNarudzbe(int ID)
        {

            return RedirectToAction("ObrisiSveStavkeNarudzbe","Stavke", new { narudzbaID = ID });
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

           

            return View(model);
        }
        [HttpPost]
        public IActionResult UrediNarudzbu(UrediNarudzbuVM model)
        {
            Narudzba n = new Narudzba();

            n = db.Narudzba.Where(x => x.Id == model.Id).FirstOrDefault();

            n.Hitnost = model.Hitnost;
             n.Opis=model.Opis;
            

            db.Narudzba.Update(n);
            db.SaveChanges();


            return RedirectToAction("PrikaziNarudzbe");
        }
        public IActionResult ObrisiNarudzbu(int NarudzbaId)
        {
            
            ObrisiStavkeNarudzbe(NarudzbaId);
            Narudzba n = new Narudzba();
            n = db.Narudzba.Where(x => x.Id == NarudzbaId).FirstOrDefault();

            db.Narudzba.Remove(n);
            db.SaveChanges();

            return RedirectToAction("PrikaziNarudzbe");
        }
        public IActionResult AjaxTestAction()
        {
            return PartialView("_AjaxTestView");
        }
    }
}