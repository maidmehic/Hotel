using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class NoviZaposlenikVM
    {
        public int Id { set; get; }
        public string Ime { set; get; }
        public string Prezime { set; get; }
        public DateTime DatumRodjenja { set; get; }
        public string Telefon { set; get; }
        public string BracniStatus { set; get; }
        public string Email { set; get; }
        public string BrojUgovora { set; get; }
        public DateTime DatumZaposljenja { set; get; }
        public string JMBG { set; get; }
        public string Spol { set; get; }
        public bool Aktivan { set; get; }
        public bool isAdministrator { set; get; }
        public bool isRecepcioner { set; get; }
        public bool isCistacica { set; get; }
        public bool isKuhar { set; get; }
        public int GradId { get; set; }
        public IEnumerable<SelectListItem> gradoviStavke { set; get; }
        public IEnumerable<SelectListItem> spoloviStavke { set; get; }
        public IEnumerable<SelectListItem> brakStavke { set; get; }
       
    }
}
