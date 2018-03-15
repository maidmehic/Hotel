using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class PrikazUslugeHotelaVM
    {
        public class Rows
        {
            public UslugeHotela usluga { set; get; }
            public bool Aktivna { set; get; }
        }
        public List<Rows> uslugeHotela { set; get; }
        public string PretragaNaziv { set; get; }

        public int PretragaAktivnostId { set; get; }
        public IEnumerable<SelectListItem> StavkePretragaAktivnost { get
            {
                List<SelectListItem> _stavke = new List<SelectListItem>();
                _stavke.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Sve"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = 1.ToString(),
                    Text = "Aktivne"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = 2.ToString(),
                    Text = "Istekle"
                });


                return _stavke;
            } }
    }
}
