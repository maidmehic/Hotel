using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotel.Web.Areas.ModulAdministracija.ViewModels;

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
            NovaPogodnostVM Model = new NovaPogodnostVM();
            return View(Model);
        }
        public IActionResult Snimi(NovaPogodnostVM temp)
        {
            if (!ModelState.IsValid)
            {
                //return View("Uredi", temp.Id);

                return View("Dodaj", temp);
            }
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
            NovaPogodnostVM Model = new NovaPogodnostVM();
            Pogodnost p = new Pogodnost();
            p = db.Pogodnost.Find(id);

            Model.Id = p.Id;
            Model.Opis = p.Opis;
            return View(Model);
        }
        
        public IActionResult ProvjeriDuplikate(string Opis, int Id)
        {
            if (db.Pogodnost.Any(x => x.Opis == Opis && x.Id != Id))
                return Json("Pogodnost je već dodana!");
            return Json(true);
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
            NovaPogodnostZaSmjestajVM Model = new NovaPogodnostZaSmjestajVM();
            
            Model.smjestajID = smjestajID;
            NapuniCmb(Model);
            
            return View(Model);
        }
        void NapuniCmb(NovaPogodnostZaSmjestajVM p)
        {
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
            p._stavke = _stavke;

        }
        public IActionResult ProvjeriStavkuPogodnosti(int? StavkaPogodnosti, int smjestajID)
        {
            if (StavkaPogodnosti == null)
                return Json("Odaberite pogodnost!");

            if(db.PogodnostiSmjestaja.Any(x=>x.SmjestajId==smjestajID && x.PogodnostId==StavkaPogodnosti))
                return Json("Pogodnost je već odabrana!");

            return Json(true);
        }
        

        public IActionResult SnimiPogodnostZaSmjestaj(NovaPogodnostZaSmjestajVM p)
        {
            if (!ModelState.IsValid)
            {
                NapuniCmb(p);
                return View("DodajPogodnostZaSmjestaj", p);
            }

            PogodnostiSmjestaja ps = new PogodnostiSmjestaja();
            ps.PogodnostId = p.StavkaPogodnosti;
            ps.SmjestajId = p.smjestajID;
            db.PogodnostiSmjestaja.Add(ps);
            db.SaveChanges();
            return RedirectToAction("PrikaziPogodnostiZaSmjestaj",new {id=p.smjestajID });
        }
    }
    //
}