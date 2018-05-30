using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web.Areas.ModulRestoran.ViewModels;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Web.Areas.ModulRestoran.Controllers
{
    [Area("ModulRestoran")]
    public class DostavaController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult PrikaziDostave(int ? StanjeOdabir, string poruka)
        {
            PrikaziDostaveVM Model = new PrikaziDostaveVM();

            Model.Dostave = db.Dostava.Include(x => x.RezervisanSmjestaj).Include(x => x.RezervisanSmjestaj.CheckIN).Include(x => x.RezervisanSmjestaj.CheckIN.Gost).Include(x => x.RezervisanSmjestaj.Smjestaj).Where(x=>x.Zavrsena==false).ToList();
            ViewBag.Poruka = poruka;

            //vidjeti jel treba raditi order po datumu

            if (StanjeOdabir == 1)
                Model.Dostave = db.Dostava.Include(x => x.RezervisanSmjestaj).Include(x => x.RezervisanSmjestaj.CheckIN).Include(x => x.RezervisanSmjestaj.CheckIN.Gost).Include(x => x.RezervisanSmjestaj.Smjestaj).ToList();

            if(StanjeOdabir==2)
                Model.Dostave = db.Dostava.Include(x => x.RezervisanSmjestaj).Include(x => x.RezervisanSmjestaj.CheckIN).Include(x => x.RezervisanSmjestaj.CheckIN.Gost).Include(x => x.RezervisanSmjestaj.Smjestaj).Where(x=>x.Zavrsena==true).ToList();
            return View(Model);
        }
    }
    
}