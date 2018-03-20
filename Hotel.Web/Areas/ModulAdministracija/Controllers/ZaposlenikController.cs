using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulAdministracija.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult DodajZaposlenika()
        {
            NoviZaposlenikVM Model = new NoviZaposlenikVM();
            List<Grad> Gradovi = db.Grad.ToList();
            Model.Aktivan = true;
            Model.isAdministrator = false;
            Model.isCistacica = false;
            Model.isKuhar = false;
            Model.isRecepcioner = false;

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

            Model.brakStavke = _brStavke;

            return View(Model);
        }   //

        public IActionResult SnimiZaposlenika(NoviZaposlenikVM zaposlenik) //
        {
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

            Model.brakStavke = _brStavke;


            return View(Model);
        }  //

        public IActionResult PrikaziZaposlenike(int ? Tip, string ImePrezimePretraga)
        {
            PrikazZaposlenikaVM Model = new PrikazZaposlenikaVM();
            Model.Zaposlenici = db.Zaposlenik.
                Where(x=>((x.isAdministrator == true && Tip == 1) && (ImePrezimePretraga==x.Ime+" "+x.Prezime || ImePrezimePretraga==null)||
                         (x.isCistacica==true && Tip == 2) && (ImePrezimePretraga == x.Ime + " " + x.Prezime || ImePrezimePretraga == null) ||
                         (x.isRecepcioner == true && Tip == 3) && (ImePrezimePretraga == x.Ime + " " + x.Prezime || ImePrezimePretraga == null) ||
                         (x.isKuhar == true && Tip == 4) && (ImePrezimePretraga == x.Ime + " " + x.Prezime || ImePrezimePretraga == null) ||
                         (!Tip.HasValue) && (ImePrezimePretraga == x.Ime + " " + x.Prezime || ImePrezimePretraga == null))).ToList();
            return View(Model);
        }     // 

    }
}