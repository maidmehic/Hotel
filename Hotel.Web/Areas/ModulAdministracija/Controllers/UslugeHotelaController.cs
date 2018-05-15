using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web.Areas.ModulAdministracija.ViewModels;
using Hotel.Data.Models;

namespace Hotel.Web.Areas.ModulAdministracija.Controllers
{
    [Area("ModulAdministracija")]
    public class UslugeHotelaController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DodajUsluguHotela()
        {
            NovaUslugaHotelaVM Model = new NovaUslugaHotelaVM();
            return View(Model);
        }
        public IActionResult PrikaziUslugeHotela(string PretragaNaziv, int ? PretragaAktivnostId)
        {
            PrikazUslugeHotelaVM Model = new PrikazUslugeHotelaVM();

            if (PretragaAktivnostId == 1) {
                Model.uslugeHotela = db.UslugeHotela.
                 Where(x => (x.Naziv == PretragaNaziv && x.DatumZavrsetka > DateTime.Now) ||
                      (PretragaNaziv == null && x.DatumZavrsetka > DateTime.Now)).
                 Select(x => new PrikazUslugeHotelaVM.Rows()
                 {
                     usluga = x,
                     Aktivna = ProvjeriValidnost(x.DatumZavrsetka)
                 }).ToList();
            }
            if (PretragaAktivnostId == 2)
            {
                Model.uslugeHotela = db.UslugeHotela.
                 Where(x => (x.Naziv == PretragaNaziv && x.DatumZavrsetka < DateTime.Now) ||
                      (PretragaNaziv == null && x.DatumZavrsetka < DateTime.Now)).
                 Select(x => new PrikazUslugeHotelaVM.Rows()
                 {
                     usluga = x,
                     Aktivna = ProvjeriValidnost(x.DatumZavrsetka)
                 }).ToList();
            }
            if (!PretragaAktivnostId.HasValue)
            {
                Model.uslugeHotela = db.UslugeHotela.
                    Where(x => (x.Naziv == PretragaNaziv) || (PretragaNaziv == null)).
                    Select(x => new PrikazUslugeHotelaVM.Rows()
                    {
                        usluga = x,
                        Aktivna = ProvjeriValidnost(x.DatumZavrsetka)
                    }).
                    ToList();
            }
            
            return View(Model);
        }

        bool ProvjeriValidnost(DateTime datum)
        {
            if (datum > DateTime.Now)
                return true;
            else
                return false;
        }

        public IActionResult ProvjeraDatuma(DateTime DatumZavrsetka, DateTime DatumPocetka)
        {
            if (DatumZavrsetka < DatumPocetka)
                return Json("Datum završetka mora biti veći od datuma početka.");

            if (DatumZavrsetka == DatumPocetka)
                return Json("Datum završetka ne smije biti isti kao datum početka.");

            return Json(true);
        }

       

        public IActionResult Snimi(NovaUslugaHotelaVM u)
        {

            if (!ModelState.IsValid)
            {
                return View("DodajUsluguHotela", u);
            }


            UslugeHotela t;

            if (u.Id == 0)
            {
                t = new UslugeHotela();
                db.UslugeHotela.Add(t);
            }
            else
            {
               t = db.UslugeHotela.Find(u.Id);
            }

            t.Naziv = u.Naziv;
            t.Cijena = u.Cijena;
            t.DatumPocetka = u.DatumPocetka;
            t.DatumZavrsetka = u.DatumZavrsetka;
            t.Opis = u.Opis;

            db.SaveChanges();

            return RedirectToAction("PrikaziUslugeHotela");
        }
        public IActionResult Uredi(int id)
        {
            NovaUslugaHotelaVM Model = new NovaUslugaHotelaVM();
            UslugeHotela u = new UslugeHotela();
            u = db.UslugeHotela.Find(id);
            Model.Cijena = u.Cijena;
            Model.DatumPocetka = u.DatumPocetka;
            Model.DatumZavrsetka = u.DatumZavrsetka;
            Model.Id = u.Id;
            Model.Naziv = u.Naziv;
            Model.Opis = u.Opis;
            return View(Model);
        }
    }
}