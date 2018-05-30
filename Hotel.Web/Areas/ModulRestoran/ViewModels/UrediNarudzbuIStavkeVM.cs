using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRestoran.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRestoran.ViewModels
{
    public class UrediNarudzbuIStavkeVM
    {
        // Podaci za narudzbu //
        public int Id { set; get; }
        public DateTime DatumKreiranja { get; set; }
        public string Opis { get; set; }
        public bool Zavrsena { set; get; }
        public bool Otkazana { set; get; }
        [Remote(action: nameof(NarudzbaController.ProvjeriHitnost), controller: "Narudzba")]
        public string Hitnost { get; set; }
        public int ZaposlenikId { set; get; }
        public IEnumerable<SelectListItem> HitnostStavke
        {
            get
            {
                List<SelectListItem> _stavke = new List<SelectListItem>();
                _stavke.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite hitnost"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = "Visoka",
                    Text = "Visoka"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = "Srednja",
                    Text = "Srednja"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = "Niska",
                    Text = "Niska"
                });
                return _stavke;
            }
        }
        
        // Prikazivanje vec dodanih stavki za narudzbu i dodavanje novih stavki //
        public PrikaziStavkeVM StavkeNarudzbe { set; get; }
    }
}
