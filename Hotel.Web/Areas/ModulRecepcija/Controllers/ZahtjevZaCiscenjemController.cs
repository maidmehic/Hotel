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
    public class ZahtjevZaCiscenjemController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            ZahtjevZaCiscenjemIndexVM model = new ZahtjevZaCiscenjemIndexVM();

            
            model.zahtjevi = db.ZahtjevZaCiscenjem.Select(x => new ZahtjevZaCiscenjemIndexVM.Row
            {
                Id = x.Id,
                DatumZahtjeva = x.DatumZahtjeva,
                Opis = x.Opis,
                Prioritet = x.Prioritet,
                Obavljen = x.Obavljen,
                Smjestaj = x.Smjestaj.BrojSmjestaja + " " + x.Smjestaj.Sprat + " " + x.Smjestaj.VrstaSmjestaja.Naziv,              
                Zaposlenik = x.Zaposlenik.Ime + " " + x.Zaposlenik.Prezime
                


            }).ToList();
           
          
            return View(model);
        }
        public IActionResult OznaciObavljenim(int ZahtjevId,int CistacicaId)
        {
            ZahtjevZaCiscenjem z = new ZahtjevZaCiscenjem();

            z = db.ZahtjevZaCiscenjem.Where(x => x.Id == ZahtjevId).FirstOrDefault();

            z.Obavljen = true;
            z.ZaposlenikId = CistacicaId;

            db.ZahtjevZaCiscenjem.Update(z);
            db.SaveChanges();

           return RedirectToAction("Index");
        }
        public IActionResult Dodaj()
        {
            ZahtjevZaCiscenjemDodajVM model = new ZahtjevZaCiscenjemDodajVM();

            var smjestaji = db.Smjestaj.Include(x => x.VrstaSmjestaja).Select(x => new
            {
                x.Id,
                Opis = "Broj Smjestaja/BrKreveta/VrstaSmjestaja: " + x.BrojSmjestaja + "/ " + x.BrojKreveta + " / " + x.VrstaSmjestaja.Naziv,
            }).ToList();

            model.Smjestaji = new SelectList(smjestaji, "Id", "Opis");
            model.CistacicaID = null;
            

            return View(model);
        }
        [HttpPost]
        public IActionResult Dodaj(ZahtjevZaCiscenjemDodajVM model)
        {
            ZahtjevZaCiscenjem z = new ZahtjevZaCiscenjem();

            z.Obavljen = false;
            z.Opis = model.Opis;
            z.Prioritet = model.Prioritet;
            z.SmjestajId = model.Smjestaj.Id;
            z.DatumZahtjeva = System.DateTime.Now.Date;
            z.ZaposlenikId = model.CistacicaID;
            db.ZahtjevZaCiscenjem.Add(z);
            db.SaveChanges();



            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult PosaljiZahtjevZaCiscenjem(CheckINCheckOutVM model)
        {
            RacunController ra = new RacunController();
            //IActionResult akcija = ra.Dodaj(model.CheckInId,model.Iznos);
            ra.Dodaj(model.CheckInId, model.Iznos);
            ZahtjevZaCiscenjem m = new ZahtjevZaCiscenjem();
            RezervisanSmjestaj r = new RezervisanSmjestaj();
            r = db.RezervisanSmjestaj.Where(x => x.CheckINId == model.CheckInId).FirstOrDefault();
            m.Opis = model.Opis;
            m.SmjestajId = r.SmjestajId;
            m.DatumZahtjeva = DateTime.Now.Date;
            m.Prioritet = model.Prioritet;
            m.Obavljen = false;

            db.ZahtjevZaCiscenjem.Add(m);
            db.SaveChanges();


            return RedirectToAction("Index","CheckIN");
        }
    }
}