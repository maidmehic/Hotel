using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web.Areas.ModulAdministracija.ViewModels;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Web.Areas.ModulAdministracija.Controllers
{
    [Area("ModulAdministracija")]
    public class CheckInController : Controller
    {
        MojContext db = new MojContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PrikaziCheckIne(DateTime? Od,DateTime? Do,int ? StatusPretraga)
        {
            PrikazCheckInaVM Model = new PrikazCheckInaVM();

            if (!StatusPretraga.HasValue) {
                Model.CheckINi = db.CheckIN.
                   Include(x => x.Gost).
                   Include(x => x.Zaposlenik).
                   Include(x => x.TipUsluge).
                   Where(x => (x.DatumDolaska >= Od && x.DatumDolaska <= Do) || (x.DatumDolaska >= Od && Do == null) || (Od == null && x.DatumDolaska <= Do) || (Od == null && Do == null))
                   .ToList();
            }
            if (StatusPretraga == 1)
            {
                Model.CheckINi = db.CheckIN.
                   Include(x => x.Gost).
                   Include(x => x.Zaposlenik).
                   Include(x => x.TipUsluge).
                   Where(x => (x.DatumDolaska >= Od && x.DatumDolaska <= Do && x.DatumOdlaska>=DateTime.Now) || (x.DatumDolaska >= Od && Do == null && x.DatumOdlaska >= DateTime.Now) || (Od == null && x.DatumDolaska <= Do && x.DatumOdlaska >= DateTime.Now) || (Od == null && Do == null && x.DatumOdlaska >= DateTime.Now))
                   .ToList();
            }
            if (StatusPretraga == 2)
            {
                Model.CheckINi = db.CheckIN.
                   Include(x => x.Gost).
                   Include(x => x.Zaposlenik).
                   Include(x => x.TipUsluge).
                   Where(x => (x.DatumDolaska >= Od && x.DatumDolaska <= Do && x.DatumOdlaska < DateTime.Now) || (x.DatumDolaska >= Od && Do == null && x.DatumOdlaska < DateTime.Now) || (Od == null && x.DatumDolaska <= Do && x.DatumOdlaska < DateTime.Now) || (Od == null && Do == null && x.DatumOdlaska < DateTime.Now))
                   .ToList();
            }
            return View(Model);
        }

        public IActionResult PrikaziDetaljeZaCheckIN(int id)
        {
            PrikazDetaljaZaCheckINVM Model = new PrikazDetaljaZaCheckINVM();
            Model.RezervisanSmjestaj = db.RezervisanSmjestaj.
                Include(x => x.Gost).
                Include(x => x.Smjestaj).
                Include(x => x.Smjestaj.VrstaSmjestaja).Where(x => x.CheckINId == id).ToList();


            Model.BrojGostiju = db.RezervisanSmjestaj.Where(x => x.CheckINId == id).Count();
            //  Model.BrojRezSmjestaja (HOCU DA POBROJIM REZ SMJESTAJ)


            Model.RezervisaneUsluge = db.RezervisanaUsluga.Include(x => x.UslugeHotela).Where(x => x.CheckINId == id).ToList();

            return View(Model);
        }
    }
}