using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web.Areas.ModulRestoran.ViewModels;
using Hotel.Web.Helper;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel.Web.Areas.ModulRestoran.Controllers
{
    [Area("ModulRestoran")]
    public class NarudzbaController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NovaNarudzba()
        {

            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isKuhar == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }
            DodajNarudzbuVM Model = new DodajNarudzbuVM();
            Model.DatumKreiranja = DateTime.Now;
            Model.Zavrsena = false;
            Model.Otkazana = false;
            Model.ZaposlenikId = HttpContext.GetLogiraniKorisnik().Id;

            return View(Model);
        }
        public IActionResult Snimi(DodajNarudzbuVM n)//Snima novu narudzbu
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isKuhar == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }
            if (!ModelState.IsValid)
            {
                return View("NovaNarudzba", n);
            }

            Narudzba temp= new Narudzba();
            temp.Hitnost = n.Hitnost;
            temp.Opis = n.Opis;
            temp.ZaposlenikId = n.ZaposlenikId;
            temp.DatumKreiranja = n.DatumKreiranja;
            temp.Zavrsena = n.Zavrsena;
            temp.Otkazana = n.Otkazana;

            db.Narudzba.Add(temp);
            db.SaveChanges();
            return RedirectToAction("DodavanjeStavki","Stavke");
        }

        public IActionResult SnimiNarudzbuPoslijeEdita(UrediNarudzbuIStavkeVM n)//Snima editovanu narudzbu
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isKuhar == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }
            Narudzba temp = new Narudzba();
            temp = db.Narudzba.Find(n.Id);
            temp.Hitnost = n.Hitnost;
            temp.DatumKreiranja = n.DatumKreiranja;
            temp.Opis = n.Opis;
            temp.ZaposlenikId = n.ZaposlenikId;
            temp.Zavrsena = n.Zavrsena;
            temp.Otkazana = n.Otkazana;

            db.SaveChanges();
            return RedirectToAction("PrikaziZalihe", "Proizvod");
        }


        public IActionResult Uredi(int Id)
        {

            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isKuhar == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }
            UrediNarudzbuIStavkeVM Model = new UrediNarudzbuIStavkeVM();
            Narudzba n = new Narudzba();
            n = db.Narudzba.Find(Id);

            Model.Id = n.Id;
            Model.DatumKreiranja = n.DatumKreiranja;
            Model.Opis = n.Opis;
            Model.Hitnost = n.Hitnost;
            Model.ZaposlenikId = n.ZaposlenikId;
            Model.Zavrsena = n.Zavrsena;
            Model.Otkazana = n.Otkazana;
            // Model.StavkeNarudzbe.Stavke = db.Stavke.Include(x => x.Proizvodi).Include(x => x.Narudzba).Where(x => x.NarudzbaId == n.Id).ToList();
            Model.StavkeNarudzbe = new PrikaziStavkeVM();
            Model.StavkeNarudzbe.Stavke = db.Stavke.Include(x => x.Proizvodi).Include(x => x.Narudzba).Where(x => x.NarudzbaId == n.Id).ToList();
            Model.StavkeNarudzbe.NarudzbaId = n.Id;


            List<SelectListItem> _stavke = new List<SelectListItem>();
            _stavke.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite proizvod"
            });

            _stavke.AddRange(db.Proizvod.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }));
            Model.StavkeNarudzbe.ProizvodiStavke = _stavke;
            

            return View(Model);
        }

        public IActionResult SnimiStavku(PrikaziStavkeVM s)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isKuhar == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Uredi", new { Id = s.NarudzbaId });
            }

            if (db.Stavke.Where(x => (x.NarudzbaId == s.NarudzbaId) && (x.ProizvodId == s.ProizvodId)).Any())
            {
                return RedirectToAction("Uredi", new { Id = s.NarudzbaId });
            }



            Stavke temp= new Stavke();

            temp.Kolicina = s.Kolicina ?? 0;
            temp.NarudzbaId = s.NarudzbaId;
            temp.ProizvodId = s.ProizvodId;

            db.Stavke.Add(temp);
            db.SaveChanges();
            return RedirectToAction("Uredi", new { Id = temp.NarudzbaId });
           
        }


        public IActionResult ObrisiStavku(int Id)//Brise stavke narudzbe (prilikom edita)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isKuhar == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }
            Stavke s = db.Stavke.Find(Id);
            db.Stavke.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Uredi", new { Id = s.NarudzbaId });
        }

        public IActionResult ProvjeriHitnost(string Hitnost)
        {
            if (Hitnost == "Odaberite hitnost")
                return Json("Odaberite hitnost.");
            return Json(true);
        }

        public IActionResult PrikaziNarudzbe(int ? StanjeOdabir,string poruka)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isKuhar == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }
            PrikaziNarudzbeVM Model = new PrikaziNarudzbeVM();
            ViewBag.Poruka = poruka;
            if (StanjeOdabir == null)
                Model.Narudzbe = db.Narudzba.Where(x=>x.Zavrsena==false&& x.Otkazana==false).Include(x => x.Zaposlenik).OrderByDescending(x => x.DatumKreiranja).ToList();
            
            if (StanjeOdabir == 1)
                 Model.Narudzbe = db.Narudzba.Include(x => x.Zaposlenik).OrderByDescending(x => x.DatumKreiranja).ToList();

            if (StanjeOdabir == 2)
                Model.Narudzbe = db.Narudzba.Where(x => x.Zavrsena == true).Include(x => x.Zaposlenik).OrderByDescending(x => x.DatumKreiranja).ToList();

            if (StanjeOdabir == 3)
                Model.Narudzbe = db.Narudzba.Where(x => x.Otkazana == true).Include(x => x.Zaposlenik).OrderByDescending(x => x.DatumKreiranja).ToList();

            Model.zaposlenikId =HttpContext.GetLogiraniKorisnik().Id;
            return View(Model);
        }

        public IActionResult ProvjeriNosiocaNarudzbe (int Id)
        {

            Narudzba n = new Narudzba();
            n = db.Narudzba.Find(Id);
            if (n.ZaposlenikId == HttpContext.GetLogiraniKorisnik().Id)
            {
                return RedirectToAction("Uredi", new { Id = n.Id });
            }
            return RedirectToAction("PrikaziNarudzbe", new { poruka = "Samo nosilac narudžbe može urediti istu."});
        }

        public IActionResult PrikaziStavkeNarudzbe(int Id)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isKuhar == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }
            PrikaziStavkeVM Model = new PrikaziStavkeVM();
            Model.Stavke = db.Stavke.Where(x => x.NarudzbaId == Id).Include(x=>x.Proizvodi).ToList();
            return View(Model);
        }

        public IActionResult OtkaziNarudzbu(int Id)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isKuhar == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }
            Narudzba temp = new Narudzba();
            temp = db.Narudzba.Find(Id);
            temp.Otkazana = true;
            db.SaveChanges();

            return RedirectToAction("PrikaziNarudzbe");
        }
    }
}