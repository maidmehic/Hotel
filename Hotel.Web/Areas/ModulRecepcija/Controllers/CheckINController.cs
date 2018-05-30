using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Helper;
using Hotel.Web.Areas.ModulRecepcija.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Web.Areas.ModulRecepcija.Controllers
{
    [Area("ModulRecepcija")]
    public class CheckINController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index(string PretraziPo,string pretraga)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k==null || k.isRecepcioner == false)
            {
                TempData["error_poruka"] = "nemate pravo pristupa/TREBA RECEPCIJA";
                return RedirectToAction("Index", "Autentifikacija",new { area=" "});

            }


            CheckINIndexVM model = new CheckINIndexVM();
            model.Brojac = 0;
            if (PretraziPo == "Ime")
            {

                model.CheckINI = db.CheckIN.Where(x=>x.Gost.Ime.StartsWith(pretraga)).Select(x => new CheckINIndexVM.Row
                {
                    Id = x.Id,
                    BrojDjece = x.BrojDjece,
                    BrojOdraslih = x.BrojOdraslih,
                    DatumDolaska = x.DatumDolaska.ToShortDateString(),
                    DatumOdlaska = x.DatumOdlaska.ToShortDateString(),
                  
                    Napomena = x.Napomena,
                    Gost = x.Gost.Ime + " " + x.Gost.Prezime,
                    GostId=x.GostId,
                    Zaposlenik = x.Zaposlenik.Ime + " " + x.Zaposlenik.Prezime,
                   BrojPasosa = x.Gost.BrojPasosa,
                    TipUsluge = x.TipUsluge.Naziv + " " + x.TipUsluge.Cijena + "KM"
                    


                }).ToList();
               
            }
          
            if (PretraziPo == "BrojPasosa")
            {
                model.CheckINI = db.CheckIN.Where(x => x.Gost.BrojPasosa.StartsWith(pretraga)).Select(x => new CheckINIndexVM.Row
                {
                    Id = x.Id,
                    BrojDjece = x.BrojDjece,
                    BrojOdraslih = x.BrojOdraslih,
                    DatumDolaska = x.DatumDolaska.ToShortDateString(),
                    DatumOdlaska = x.DatumOdlaska.ToShortDateString(),
                   
                    Napomena = x.Napomena,
                    Gost = x.Gost.Ime + " " + x.Gost.Prezime,
                    GostId = x.GostId,
                    Zaposlenik = x.Zaposlenik.Ime + " " + x.Zaposlenik.Prezime,
                    TipUsluge = x.TipUsluge.Naziv + " " + x.TipUsluge.Cijena + "KM",
                      BrojPasosa = x.Gost.BrojPasosa,


                }).ToList();
            }
            if (PretraziPo == "Sve")
            {
                model.CheckINI = db.CheckIN.Select(x => new CheckINIndexVM.Row
                {
                    Id = x.Id,
                    BrojDjece = x.BrojDjece,
                    BrojOdraslih = x.BrojOdraslih,
                    DatumDolaska = x.DatumDolaska.ToShortDateString(),
                    DatumOdlaska = x.DatumOdlaska.ToShortDateString(),

                    Napomena = x.Napomena,
                    Gost = x.Gost.Ime + " " + x.Gost.Prezime,
                    GostId = x.GostId,
                    BrojPasosa = x.Gost.BrojPasosa,
                    Zaposlenik = x.Zaposlenik.Ime + " " + x.Zaposlenik.Prezime,
                    TipUsluge = x.TipUsluge.Naziv + " " + x.TipUsluge.Cijena + "KM"



                }).ToList();
            }
            if (PretraziPo == null)
            {
                model.CheckINI = db.CheckIN.Select(x => new CheckINIndexVM.Row
                {
                    Id = x.Id,
                    BrojDjece = x.BrojDjece,
                    BrojOdraslih = x.BrojOdraslih,
                    DatumDolaska = x.DatumDolaska.ToShortDateString(),
                    DatumOdlaska = x.DatumOdlaska.ToShortDateString(),
                 
                    Napomena = x.Napomena,
                    Gost = x.Gost.Ime + " " + x.Gost.Prezime,
                    GostId = x.GostId,
                    BrojPasosa = x.Gost.BrojPasosa,
                    Zaposlenik = x.Zaposlenik.Ime + " " + x.Zaposlenik.Prezime,
                    TipUsluge = x.TipUsluge.Naziv + " " + x.TipUsluge.Cijena + "KM"



                }).ToList();
            }
            if (model.CheckINI!=null)
                model.Brojac = model.CheckINI.Count;
            else
                model.Brojac = 0;
            return View(model);
        }
        public void PripremiStavkeModela(CheckINDodajVM model)
        {

            model.GostId = model.GostId;
            var Usluge = db.TipUsluge.Select(s => new
            {
                s.Id,
                Polje = string.Format("Naziv: {0} Cijena: {1}  ", s.Naziv, s.Cijena)
            }).ToList();

           
            model.TipoviUsluga = new SelectList(Usluge, "Id", "Polje");
        }
        public IActionResult OdaberiteGosta()
        {          
            return RedirectToAction("Index","Gost");
        }
        


        public IActionResult Dodaj(int GostId)
        {
            CheckINDodajVM model = new CheckINDodajVM();
            model.GostId = GostId;
            PripremiStavkeModela(model);


            return View(model);
        }
        [HttpPost]
        public IActionResult Dodaj(CheckINDodajVM model)
        {


            if (!ModelState.IsValid)
            {
                PripremiStavkeModela(model);
                return View("Dodaj", model);
            }

            CheckIN c = new CheckIN();

           
            c.TipUslugeId = model.TipUsluge.Id;
            c.ZaposlenikId = HttpContext.GetLogiraniKorisnik().Id;// PREUZIMATI IZ SESIJE
            c.BrojDjece = model.BrojDjece;
            c.BrojOdraslih = model.BrojOdraslih;
            c.DatumDolaska = model.DatumDolaska;
            c.DatumOdlaska = model.DatumOdlaska;
           
            c.Napomena = model.Napomena;
            c.GostId = model.GostId;

            db.CheckIN.Add(c);
            db.SaveChanges();


            return RedirectToAction("OdaberiSmjestaj","RezervisanSmjestaj",new { CheckInId =c.Id});
        }
        public IActionResult CheckOut(int GostId)
        {
            CheckIN c = new CheckIN();
            c = db.CheckIN.Where(x => x.GostId == GostId).FirstOrDefault();
            c.DatumOdlaska = DateTime.Now.Date;

            // racunanje racuna i slanje u akciju dodajracun
            CheckINCheckOutVM model = new CheckINCheckOutVM();
            model.CheckInId = c.Id;

            double suma= new double();

            TipUsluge t = db.TipUsluge.Where(x => x.Id == c.TipUslugeId).FirstOrDefault();
            suma += t.Cijena;

            List<RezervisanaUsluga> rezervisane = db.RezervisanaUsluga.Include(x=>x.UslugeHotela).Where(x => x.CheckINId == c.Id).ToList();

            foreach (var i in rezervisane)
            {
                suma += i.UslugeHotela.Cijena;
            }

            List<RezervisanSmjestaj> smjestaji = db.RezervisanSmjestaj.Include(x=>x.Smjestaj).Where(x => x.CheckINId == c.Id).ToList();

            foreach (var I in smjestaji)
            {
                suma += I.Smjestaj.Cijena;
            }

            model.Iznos = suma;
           

           
            return PartialView(model);
        }
        public IActionResult Detalji(int Id)
        {
            CheckIN c = db.CheckIN.Include(x=>x.TipUsluge).Where(x => x.Id == Id).FirstOrDefault();
        
            return View(c);
        }
        public IActionResult Obrisi(int Id)
        {
            // obrisi implementirat mozda

           return RedirectToAction("Index");
        }
    }
}