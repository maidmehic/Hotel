using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRecepcija.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.ModulRecepcija.Controllers
{
    [Area("ModulRecepcija")]
    public class DostavaController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            DostavaIndexVM model = new DostavaIndexVM();


            model.dostave = db.Dostava.Select(x => new DostavaIndexVM.Row
            {
                Cijena= x.Cijena,
                Kolicina= x.Kolicina,
                Naziv= x.Naziv,
                Gost=x.RezervisanSmjestaj.Gost.Ime +" "+x.RezervisanSmjestaj.Gost.Prezime,

            }).ToList();

            return View(model);
        }
       
        public IActionResult Dodaj(int RezervisanSmjestajId)
        {
            DostavaDodajVM model = new DostavaDodajVM();

            model.RezervisanSmjestajId = RezervisanSmjestajId;




            return View(model);
        }
        [HttpPost]
        public IActionResult Dodaj(DostavaDodajVM model)
        {

            Dostava d = new Dostava();
            d.Cijena = model.Cijena;
            d.Kolicina = model.Kolicina;
            d.Naziv = model.Naziv;
            d.RezervisanSmjestajId = model.RezervisanSmjestajId;

            db.Dostava.Add(d);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}