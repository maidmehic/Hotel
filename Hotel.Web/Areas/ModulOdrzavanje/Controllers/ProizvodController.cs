using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulOdrzavanje.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.ModulOdrzavanje.Controllers
{
    public class ProizvodController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            ProizvodIndexVM model = new ProizvodIndexVM();

            model.Proizvodi = db.Proizvod.Select(x=> new ProizvodIndexVM.Row {
                Naziv=x.Naziv,
                Cijena=x.Cijena,
                Vrsta=x.Vrsta

            }).ToList();



            return View(model);
        }
        public IActionResult Dodaj()
        {
            ProizvodDodajVM model = new ProizvodDodajVM();

            

            return View(model);
        }
        [HttpPost]
        public IActionResult Dodaj(ProizvodDodajVM model)
        {

            Proizvodi p = new Proizvodi();

            p.Naziv = model.Naziv;
            p.Cijena = model.Cijena;
            p.Vrsta = model.Vrsta;

            db.Proizvod.Add(p);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
        public IActionResult Edit(int Id)
        {
            ProizvodDodajVM model = new ProizvodDodajVM();

            Proizvodi p = new Proizvodi();
            p = db.Proizvod.Where(x => x.Id == Id).FirstOrDefault();

            model.Naziv = p.Naziv;
            model.Cijena = p.Cijena;
            model.Vrsta = p.Vrsta;



            return View(model);
        }
        public IActionResult Izbrisi()
        {
            return View();
        }

    }
}