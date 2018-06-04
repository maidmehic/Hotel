using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web.Areas.ModulAdministracija.ViewModels;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotel.Web.Helper;

namespace Hotel.Web.Areas.ModulAdministracija.Controllers
{
    [Area("ModulAdministracija")]
    public class SmjestajController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult PrikaziSmjestaj( int ? BrojPretraga, int ? StatusPretraga)
        {

            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }

            PrikazSmjestajaVM Model = new PrikazSmjestajaVM();
            Model.Smjestaji = db.Smjestaj.Include(x=>x.VrstaSmjestaja).
                Where(x=>((x.BrojSmjestaja == BrojPretraga) && ((x.Zauzeto == true && StatusPretraga == 2)||!StatusPretraga.HasValue))||
                ((x.BrojSmjestaja == BrojPretraga) && ((x.Zauzeto == false && StatusPretraga == 1) || !StatusPretraga.HasValue)) ||
                (!BrojPretraga.HasValue)&& (x.Zauzeto == false && StatusPretraga == 1)||
                (!BrojPretraga.HasValue) && (x.Zauzeto == true && StatusPretraga == 2) ||
                (!BrojPretraga.HasValue) && (!StatusPretraga.HasValue))
                .ToList();
            Model.BrojPretraga = null;
            return View(Model);
        }
        public IActionResult DodajSmjestaj()
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }

            NoviSmjestajVM Model = new NoviSmjestajVM();
            Model.Zauzeto = false;
            NapuniCmb(Model);
            return View(Model);
        }

        void NapuniCmb(NoviSmjestajVM s)
        {
            List<SelectListItem> _stavke = new List<SelectListItem>();
            _stavke.Add(new SelectListItem
            {
                Value = null,
                Text = "Odaberite vrstu"
            });
            _stavke.AddRange(db.VrstaSmjestaja.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }));

            s._vrstaStavke = _stavke;
        }
        public IActionResult ProvjeriBroj(int BrojSmjestaja,int Id)
        {
            if (db.Smjestaj.Any(x => x.BrojSmjestaja == BrojSmjestaja && x.Id!=Id))
                return Json("Broj smještaja je već upotrebljen.");
            return Json(true);
        }

        public IActionResult ProvjeriVrstu(int? VrstaSmjestajaId)
        {
            if (VrstaSmjestajaId == null)
                return Json("Odaberite vrstu!");
            return Json(true);
        }


        public IActionResult Snimi(NoviSmjestajVM s)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }

            if (!ModelState.IsValid)
            {
                NapuniCmb(s);
                return View("DodajSmjestaj", s);
            }

            Smjestaj temp;
            if (s.Id == 0)
            {
                temp = new Smjestaj();
                db.Smjestaj.Add(temp);
            }
            else
            {
                temp = db.Smjestaj.Find(s.Id);
            }
            
            temp.BrojSmjestaja = s.BrojSmjestaja??0;//Ovako radimo da bi nam izbacilo 0 sa viewa
            temp.Sprat = s.Sprat??0;
            temp.BrojKreveta = s.BrojKreveta??0;
            temp.Kvadratura = s.Kvadratura ?? 0;
            temp.Zauzeto = s.Zauzeto;
            temp.Cijena = s.Cijena ?? 0;
            temp.VrstaSmjestajaId = s.VrstaSmjestajaId;
            db.SaveChanges();
            return RedirectToAction("PrikaziSmjestaj");
        }
        public IActionResult Uredi(int id)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }

            NoviSmjestajVM Model = new NoviSmjestajVM();
            Smjestaj s = new Smjestaj();
            s = db.Smjestaj.Find(id);
            Model.Id = s.Id;
            Model.BrojSmjestaja = s.BrojSmjestaja;
            Model.BrojKreveta = s.BrojKreveta;
            Model.Kvadratura = s.Kvadratura;
            Model.Sprat = s.Sprat;
            Model.VrstaSmjestajaId = s.VrstaSmjestajaId;
            Model.Zauzeto = s.Zauzeto;
            Model.Cijena = s.Cijena;
            List<SelectListItem> _stavke = new List<SelectListItem>();
            _stavke.Add(new SelectListItem
            {
                Value = null,
                Text = "Odaberite vrstu"
            });
            _stavke.AddRange(db.VrstaSmjestaja.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }));
            Model._vrstaStavke = _stavke;
            return View(Model);
        }


        //Rezervisan smjestaj

        public IActionResult HistorijaIzdavanja(int id, DateTime CheckInDatum)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }

            HistorijaIzdavanjaVM Model = new HistorijaIzdavanjaVM();
            Model.RezervacijeZaSmjestaj = db.RezervisanSmjestaj.
                Include(x => x.Smjestaj).
                Include(x => x.CheckIN).
                Include(x=>x.CheckIN.Gost).
                Include(x => x.Gost).
                Include(x => x.Gost.Grad).
                Where(x => (x.SmjestajId == id && CheckInDatum <= x.CheckIN.DatumDolaska)).ToList();
            Model.id = id;

            //Model.FeedbaciZaSmjestaj = db.Feedback.
            //    Include(x => x.CheckIN).                Vidjeti ovo oko feedbackova
            //    Include(x => x.Gost).ToList();
            return View(Model);
        }
    }
}