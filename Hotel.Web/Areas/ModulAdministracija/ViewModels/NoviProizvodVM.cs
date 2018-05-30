using Hotel.Web.Areas.ModulAdministracija.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class NoviProizvodVM
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Naziv je obavezan!")]
        public string Naziv { set; get; }

        [Required(ErrorMessage = "Cijena je obavezna!")]
        [Range(0.1, float.MaxValue, ErrorMessage = "Cijena mora biti veća od 0.")]
        public float? Cijena { set; get; }

        [Remote(action: nameof(ProizvodController.ProvjeriVrstu), controller: "Proizvod")]
        public string Vrsta { set; get; }

        public float Kolicina { set; get; }

        [Remote(action: nameof(ProizvodController.ProvjeriMjernuJedinicu), controller: "Proizvod")]
        public string MjernaJedinica { set; get; }

        public IEnumerable<SelectListItem> VrstaStavke
        {
            get
            {
                List<SelectListItem> _stavke = new List<SelectListItem>();
                _stavke.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite vrstu"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = "Hrana",
                    Text = "Hrana"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = "Pića",
                    Text = "Pića"
                });

                return _stavke;
            }
        }
        public IEnumerable<SelectListItem> MjernaJedinicaStavke
        {
            get
            {
                List<SelectListItem> _stavke = new List<SelectListItem>();
                _stavke.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Mjerna jednica"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = "kom",
                    Text = "kom"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = "kilogram",
                    Text = "kilogram"
                });

                return _stavke;
            }
        }
    }
}
