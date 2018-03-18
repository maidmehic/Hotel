﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRecepcija.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.ModulRecepcija.Controllers
{
    [Area("ModulRecepcija")]
    public class TipUslugeController : Controller
    {
        MojContext db = new MojContext();
        public IActionResult Index()
        {
            TipUslugeIndexVM model = new TipUslugeIndexVM();

            model.TipoviUsluga = db.TipUsluge.Select(x => new TipUslugeIndexVM.Row {
                Naziv = x.Naziv,
                Cijena=x.Cijena,
                Id=x.Id


            }).ToList();




            return View(model);
        }
        public IActionResult Dodaj()
        {
            TipUslugeDodajVM model = new TipUslugeDodajVM();

           

            return View(model);
        }
        [HttpPost]
        public IActionResult Dodaj(TipUslugeDodajVM model)
        {
            TipUsluge t = new TipUsluge();

            t.Naziv = model.Naziv;
            t.Cijena = model.Cijena;

            db.TipUsluge.Add(t);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}