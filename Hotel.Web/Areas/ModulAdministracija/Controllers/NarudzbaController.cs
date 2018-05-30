using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulAdministracija.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Web.Areas.ModulAdministracija.Controllers
{
    [Area("ModulAdministracija")]
    public class NarudzbaController : Controller
    {
        MojContext db = new MojContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PrikaziNarudzbe( int ? StanjeOdabir)
        {
            PrikazNarudzbiVM Model = new PrikazNarudzbiVM();

            if (StanjeOdabir == null)
               Model.Narudzbe = db.Narudzba.Include(x=>x.Zaposlenik).OrderByDescending(x=>x.DatumKreiranja).ToList();

            if (StanjeOdabir == 1)
                Model.Narudzbe = db.Narudzba.Include(x => x.Zaposlenik).Where(x=>x.Zavrsena==false && x.Otkazana==false).OrderByDescending(x => x.DatumKreiranja).ToList();

            if (StanjeOdabir == 2)
                Model.Narudzbe = db.Narudzba.Include(x => x.Zaposlenik).Where(x => x.Zavrsena == true).OrderByDescending(x => x.DatumKreiranja).ToList();

            if (StanjeOdabir == 3)
                Model.Narudzbe = db.Narudzba.Include(x => x.Zaposlenik).Where(x => x.Otkazana == true).OrderByDescending(x => x.DatumKreiranja).ToList();

            return View(Model);
        }

        public IActionResult PrikaziStavkeNarudzbe(int Id)
        {
            PrikazStavkiNarudzbeVM Model = new PrikazStavkiNarudzbeVM();
            Model.Stavke = db.Stavke.Include(x=>x.Proizvodi).Where(x => x.NarudzbaId == Id).ToList();
            return View(Model);
        }

    }
}