using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRecepcija.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel.Web.Areas.ModulRecepcija.Controllers
{
    [Area("ModulRecepcija")]
    public class RezervisanaUslugaController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            RezervisanaUslugaIndexVM model = new RezervisanaUslugaIndexVM();
         
            model.usluge = db.RezervisanaUsluga.Select(x => new RezervisanaUslugaIndexVM.Row{
                Id=x.Id,
                UslugeHotela = x.UslugeHotela.Naziv +"/"+ x.UslugeHotela.Opis + "/" +x.UslugeHotela.Cijena,
                CheckIN= x.CheckIN.Gost.Ime+" "+x.CheckIN.Gost.Prezime +"("+ x.CheckIN.DatumDolaska.ToShortDateString() +"-" + x.CheckIN.DatumOdlaska.ToShortDateString() + ")"



            }).ToList();

            return View(model);
        }
        public IActionResult Dodaj()
        {
            RezervisanaUslugaDodajVM model = new RezervisanaUslugaDodajVM();


            var CheckINI =
            db.CheckIN
           .Select(s => new
           {
               Id = s.Id,
               
               Polje = string.Format("Gost: {0} Datum Dolaska {1} Datum Odlaska: {2} /// Broj djece:{3} Broj odraslih: {4}", s.Gost.Ime + s.Gost.Prezime, s.DatumDolaska, s.DatumOdlaska, s.BrojDjece, s.BrojOdraslih)
           })
    .ToList();



            var Usluge =
         db.UslugeHotela
        .Select(s => new
        {
            Id = s.Id,
            Polje = string.Format("Naziv: {0} Cijena: {1} Datum Pocetka: {2} Datum Zavrsetka:{3} ", s.Naziv, s.Cijena, s.DatumPocetka, s.DatumZavrsetka)
        })
 .ToList();


            model.UslugeHotela = new SelectList(Usluge, "Id", "Polje");
            model.Checkini = new SelectList(CheckINI, "Id", "Polje");

            return View(model);

        }

        [HttpPost]
        public IActionResult Dodaj(RezervisanaUslugaDodajVM model)
        {

            RezervisanaUsluga ru = new RezervisanaUsluga();
            ru.CheckINId = model.CheckIN.Id;
            ru.UslugeHotelaId = model.Usluga.Id;

            db.RezervisanaUsluga.Add(ru);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Obrisi(int Id)
        {
            RezervisanaUsluga re = db.RezervisanaUsluga.Where(x => x.Id == Id).FirstOrDefault();

            db.RezervisanaUsluga.Remove(re);
            db.SaveChanges();



            return RedirectToAction("Index");
        }

    }

   
}