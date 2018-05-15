using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRecepcija.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.ModulRecepcija.Controllers
{
    [Area("ModulRecepcija")]
    public class FeedbackController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            FeedbackIndexVM model = new FeedbackIndexVM();

            model.feedbaci = db.Feedback.Select(x => new FeedbackIndexVM.Row
            {
                Sadrzaj=x.Sadrzaj,
                Gost=x.CheckIN.Gost.Ime + x.CheckIN.Gost.Prezime,
                CheckINId=x.CheckINId,
                CheckIN="Boravio u:"+x.CheckIN.TipUsluge.Naziv +" "+x.CheckIN.TipUsluge.Cijena + "KM// OD:"+x.CheckIN.DatumDolaska +"-DO:"+ x.CheckIN.DatumOdlaska
                
            }).ToList();
            return View(model);
        }

        

        public IActionResult Dodaj(int CheckINId,int GostID)
        {
            FeedbackDodajVM model = new FeedbackDodajVM();

            model.CheckINId = CheckINId;
            model.GostId = GostID;


            return PartialView(model);
        }
        [HttpPost]
        public IActionResult Dodaj(FeedbackDodajVM model)
        {

            if(!ModelState.IsValid)
            {
                return View("Dodaj", model);
            }
            Feedback f = new Feedback();



            f.CheckINId = model.CheckINId;
            f.GostId = model.GostId;

            f.Sadrzaj = model.Sadrzaj;

            db.Feedback.Add(f);
            db.SaveChanges();
            return RedirectToAction("Index","CheckIN");
        }

    }
}