using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web.Areas.ModulRestoran.ViewModels;
using Hotel.Data.Models;

namespace Hotel.Web.Areas.ModulRestoran.Controllers
{
    [Area("ModulRestoran")]
    public class ProizvodController : Controller
    {
       
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult PrikaziZalihe(string NazivPretraga, int? VrstaOdabir)
        {
            bool greska = false;
            foreach(Proizvodi p in db.Proizvod.ToList())
            {
                if (p.Kolicina <= 20)
                {
                    greska=true;
                }
            }
            if (greska == true)
            {
                ViewBag.Poruka = "Zalihe nekih proizvoda su pri kraju. Molimo izvršite narudžbu"; //Ovdje mozda nekako prikazati i koji su to proizvodi
            }


            PrikaziZaliheVM Model = new PrikaziZaliheVM();

            if(VrstaOdabir==null)
                Model.Proizvodi = db.Proizvod.Where(x=>x.Naziv.Contains(NazivPretraga) || NazivPretraga==null).ToList();

            if(VrstaOdabir==1)
                Model.Proizvodi = db.Proizvod.Where(x =>x.Vrsta=="Hrana" && (x.Naziv.Contains(NazivPretraga) || NazivPretraga == null)).ToList();
            
            if (VrstaOdabir == 2)
                Model.Proizvodi = db.Proizvod.Where(x =>(x.Naziv.Contains(NazivPretraga) || NazivPretraga == null)&& x.Vrsta == "Pića").ToList();
            

            return View(Model);
        }

        
    }
}