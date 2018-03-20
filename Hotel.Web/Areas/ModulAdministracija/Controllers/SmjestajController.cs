using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web.Areas.ModulAdministracija.ViewModels;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel.Web.Areas.ModulAdministracija.Controllers
{
    [Area("ModulAdministracija")]
    public class SmjestajController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult PrikaziSmjestaj( int ? BrojPretraga, int ? StatusPretraga)
        {
            PrikazSmjestajaVM Model = new PrikazSmjestajaVM();
            Model.Smjestaji = db.Smjestaj.Include(x=>x.VrstaSmjestaja).
                Where(x=>((x.BrojSmjestaja == BrojPretraga) && ((x.Zauzeto == true && StatusPretraga == 2)||!StatusPretraga.HasValue))||
                ((x.BrojSmjestaja == BrojPretraga) && ((x.Zauzeto == false && StatusPretraga == 1) || !StatusPretraga.HasValue)) ||
                (!BrojPretraga.HasValue)&& (x.Zauzeto == false && StatusPretraga == 1)||
                (!BrojPretraga.HasValue) && (x.Zauzeto == true && StatusPretraga == 2) ||
                (!BrojPretraga.HasValue) && (!StatusPretraga.HasValue))
                .ToList();
            Model.BrojPretraga = null;
            return View(Model);
        }
        public IActionResult DodajSmjestaj()
        {
            NoviSmjestajVM Model = new NoviSmjestajVM();
            Model.Zauzeto = false;
            List<SelectListItem> _stavke = new List<SelectListItem>();
            _stavke.Add(new SelectListItem
            {
                Value = null,
                Text = "Odaberite vrstu"
            });
            _stavke.AddRange(db.VrstaSmjestaja.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }));
            Model._vrstaStavke = _stavke;
            return View(Model);
        }
        public IActionResult Snimi(NoviSmjestajVM s)
        {
            Smjestaj temp;
            if (s.Id == 0)
            {
                temp = new Smjestaj();
                db.Smjestaj.Add(temp);
            }
            else
            {
                temp = db.Smjestaj.Find(s.Id);
            }

            temp.BrojSmjestaja = s.BrojSmjestaja;
            temp.Sprat = s.Sprat;
            temp.BrojKreveta = s.BrojKreveta;
            temp.Kvadratura = s.Kvadratura;
            temp.Zauzeto = s.Zauzeto;
            temp.Cijena = s.Cijena;
            temp.VrstaSmjestajaId = s.VrstaSmjestajaId;
            db.SaveChanges();
            return RedirectToAction("PrikaziSmjestaj");
        }
        public IActionResult Uredi(int id)
        {
            NoviSmjestajVM Model = new NoviSmjestajVM();
            Smjestaj s = new Smjestaj();
            s = db.Smjestaj.Find(id);
            Model.Id = s.Id;
            Model.BrojSmjestaja = s.BrojSmjestaja;
            Model.BrojKreveta = s.BrojKreveta;
            Model.Kvadratura = s.Kvadratura;
            Model.Sprat = s.Sprat;
            Model.VrstaSmjestajaId = s.VrstaSmjestajaId;
            Model.Zauzeto = s.Zauzeto;
            Model.Cijena = s.Cijena;
            List<SelectListItem> _stavke = new List<SelectListItem>();
            _stavke.Add(new SelectListItem
            {
                Value = null,
                Text = "Odaberite vrstu"
            });
            _stavke.AddRange(db.VrstaSmjestaja.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }));
            Model._vrstaStavke = _stavke;
            return View(Model);
        }
    }
}