using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRecepcija.ViewModels;
using Hotel.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Web.Areas.ModulRecepcija.Controllers
{
    [Area("ModulRecepcija")]
    public class GostController : Controller
    {
        MojContext db = new MojContext();

        public IActionResult Index(string ImePrezimePretraga)
        {
            GostIndexVM model = new GostIndexVM();

            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isRecepcioner == false)
            {
                TempData["error_poruka"] = "nemate pravo pristupa/TREBA RECEPCIJA";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });

            }


            model.Gosti = db.Gost.Where(x => x.Ime.StartsWith(ImePrezimePretraga) || x.Prezime.StartsWith(ImePrezimePretraga) || ImePrezimePretraga == null).Select(x => new GostIndexVM.Row
            {
                Id = x.Id,
                BrojPasosa = x.BrojPasosa,
               ImePrezime = x.Ime + " " + x.Prezime,
           
                Drzavljanstvo = x.Drzavljanstvo,
                DatumRodenja = x.DatumRodenja.ToShortDateString(),
                Telefon = x.Telefon,
                Email = x.Email,
                Grad = x.Grad.Naziv,
               
                Spol = x.Spol
                   

    }).ToList();




            return View(model);
        }
        public IActionResult Detalji(int GostId,string ImeKontrolera,string ImeAkcije,int? IdPozivatelja)
        {

            GostIndexVM.Row model = new GostIndexVM.Row();
            Gost x = db.Gost.Include(c=>c.Grad).Where(c => c.Id == GostId).FirstOrDefault();
            model.Id = x.Id;
            model.BrojPasosa = x.BrojPasosa;
            model.ImePrezime = x.Ime +" "+ x.Prezime;
           
            model.Drzavljanstvo = x.Drzavljanstvo;
            model.DatumRodenja = x.DatumRodenja.ToShortDateString();
            model.Telefon = x.Telefon;
            model.Email = x.Email;
            model.Grad = x.Grad.Naziv;
            model.Spol = x.Spol;
            model.ImeAkcije = ImeAkcije;
            model.ImeKontrolera = ImeKontrolera;
            model.IdPozivatelja = IdPozivatelja!=null ? IdPozivatelja.Value : 0;

            return PartialView(model);
        }
        [HttpPost]
        public IActionResult Detalji(GostIndexVM.Row model)
        {

            //string controllerName = ControllerContext.RouteData.Values["controller"].ToString();
            if (model.IdPozivatelja == 0)
                return RedirectToAction(model.ImeAkcije, model.ImeKontrolera);
            else
                return RedirectToAction(model.ImeAkcije, model.ImeKontrolera, new { Id = model.IdPozivatelja });
        }
        public void PripremiStavkeModela(GostDodajVM model)
        {
            model.Gradovi = new SelectList(db.Grad, "Id", "Naziv", "--Odaberite Grad--");
        }
        public IActionResult DetaljiZaposlenika(int ZaposlenikId,string ImeKontrolera,string ImeAkcije, int? IdPozivatelja)
        {
            GostDetaljiZaposlenikaVM z = new GostDetaljiZaposlenikaVM();

            z = db.Zaposlenik.Include(x=>x.Grad).Where(x => x.Id == ZaposlenikId).Select(x=>new GostDetaljiZaposlenikaVM {
                ImePrezime= x.Ime +" "+ x.Prezime,
                Telefon= x.Telefon,
                DatumRodjenja=x.DatumRodjenja.ToShortDateString(),                          
                Email=x.Email,                
                Spol=x.Spol,             
                Grad=x.Grad.Naziv,
                ImeKontrolera=ImeKontrolera,
                ImeAkcije=ImeAkcije,
                IdPozivatelja = IdPozivatelja != null ? IdPozivatelja.Value : 0

        }).FirstOrDefault();

            return PartialView(z);
        }
  
        [HttpPost]
        public IActionResult DetaljiZaposlenika(GostDetaljiZaposlenikaVM z)
        {


            if (z.IdPozivatelja == 0)
                return RedirectToAction(z.ImeAkcije, z.ImeKontrolera);
            else
                return RedirectToAction(z.ImeAkcije, z.ImeKontrolera, new { Id = z.IdPozivatelja });
          
        }



        public IActionResult Dodaj()
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isRecepcioner == false)
            {
                TempData["error_poruka"] = "nemate pravo pristupa/TREBA RECEPCIJA";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });

            }


            GostDodajVM model = new GostDodajVM();
            PripremiStavkeModela(model);


            return View(model);
        }
        [HttpPost]
        public IActionResult Dodaj(GostDodajVM model)
        {

            if (!ModelState.IsValid)
            {
                PripremiStavkeModela(model);
                return View("Dodaj", model);
            }


            Gost g;

            if (model.Id == 0)
            {
                g = new Gost();
                db.Add(g);

            }
            else
            {
                g = db.Gost.Find(model.Id);
            }


            g.BrojPasosa = model.BrojPasosa;
            g.Ime = model.Ime;
            g.Prezime = model.Prezime;
            g.Drzavljanstvo = model.Drzavljanstvo;
            g.DatumRodenja = model.DatumRodenja;
            g.Email = model.Email;
            g.Telefon = model.Telefon;
            g.Spol = model.Spol;
            g.GradId = model.GradId;



            db.SaveChanges();



            return RedirectToAction("Index");
        }
        public IActionResult Uredi(int GostID)
        {

            Gost g1 = db.Gost.Where(x => x.Id == GostID).FirstOrDefault();

            GostDodajVM g = new GostDodajVM();

            g.Id = g1.Id;
            g.BrojPasosa = g1.BrojPasosa;
            g.Ime = g1.Ime;
            g.Prezime = g1.Prezime;
            g.Drzavljanstvo = g1.Drzavljanstvo;
            g.DatumRodenja = g1.DatumRodenja;
            g.Email = g1.Email;
            g.Telefon = g1.Telefon;
            g.Spol = g1.Spol;


            g.Gradovi = new SelectList(db.Grad, "Id", "Naziv");

            return View(g);
        }
    
        public IActionResult Obrisi(int GostID)
        {
            Gost g = db.Gost.Where(x => x.Id == GostID).FirstOrDefault();


            db.Gost.Remove(g);
            db.SaveChanges();




            return RedirectToAction("Index");
        }
    }
}