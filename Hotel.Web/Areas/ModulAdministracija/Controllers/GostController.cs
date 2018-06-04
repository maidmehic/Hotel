using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulAdministracija.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotel.Web.Helper;

namespace Hotel.Web.Areas.ModulAdministracija.Controllers
{
    [Area("ModulAdministracija")]
    public class GostController : Controller
    {
        MojContext db = new MojContext();

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult PrikaziGoste(string ImePrezimePretraga,int? PretragaGrad)
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }
            PrikazGostijuVM Model = new PrikazGostijuVM();

            Model.Gosti = db.Gost.Include(x=>x.Grad).
                Include(x=>x.Grad.Drzava).
                Where(x=>(x.GradId==PretragaGrad)&&((x.Ime+" "+x.Prezime).Contains(ImePrezimePretraga) || ImePrezimePretraga==null)||
                         (!PretragaGrad.HasValue)&&((x.Ime + " " + x.Prezime).Contains(ImePrezimePretraga) || ImePrezimePretraga == null)).
                ToList();

            List<SelectListItem> gradoviStavke = new List<SelectListItem>();
            gradoviStavke.Add(new SelectListItem()
            {
                Value=null,
                Text="Svi gradovi"
            });
            gradoviStavke.AddRange(db.Grad.Select(x => new SelectListItem()
            {
                Value=x.Id.ToString(),
                Text=x.Naziv
            }));
            Model.GradoviStavke = gradoviStavke;

            return View(Model);
        }

        public IActionResult PrikaziDetaljeGosta(int gostId)
        {

            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isAdministrator == false)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa.";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });
            }

            PrikazDetaljaZaGostaVM Model = new PrikazDetaljaZaGostaVM();

            Model.RezervisaniSmjestaji = db.RezervisanSmjestaj.
                Include(x=>x.Smjestaj).
                Include(x=>x.Smjestaj.VrstaSmjestaja).
                Include(x=>x.CheckIN).
                Include(x=>x.CheckIN.Gost).
                Include(x=>x.CheckIN.Zaposlenik).
                Include(x=>x.CheckIN.TipUsluge)
                .Where(x => x.GostId == gostId).ToList();

            return View(Model);
        }
    }
}