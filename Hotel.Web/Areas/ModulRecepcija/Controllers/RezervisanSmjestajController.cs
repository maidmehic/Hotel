using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRecepcija.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Web.Areas.ModulRecepcija.Controllers
{
    [Area("ModulRecepcija")]
    public class RezervisanSmjestajController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            RezervisanSmjestajIndexVM model = new RezervisanSmjestajIndexVM();

            model.smjestaji = db.RezervisanSmjestaj.Select(x => new RezervisanSmjestajIndexVM.Row
            {
                Id=x.Id,
                Smjestaj = "Sprat: " + x.Smjestaj.Sprat + "," + x.Smjestaj.Kvadratura + "m^2, vrsta smjestaja: " + x.Smjestaj.VrstaSmjestaja.Naziv,
                Gost= x.Gost.Ime+" " +x.Gost.Prezime ,
                GostId=x.GostId,
                CheckINID=x.CheckINId,
                CheckIN= "Nosioc rezervacije: "+ x.CheckIN.Gost.Ime + " "+ x.CheckIN.Gost.Prezime +" Boravio od do" +x.CheckIN.DatumDolaska.ToShortDateString()+"-" +x.CheckIN.DatumOdlaska.ToShortDateString()
                
            }).ToList();



            return View(model);
        }
        public IActionResult Dodaj()
        {
            RezervisanSmjestajDodajVM model = new RezervisanSmjestajDodajVM();

            var CheckINI =
            db.CheckIN
           .Select(s => new
           {
               s.Id,

               Polje = string.Format("Gost nosilac: {0} Datum Dolaska {1} Datum Odlaska: {2} /// Broj djece:{3} Broj odraslih: {4}", s.Gost.Ime + s.Gost.Prezime, s.DatumDolaska, s.DatumOdlaska, s.BrojDjece, s.BrojOdraslih)
           })
    .ToList();

            var Smjestaji =
           db.Smjestaj
          .Where(x=>x.Zauzeto==false).Select(s => new
          {
              s.Id,

              Polje = string.Format("Vrsta smjestaja : {0} Sprat: {1}", s.VrstaSmjestaja.Naziv, s.Sprat)
          })
   .ToList();

            var Gosti =
           db.Gost
          .Select(s => new
          {
              s.Id,

              Polje = string.Format("Gost: {0} Telefon: {1}", s.Ime + s.Prezime, s.Telefon)
          })
   .ToList();

            model.Checkini = new SelectList(CheckINI, "Id", "Polje");
            model.Smjestaji = new SelectList(Smjestaji, "Id", "Polje");
            model.Gosti = new SelectList(Gosti, "Id", "Polje");

            return View(model);
        }
        [HttpPost]
        public IActionResult Dodaj(RezervisanSmjestajDodajVM model)
        {
            RezervisanSmjestaj s = new RezervisanSmjestaj();
            s.CheckINId = model.CheckIN.Id;
            s.GostId = model.Gost.Id;
            s.SmjestajId = model.Smjestaj.Id;
            ZauzmiSmjestaj(model.Smjestaj.Id);
            db.RezervisanSmjestaj.Add(s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public void ZauzmiSmjestaj(int id) {           
            Smjestaj s = new Smjestaj();
            s = db.Smjestaj.Where(x => x.Id == id).FirstOrDefault();
            s.Zauzeto = true;
            db.Smjestaj.Update(s);
        }
        public IActionResult Obrisi(int ID)
        {

            RezervisanSmjestaj s = new RezervisanSmjestaj();

            s = db.RezervisanSmjestaj.Include(x=>x.Smjestaj).Where(x => x.Id == ID).FirstOrDefault();
            s.Smjestaj.Zauzeto = false;
            db.Smjestaj.Update(s.Smjestaj);

            db.RezervisanSmjestaj.Remove(s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult ProvjeriSlobodanSmjestaj()
        {
            RezervisanSmjestajProvjeriSlobodanSmjestajVM model = new RezervisanSmjestajProvjeriSlobodanSmjestajVM();

            model.lista = db.Smjestaj.Include(x=>x.VrstaSmjestaja).Where(x => x.Zauzeto == false).Select(x => new RezervisanSmjestajProvjeriSlobodanSmjestajVM.Row
            {
                Opis= "Broj Smjestaja: "+ x.BrojSmjestaja.ToString() + " opremljen sa: "+x.BrojKreveta.ToString() +" kreveta, nalazi se na: " +x.Sprat.ToString() + " spratu i ima: "+x.Kvadratura.ToString()+" kvadrata",
                Cijena=x.Cijena,
                VrstaSmjestaja=x.VrstaSmjestaja.Naziv

            }).ToList();

            return View(model);
        }
      
      
    }
}