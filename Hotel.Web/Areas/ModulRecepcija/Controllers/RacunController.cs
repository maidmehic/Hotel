using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRecepcija.ViewModels;
using Hotel.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Hotel.Web.Areas.ModulRecepcija.Controllers
{
    [Area("ModulRecepcija")]
    public class RacunController : Controller
    {
        MojContext db = new MojContext(); 
        public IActionResult Index()
        {
            Zaposlenik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.isRecepcioner == false)
            {
                TempData["error_poruka"] = "nemate pravo pristupa";
                return RedirectToAction("Index", "Autentifikacija", new { area = " " });

            }
            RacunIndexVM model = new RacunIndexVM();
            model.racuni = db.Racun.Select(x => new RacunIndexVM.Row
            {
                CheckIN = x.CheckIN.BrojDjece + "--" + x.CheckIN.BrojOdraslih + "  /" + x.CheckIN.DatumDolaska.ToShortDateString() + "-" + ((x.CheckIN.DatumOdlaska == null) ? "-" : (DateTime.Parse(x.CheckIN.DatumOdlaska.ToString()).ToShortDateString())),
                DatumIzdavanja = x.DatumIzdavanja,
                Suma = x.Suma,
                Gost = x.Gost.Ime +" "+ x.Gost.Prezime

            }).ToList();


            return View(model);
        }
        public IActionResult Dodaj(int CheckInId,double suma)
        {
            CheckIN c = new CheckIN();

            c = db.CheckIN.Where(x => x.Id == CheckInId).FirstOrDefault();

            Racun r = new Racun();

            r.CheckINId = CheckInId;
            r.GostId = c.GostId;
            r.Suma = suma;
            r.DatumIzdavanja = DateTime.Now.Date;

            db.Racun.Add(r);
            db.SaveChanges();



            //TempData["msg"] = "<script>alert('Change succesfully');</script>";

            return RedirectToAction("Index");
        }
      
    }
}