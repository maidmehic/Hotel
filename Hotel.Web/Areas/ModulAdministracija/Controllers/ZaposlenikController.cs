using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulAdministracija.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Web.Helper;

namespace Hotel.Web.Areas.ModulAdministracija.Controllers
{ 
    [Area("ModulAdministracija")]
    public class ZaposlenikController : Controller
    {
        MojContext db = new MojContext();

        public IActionResult Index()
        {
            return View();
        }
        //

        public void PripremiCmb(NoviZaposlenikVM zaposlenik)
        {
            List<SelectListItem> _grStavke = new List<SelectListItem>();
            _grStavke.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite grad"
            });
            _grStavke.AddRange(db.Grad.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }));

            zaposlenik.gradoviStavke = _grStavke;

            List<SelectListItem> _spStavke = new List<SelectListItem>();
            _spStavke.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite spol"
            });
            _spStavke.Add(new SelectListItem()
            {
                Value = "Muški",
                Text = "Muški"
            });
            _spStavke.Add(new SelectListItem()
            {
                Value = "Ženski",
                Text = "Ženski"
            });

            zaposlenik.spoloviStavke = _spStavke;

            List<SelectListItem> _brStavke = new List<SelectListItem>();
            _brStavke.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite bračni status"
            });
            _brStavke.Add(new SelectListItem()
            {
                Value = "Oženjen",
                Text = "Oženjen"
            });
            _brStavke.Add(new SelectListItem()
            {
                Value = "Udata",
                Text = "Udata"
            });

            zaposlenik.brakStavke = _brStavke;
        }

        public IActionResult ProvjeriBracniStatus(string BracniStatus)
        {
            if (BracniStatus == "Odaberite bračni status")
                return Json("Odaberite bračni status!");

            return Json(true);
        }

        public IActionResult ProvjeriSpol(string Spol)
        {
            if (Spol == "Odaberite spol")
                return Json("Odaberite spol!");

            return Json(true);
        }

        public IActionResult ProvjeriGrad(int ? GradId)
        {
            if (GradId == null)
                return Json("Odaberite grad!");
            return Json(true);
        }



        public IActionResult DodajZaposlenika()
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }

            NoviZaposlenikVM Model = new NoviZaposlenikVM();
            Model.Aktivan = true;
            Model.isAdministrator = false;
            Model.isCistacica = false;
            Model.isKuhar = false;
            Model.isRecepcioner = false;

            PripremiCmb(Model);

            return View(Model);
        }   //

        public IActionResult PrikaziZaposlenike(int? Tip, string ImePrezimePretraga)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }

            PrikazZaposlenikaVM Model = new PrikazZaposlenikaVM();
            Model.Zaposlenici = db.Zaposlenik.Include(x=>x.Grad).
                Where(x => ((x.isAdministrator == true && Tip == 1) && ((x.Ime + " " + x.Prezime).Contains(ImePrezimePretraga) || ImePrezimePretraga == null) ||
                         (x.isCistacica == true && Tip == 2) && ((x.Ime + " " + x.Prezime).Contains(ImePrezimePretraga) || ImePrezimePretraga == null) ||
                         (x.isRecepcioner == true && Tip == 3) && ((x.Ime + " " + x.Prezime).Contains(ImePrezimePretraga) || ImePrezimePretraga == null) ||
                         (x.isKuhar == true && Tip == 4) && ((x.Ime + " " + x.Prezime).Contains(ImePrezimePretraga) || ImePrezimePretraga == null) ||
                         (!Tip.HasValue) && ((x.Ime + " " + x.Prezime).Contains(ImePrezimePretraga) || ImePrezimePretraga == null))).ToList();
            return View(Model);
        }
        
        public IActionResult ViseDetalja(int Id)
        {
            PrikazZaposlenikaVM Model = new PrikazZaposlenikaVM();
            Model.Zaposlenik = db.Zaposlenik.Include(x => x.Grad).Where(x => x.Id == Id).FirstOrDefault();
            return View(Model);
        }
        public IActionResult SnimiZaposlenika(NoviZaposlenikVM zaposlenik) //
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }
            if (!ModelState.IsValid)
            {
                PripremiCmb(zaposlenik);
                return View("DodajZaposlenika", zaposlenik);
            }

            Zaposlenik z;
            if (zaposlenik.Id == 0)
            {
                z = new Zaposlenik();
                db.Zaposlenik.Add(z);
            }
            else
            {
                z = db.Zaposlenik.Find(zaposlenik.Id);
            }
            z.Ime = zaposlenik.Ime;
            z.Prezime = zaposlenik.Prezime;
            z.DatumRodjenja = zaposlenik.DatumRodjenja;
            z.Telefon = zaposlenik.Telefon;
            z.BracniStatus = zaposlenik.BracniStatus;
            z.Email = zaposlenik.Email;
            z.BrojUgovora = zaposlenik.BrojUgovora;
            z.DatumZaposljenja = zaposlenik.DatumZaposljenja;
            z.JMBG = zaposlenik.JMBG;
            z.Spol = zaposlenik.Spol;
            z.Aktivan = zaposlenik.Aktivan;
            z.isAdministrator = zaposlenik.isAdministrator;
            z.isCistacica = zaposlenik.isCistacica;
            z.isKuhar = zaposlenik.isKuhar;
            z.isRecepcioner = zaposlenik.isRecepcioner;
            z.GradId = zaposlenik.GradId;
           
            db.SaveChanges();
            return RedirectToAction("PrikaziZaposlenike");
        }

        public IActionResult UrediZaposlenika(int id) 
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }


            NoviZaposlenikVM Model = new NoviZaposlenikVM();

            Zaposlenik z = new Zaposlenik();
            z = db.Zaposlenik.Find(id);

            Model.Id = z.Id;
            Model.Ime = z.Ime;
            Model.Prezime = z.Prezime;
            Model.DatumRodjenja = z.DatumRodjenja;
            Model.DatumZaposljenja = z.DatumZaposljenja;
            Model.Telefon = z.Telefon;
            Model.BracniStatus = z.BracniStatus;
            Model.Email = z.Email;
            Model.BrojUgovora = z.BrojUgovora;
            Model.JMBG = z.JMBG;
            Model.Spol = z.Spol;
            Model.Aktivan = z.Aktivan;
            Model.GradId = z.GradId;
            Model.isAdministrator = z.isAdministrator;
            Model.isCistacica = z.isCistacica;
            Model.isRecepcioner = z.isRecepcioner;
            Model.isKuhar = z.isKuhar;

            List<Grad> Gradovi = db.Grad.ToList();
            List<SelectListItem> _grStavke = new List<SelectListItem>();
            _grStavke.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite grad"
            });
            _grStavke.AddRange(Gradovi.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }));

            Model.gradoviStavke = _grStavke;

            List<SelectListItem> _spStavke = new List<SelectListItem>();
            _spStavke.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite spol"
            });
            _spStavke.Add(new SelectListItem()
            {
                Value = "Muški",
                Text = "Muški"
            });
            _spStavke.Add(new SelectListItem()
            {
                Value = "Ženski",
                Text = "Ženski"
            });

            Model.spoloviStavke = _spStavke;

            List<SelectListItem> _brStavke = new List<SelectListItem>();
            _brStavke.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite bračni status"
            });
            _brStavke.Add(new SelectListItem()
            {
                Value = "Oženjen",
                Text = "Oženjen"
            });
            _brStavke.Add(new SelectListItem()
            {
                Value = "Udata",
                Text = "Udata"
            });
            _brStavke.Add(new SelectListItem()
            {
                Value = "Slobodan/a",
                Text = "Slobodan/a"
            });

            Model.brakStavke = _brStavke;


            return View(Model);
        }  //

         // 

    }
}