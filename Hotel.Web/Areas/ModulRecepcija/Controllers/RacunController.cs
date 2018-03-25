using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.ModulRecepcija.Controllers
{
    [Area("ModulRecepcija")]
    public class RacunController : Controller
    {
        MojContext db = new MojContext(); 
        public IActionResult Index()
        {
            return View();
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

            //PosaljiZahtjevZaCiscenjem(c);

            return RedirectToAction("Index");
        }
        //public IActionResult PosaljiZahtjevZaCiscenjem(CheckIN c)
        //{
        //    //return RedirectToAction(Dodaj"" zahtjev za ciscenjem itd)
        //}
    }
}