using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRecepcija.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Web.Areas.ModulRecepcija.Controllers
{
    [Area("ModulRecepcija")]
    public class DostavaController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            DostavaIndexVM model = new DostavaIndexVM();


            model.dostave = db.Dostava.Include(x=>x.RezervisanSmjestaj).Select(x => new DostavaIndexVM.Row
            {
               
              Datum= x.Datum.ToShortDateString(),
              Zavrsena= x.Zavrsena,
              RezervisanSmjestaj= x.RezervisanSmjestaj.Smjestaj.Sprat +" "+x.RezervisanSmjestaj.Smjestaj.VrstaSmjestaja.Naziv

            }).ToList();

            return View(model);
        }
        public IActionResult DostaveNaSmjestaj(int IdSmjestaja)
        {
            DostavaDostaveNaSmjestajVM model = new DostavaDostaveNaSmjestajVM();
            RezervisanSmjestaj s = db.RezervisanSmjestaj.Include(x=>x.Smjestaj).Include(x=>x.Smjestaj.VrstaSmjestaja).Where(x => x.SmjestajId == IdSmjestaja).FirstOrDefault();
            model.RezervisanSmjestaj =  s.Smjestaj.Sprat + " " + s.Smjestaj.VrstaSmjestaja.Naziv;

            model.dostave = db.Dostava.Include(x=>x.RezervisanSmjestaj).Where(x=>x.RezervisanSmjestaj.SmjestajId==IdSmjestaja).Select(x => new DostavaDostaveNaSmjestajVM.Row
            {

                Datum = x.Datum.ToShortDateString(),
                Zavrsena = x.Zavrsena,
               

            }).ToList();

            return PartialView(model);
        }

        public IActionResult Dodaj(int RezervisanSmjestajId)
        {


            Dostava d = new Dostava();
            d.RezervisanSmjestajId = RezervisanSmjestajId;
            d.Zavrsena = false;
            d.Datum = DateTime.Now;

            db.Dostava.Add(d);
            db.SaveChanges();

            RezervisanSmjestaj s = db.RezervisanSmjestaj.Where(x => x.Id == RezervisanSmjestajId).FirstOrDefault();

            DostavaDodajVM model = new DostavaDodajVM();

            model.Datum = d.Datum.ToShortDateString();
            model.RezervisanSmjestajId = RezervisanSmjestajId;
            model.DostavaId = d.Id;
            model.IdSmjestaja =s.SmjestajId;

            


            return View(model);
        }

        public IActionResult DodajStavku(int DostavaId,int RezervisanSmjestajId)
        {
            DostavaDodajStavkuVM model = new DostavaDodajStavkuVM();

            model.DostavaId = DostavaId;
            model.Proizvodi = db.Proizvod.Where(x => x.Vrsta != "sastojak").ToList();
            model.RezervisanSmjestajId = RezervisanSmjestajId;

            return PartialView(model);
        }
        [HttpPost]
        public IActionResult DodajStavku(DostavaDodajStavkuVM model)
        {
            DostavaStavke s = new DostavaStavke();

            s.DostavaId = model.DostavaId;
            s.ProizvodId = model.ProizvodId;
            s.Kolicina = model.Kolicina;

            db.DostavaStavke.Add(s);
            db.SaveChanges();

            return RedirectToAction("Dodaj", new { model.RezervisanSmjestajId });
        }

        [HttpPost]
        public IActionResult Dodaj(DostavaDodajVM model)
        {


            return RedirectToAction("Index");
        }
    }
}