using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRecepcija.Controllers;
using Hotel.Web.Areas.ModulRecepcija.ViewModels;
using Hotel.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Web.Areas.ModulOdrzavanje.Controllers
{
    [Area("ModulOdrzavanje")]
    public class ZahtjevZaCiscenjemController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isCistacica == false)
            {
                TempData["error_poruka"] = "nemate pravo pristupa";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });

            }

            ZahtjevZaCiscenjemIndexVM model = new ZahtjevZaCiscenjemIndexVM();

            
            model.zahtjevi = db.ZahtjevZaCiscenjem.Select(x => new ZahtjevZaCiscenjemIndexVM.Row
            {
                Id = x.Id,
                DatumZahtjeva = x.DatumZahtjeva.ToShortDateString(),
                Opis = x.Opis,
                Prioritet = x.Prioritet,
                Obavljen = x.Obavljen,
                Smjestaj = x.Smjestaj.BrojSmjestaja + " " + x.Smjestaj.Sprat + " " + x.Smjestaj.VrstaSmjestaja.Naziv,              
                Zaposlenik = x.Zaposlenik.Ime + " " + x.Zaposlenik.Prezime
                


            }).ToList();
           
          
            return View(model);
        }
        public IActionResult OznaciObavljenim(int ZahtjevId)
        {
            ZahtjevZaCiscenjem z = new ZahtjevZaCiscenjem();
            Zaposlenik zz = HttpContext.GetLogiraniKorisnik();

            z = db.ZahtjevZaCiscenjem.Where(x => x.Id == ZahtjevId).FirstOrDefault();
            z.ZaposlenikId = zz.Id;
            z.Obavljen = true;

          

            db.ZahtjevZaCiscenjem.Update(z);
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

            RezervisanSmjestaj r = db.RezervisanSmjestaj.Where(x => x.CheckINId == model.CheckInId).FirstOrDefault();

            m.Opis = model.Opis;
            m.SmjestajId = r.SmjestajId;
            m.DatumZahtjeva = DateTime.Now.Date;
            m.Prioritet = model.Prioritet;
            m.Obavljen = false;

            db.ZahtjevZaCiscenjem.Add(m);
            db.SaveChanges();


            return RedirectToAction("Index","CheckIN",new { area="ModulRecepcija"});
        }
    }
}