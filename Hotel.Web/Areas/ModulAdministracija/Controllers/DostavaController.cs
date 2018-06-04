using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Hotel.Web.Areas.ModulAdministracija.ViewModels;
using Hotel.Web.Helper;

namespace Hotel.Web.Areas.ModulAdministracija.Controllers
{
    [Area("ModulAdministracija")]
    public class DostavaController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult PrikaziDostave(int? StanjeOdabir)
        {

            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }
            PrikaziDostaveVM Model = new PrikaziDostaveVM();

            Model.Dostave = db.Dostava.Include(x => x.RezervisanSmjestaj).Include(x => x.RezervisanSmjestaj.CheckIN).Include(x => x.RezervisanSmjestaj.CheckIN.Gost).Include(x => x.RezervisanSmjestaj.Smjestaj).OrderByDescending(x=>x.Datum).ToList();
           

            //vidjeti jel treba raditi order po datumu

            if (StanjeOdabir == 1)
                Model.Dostave = db.Dostava.Include(x => x.RezervisanSmjestaj).Include(x => x.RezervisanSmjestaj.CheckIN).Include(x => x.RezervisanSmjestaj.CheckIN.Gost).Include(x => x.RezervisanSmjestaj.Smjestaj).Where(x => x.Zavrsena == false).OrderByDescending(x => x.Datum).ToList();

            if (StanjeOdabir == 2)
                Model.Dostave = db.Dostava.Include(x => x.RezervisanSmjestaj).Include(x => x.RezervisanSmjestaj.CheckIN).Include(x => x.RezervisanSmjestaj.CheckIN.Gost).Include(x => x.RezervisanSmjestaj.Smjestaj).Where(x => x.Zavrsena == true).OrderByDescending(x => x.Datum).ToList();
            return View(Model);
        }


        public IActionResult PrikaziStavkeZaDostavu(int DostavaId)
        {

            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }
            PrikaziStavkeDostaveVM Model = new PrikaziStavkeDostaveVM();
            Model.StavkeDostave = db.DostavaStavke.Include(x => x.Proizvod).Include(x => x.Dostava).Where(x => x.DostavaId == DostavaId).ToList();
            return View(Model);
        }
    }
}