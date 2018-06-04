using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulAdministracija.ViewModels;
using Hotel.Web.Helper;

namespace Hotel.Web.Areas.ModulAdministracija.Controllers
{
    [Area("ModulAdministracija")]
    public class ProizvodController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProvjeriVrstu(string Vrsta)
        {
            if (Vrsta == "Odaberite vrstu")
                return Json("Odaberite vrstu.");
            return Json(true);
        }

        public IActionResult ProvjeriMjernuJedinicu(string MjernaJedinica)
        {
            if (MjernaJedinica == "Mjerna jednica")
                return Json("Odaberite mjernu jedinicu.");
            return Json(true);
        }


        public IActionResult PrikaziProizvode(string NazivPretraga, int? VrstaOdabir)
        {


            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }

            PrikazProizvodaVM Model = new PrikazProizvodaVM();

            if (VrstaOdabir == null)
                Model.Proizvodi = db.Proizvod.Where(x => x.Naziv.Contains(NazivPretraga) || NazivPretraga == null).ToList();

            if (VrstaOdabir == 1)
                Model.Proizvodi = db.Proizvod.Where(x => x.Vrsta == "Hrana" && (x.Naziv.Contains(NazivPretraga) || NazivPretraga == null)).ToList();

            if (VrstaOdabir == 2)
                Model.Proizvodi = db.Proizvod.Where(x => (x.Naziv.Contains(NazivPretraga) || NazivPretraga == null) && x.Vrsta == "Pića").ToList();


            return View(Model);
        }

        public IActionResult DodajProizvod(string Link)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }

            NoviProizvodVM Model = new NoviProizvodVM();
           Model.Kolicina = 0;
           Model.Link = Link;
            return View(Model);
        }



        public IActionResult Snimi(NoviProizvodVM p)
        {

            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }

            if (p.Id != 0)
            {
                if(p.MjernaJedinica== "Mjerna jednica" || p.Vrsta== "Odaberite vrstu")
                    return View("UrediProizvod", p);//Kako ovdje vratiti poruke o gresci


                if (!ModelState.IsValid)
                {
                    return View("UrediProizvod",p);
                }
            }
            if (!ModelState.IsValid) // kad udje u ovaj dio koda, onda se ne izvrsi ajax
            {
                return View("DodajProizvod", p);
            }



            Proizvodi temp;
            if (p.Id == 0)
            {
                temp = new Proizvodi();
                db.Proizvod.Add(temp);
            }
            else
            {
                temp = db.Proizvod.Find(p.Id);
            }
            temp.Naziv = p.Naziv;
            temp.Kolicina = p.Kolicina;
            temp.MjernaJedinica = p.MjernaJedinica;
            temp.Vrsta = p.Vrsta;
            temp.Cijena = p.Cijena ?? 0;
            db.SaveChanges();
            return RedirectToAction("PrikaziProizvode");
        }

        public IActionResult UrediProizvod(int Id)
        {

            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }

            NoviProizvodVM Model = new NoviProizvodVM();
            Proizvodi p = new Proizvodi();
            p = db.Proizvod.Find(Id);

            Model.Cijena = p.Cijena;
            Model.Id = p.Id;
            Model.Kolicina = p.Kolicina;
            Model.MjernaJedinica = p.MjernaJedinica;
            Model.Naziv = p.Naziv;
            Model.Vrsta = p.Vrsta;
            
            return View(Model);
        
       }

        public IActionResult Obrisi(int Id)
        {

            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }

            Proizvodi p = new Proizvodi();
            p = db.Proizvod.Find(Id);
            db.Proizvod.Remove(p);
            db.SaveChanges();
            return RedirectToAction("PrikaziProizvode");
        }
        
    }
}