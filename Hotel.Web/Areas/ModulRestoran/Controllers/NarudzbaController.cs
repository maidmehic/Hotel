using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web.Areas.ModulRestoran.ViewModels;
using Hotel.Web.Helper;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel.Web.Areas.ModulRestoran.Controllers
{
    [Area("ModulRestoran")]
    public class NarudzbaController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NovaNarudzba()
        {
            DodajNarudzbuVM Model = new DodajNarudzbuVM();
            Model.DatumKreiranja = DateTime.Now;
            Model.ZaposlenikId = HttpContext.GetLogiraniKorisnik().Id;

            return View(Model);
        }
        public IActionResult Snimi(DodajNarudzbuVM n)
        {
            Narudzba temp;
            if (n.Id == 0)
            {
                temp = new Narudzba();
                db.Narudzba.Add(temp);
            }
            else
            {
                temp = db.Narudzba.Find(n.Id);
            }
            temp.Hitnost = n.Hitnost;
            temp.Opis = n.Opis;
            temp.ZaposlenikId = n.ZaposlenikId;
            temp.DatumKreiranja = n.DatumKreiranja;
            db.SaveChanges();
            return RedirectToAction("DodavanjeStavki");
        }
        public IActionResult DodavanjeStavki()
        {
            PrikaziNarudzbuDodajProizvodeVM Model = new PrikaziNarudzbuDodajProizvodeVM();

            Model.Narudzba = db.Narudzba.Include(x=>x.Zaposlenik).Last();
            Model.NarudzbaId = db.Narudzba.Include(x=>x.Zaposlenik).Last().Id;

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

            temp.Kolicina = s.Kolicina ??0;
            temp.NarudzbaId = s.NarudzbaId;
            temp.ProizvodId = s.ProizvodId;
            db.SaveChanges();
            return RedirectToAction("PrikaziStavke",new { id=temp.NarudzbaId });
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
                foreach (Stavke s in db.Stavke.Where(x=>x.NarudzbaId==NarudzbaId).ToList())
                {
                    if (p.Id == s.ProizvodId)
                    {
                        p.Kolicina = p.Kolicina + s.Kolicina;
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction("PrikaziZalihe", "Proizvod");
        }
    }
}