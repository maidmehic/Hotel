using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel.Web.Areas.ModulAdministracija.Controllers
{
    [Area("ModulAdministracija")]
    public class PogodnostController : Controller
    {
        MojContext db = new MojContext();
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Prikazi()
        {
            List<Pogodnost> pogodnosti = new List<Pogodnost>();
            pogodnosti = db.Pogodnost.ToList();
            ViewData["pogodnosti"] = pogodnosti;
            return View();
        }
        public IActionResult Dodaj()
        {
            return View();
        }
        public IActionResult Snimi(Pogodnost temp)
        {
            Pogodnost p;
            if (temp.Id == 0)
            {
                p = new Pogodnost();
                db.Pogodnost.Add(p);
            }
            else
            {
                p = db.Pogodnost.Find(temp.Id);
            }

            p.Opis = temp.Opis;
            db.SaveChanges();

            return RedirectToAction("Prikazi");
        }
        public IActionResult Obrisi(int id)
        {
            Pogodnost p = db.Pogodnost.Find(id);
            db.Pogodnost.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Prikazi");
        }
        public IActionResult Uredi(int id)
        {
            Pogodnost p = new Pogodnost();
            p = db.Pogodnost.Find(id);
            ViewData["p"] = p;
            return View();
        }



        //tabela "PogodnostiSmjestaja"
        public IActionResult PrikaziPogodnostiZaSmjestaj(int id)
        {
            ViewData["smjestajID"] = id;
            List<PogodnostiSmjestaja> p = new List<PogodnostiSmjestaja>();
            p = db.PogodnostiSmjestaja.Include(x => x.Smjestaj).Include(x => x.Pogodnost).
                Where(x => x.SmjestajId == id).ToList();

            ViewData["p"] = p;
            return View();
        }
        public IActionResult ObrisiPogodnostZaSmjestaj(int id)
        {
            PogodnostiSmjestaja p = new PogodnostiSmjestaja();
            p = db.PogodnostiSmjestaja.Find(id);
            int smjestajID = new int();
            smjestajID = p.SmjestajId;
            db.PogodnostiSmjestaja.Remove(p);
            db.SaveChanges();
            return RedirectToAction("PrikaziPogodnostiZaSmjestaj",new {id= smjestajID });
        }
        public IActionResult DodajPogodnostZaSmjestaj(int smjestajID)
        {
            ViewData["smjestajID"] = smjestajID;
            List<SelectListItem> _stavke = new List<SelectListItem>();
            _stavke.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite pogodnost"
            });
            _stavke.AddRange(db.Pogodnost.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Opis
            }));
            IEnumerable<SelectListItem> PogodnostiStavke=_stavke;
            ViewData["PogodnostiStavke"] = PogodnostiStavke;
            return View();
        }
        public IActionResult SnimiPogodnostZaSmjestaj(int smjestajID, int StavkaPogodnosti)
        {
            PogodnostiSmjestaja ps = new PogodnostiSmjestaja();
            ps.PogodnostId = StavkaPogodnosti;
            ps.SmjestajId = smjestajID;
            db.PogodnostiSmjestaja.Add(ps);
            db.SaveChanges();
            return RedirectToAction("PrikaziPogodnostiZaSmjestaj",new {id=smjestajID });
        }
    }
}