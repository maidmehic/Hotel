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


            model.dostave = db.Dostava.Include(x=>x.RezervisanSmjestaj).Include(x=>x.RezervisanSmjestaj.Smjestaj).Select(y => new DostavaIndexVM.Row
            {
               
              Datum= y.Datum.ToShortDateString(),
              Zavrsena= y.Zavrsena,
              RezervisanSmjestaj= "Broj smještaja: " + y.RezervisanSmjestaj.Smjestaj.BrojSmjestaja.ToString() + " sprat: " + y.RezervisanSmjestaj.Smjestaj.Sprat.ToString(),
              BrojStavki = db.DostavaStavke.Where(x => x.DostavaId == y.Id).Count(),
            }).ToList();

            return View(model);
        }
        public IActionResult DostaveNaSmjestaj(int IdSmjestaja)
        {
            DostavaDostaveNaSmjestajVM model = new DostavaDostaveNaSmjestajVM();
            RezervisanSmjestaj s = db.RezervisanSmjestaj.Include(x=>x.Smjestaj).Include(x=>x.Smjestaj.VrstaSmjestaja).Where(x => x.SmjestajId == IdSmjestaja).FirstOrDefault();
            model.RezervisanSmjestaj =  s.Smjestaj.Sprat + " " + s.Smjestaj.VrstaSmjestaja.Naziv;

            // treba mi broj proizvoda u dostavi
            //List<DostavaStavke> listaDostava =db.DostavaStavke.Where(x=>x.) 
                // treba mi link na detalje dostave gdje bi vidio sve stavke te dostave 
            model.dostave = db.Dostava.Include(x=>x.RezervisanSmjestaj).Where(x=>x.RezervisanSmjestaj.SmjestajId==IdSmjestaja).Select(y => new DostavaDostaveNaSmjestajVM.Row
            {

                Datum = y.Datum.ToShortDateString(),
                Zavrsena = y.Zavrsena,
                BrojStavki = db.DostavaStavke.Where(x=>x.DostavaId==y.Id).Count(),


            }).ToList();

            return PartialView(model);
        }
        public IActionResult StavkeDostaveNaSmjestaj(int DostavaId)
        {
            DostavaStavkeDostaveNaSmjestajVM model = new DostavaStavkeDostaveNaSmjestajVM();

            model.stavke = db.DostavaStavke.Where(x => x.DostavaId == DostavaId).Select(x => new DostavaStavkeDostaveNaSmjestajVM.row {
                Proizvod=x.Proizvod.Naziv,
                Kolicina=x.Kolicina
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
            
            RezervisanSmjestaj s = db.RezervisanSmjestaj.Include(x=>x.Smjestaj).Where(x => x.Id == RezervisanSmjestajId).FirstOrDefault();

            DostavaDodajVM model = new DostavaDodajVM();

            model.Datum = d.Datum.ToShortDateString();
            model.RezervisanSmjestajId = RezervisanSmjestajId;
            model.DostavaId = d.Id;
            model.IdSmjestaja =s.SmjestajId;
            model.PodaciOSmjestaju = "Broj smještaja: "+ s.Smjestaj.BrojSmjestaja.ToString() + " sprat: " + s.Smjestaj.Sprat.ToString();
            


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


            RezervisanSmjestaj ss = db.RezervisanSmjestaj.Include(x => x.Smjestaj).Where(x => x.Id == model.RezervisanSmjestajId).FirstOrDefault();
            Dostava d = db.Dostava.Where(x => x.Id == model.DostavaId).FirstOrDefault();

            DostavaDodajVM model2 = new DostavaDodajVM();

            model2.Datum = d.Datum.ToShortDateString();
            model2.RezervisanSmjestajId = model.RezervisanSmjestajId;
            model2.DostavaId = d.Id;
            model2.IdSmjestaja = ss.SmjestajId;
            model2.PodaciOSmjestaju = "Broj smještaja: " + ss.Smjestaj.BrojSmjestaja.ToString() + " sprat: " + ss.Smjestaj.Sprat.ToString();




            return View("Dodaj",model2);
        }

        [HttpPost]
        public IActionResult Dodaj(DostavaDodajVM model)
        {


            return RedirectToAction("ProvjeriSlobodanSmjestaj","RezervisanSmjestaj");
        }
    }
}