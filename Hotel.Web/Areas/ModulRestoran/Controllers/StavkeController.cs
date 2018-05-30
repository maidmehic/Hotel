using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web.Areas.ModulRestoran.ViewModels;
using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Web.Areas.ModulRestoran.Controllers
{
    [Area("ModulRestoran")]
    public class StavkeController : Controller
    {
        MojContext db = new MojContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DodavanjeStavki()
        {
            PrikaziNarudzbuDodajProizvodeVM Model = new PrikaziNarudzbuDodajProizvodeVM();

            Model.Narudzba = db.Narudzba.Include(x => x.Zaposlenik).Last();
            Model.NarudzbaId = db.Narudzba.Include(x => x.Zaposlenik).Last().Id;

            List<SelectListItem> _stavke = new List<SelectListItem>();
            _stavke.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite proizvod"
            });

            _stavke.AddRange(db.Proizvod.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }));
            Model.ProizvodiStavke = _stavke;

            return View(Model);
        }

        public IActionResult SnimiStavku(PrikaziNarudzbuDodajProizvodeVM s)
        {
            
            if (!ModelState.IsValid)
            {
                return View("DodavanjeStavki", s);
            }

            if (db.Stavke.Where(x => (x.NarudzbaId == s.NarudzbaId) && (x.ProizvodId == s.ProizvodId)).Any())
            {
                return View("DodavanjeStavki", s); //PITATI ADILA KAKO DA SE VRATI PORUKA O GRESCI
            }



            Stavke temp;

            if (s.Id == 0)
            {
                temp = new Stavke();
                db.Stavke.Add(temp);
            }
            else
            {
                temp = db.Stavke.Find(s.Id);
            }

            temp.Kolicina = s.Kolicina ?? 0;
            temp.NarudzbaId = s.NarudzbaId;
            temp.ProizvodId = s.ProizvodId;
            db.SaveChanges();
            return RedirectToAction("PrikaziStavke", new { id = temp.NarudzbaId });
        }

        public IActionResult PrikaziStavke(int id)
        {
            PrikaziStavkeVM Model = new PrikaziStavkeVM();
            Model.Stavke = db.Stavke.Include(x => x.Narudzba).Include(x => x.Proizvodi).Where(x => x.NarudzbaId == id).ToList();

            return View(Model);
        }
        public IActionResult FinalizirajNarudzbu(int NarudzbaId)
        {
            foreach (Proizvodi p in db.Proizvod.ToList())
            {
                foreach (Stavke s in db.Stavke.Where(x => x.NarudzbaId == NarudzbaId).ToList())
                {
                    if (p.Id == s.ProizvodId)
                    {
                        p.Kolicina = p.Kolicina + s.Kolicina;
                    }
                }
            }
            Narudzba n= db.Narudzba.Where(x => x.Id == NarudzbaId).FirstOrDefault();
            n.Zavrsena = true;
            db.SaveChanges();
            return RedirectToAction("PrikaziZalihe", "Proizvod");
        }

        public IActionResult ProvjeriDupluStavku(int ProizvodId,int NarudzbaId)
        {
            if (db.Stavke.Where(x => x.NarudzbaId == NarudzbaId && x.ProizvodId == ProizvodId).Any())
                return Json("Proizvod je već unesen.");
            return Json(true);
        }

        public IActionResult ObrisiStavku(int Id)
        {
            Stavke s = db.Stavke.Find(Id);
            db.Stavke.Remove(s);
            db.SaveChanges();
            return RedirectToAction("PrikaziStavke", new { id = s.NarudzbaId });
        }
    }
}