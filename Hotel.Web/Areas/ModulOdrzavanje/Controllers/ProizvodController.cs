using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRecepcija.ViewModels;
using Hotel.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.ModulOdrzavanje.Controllers
{
    [Area("ModulOdrzavanje")]
    public class ProizvodController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isCistacica == false)
            {
                TempData["error_poruka"] = "nemate pravo pristupa";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });

            }

            ProizvodIndexVM model = new ProizvodIndexVM();

            model.Proizvodi = db.Proizvod.Select(x => new ProizvodIndexVM.Row
            {
                Naziv = x.Naziv,
                Cijena = x.Cijena,
                Vrsta = x.Vrsta,
                MjernaJedinica=x.MjernaJedinica,
                ID = x.Id
            }).ToList();



            return View(model);
        }
        public IActionResult Dodaj(int NarudzbaId)
        {
            ProizvodDodajVM model = new ProizvodDodajVM();
            model.NarudzbaId = NarudzbaId;



           return View(model);
        }
        [HttpPost]
        public IActionResult Dodaj(ProizvodDodajVM model)
        {

            //if (!ModelState.IsValid)
            //{
            //    return PartialView("Dodaj", model);
            //}

            Proizvodi p = new Proizvodi();

            p.Naziv = model.Naziv;
            p.Cijena = model.Cijena;
            p.Vrsta = model.Vrsta;

            db.Proizvod.Add(p);
            db.SaveChanges();


            return RedirectToAction("Dodaj", "Stavke", new { NarudzbaId = model.NarudzbaId });
        }
        public IActionResult Edit(int ProizvodId)
        {
            ProizvodDodajVM model = new ProizvodDodajVM();

            Proizvodi p = new Proizvodi();
            p = db.Proizvod.Where(x => x.Id == ProizvodId).FirstOrDefault();

            model.Naziv = p.Naziv;
            model.Cijena = p.Cijena;
            model.Vrsta = p.Vrsta;
            model.ID = p.Id;


            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ProizvodDodajVM model)
        {

            Proizvodi p = db.Proizvod.Where(x => x.Id == model.ID).FirstOrDefault();

            p.Naziv = model.Naziv;
            p.Cijena = model.Cijena;
            p.Vrsta = model.Vrsta;

            db.Proizvod.Update(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Obrisi(int Id)
        {
            Proizvodi p = db.Proizvod.Where(x => x.Id == Id).FirstOrDefault();
            db.Proizvod.Remove(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}