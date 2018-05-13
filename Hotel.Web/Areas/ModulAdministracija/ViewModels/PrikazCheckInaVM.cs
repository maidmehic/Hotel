using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class PrikazCheckInaVM
    {
        public List<CheckIN> CheckINi { get; set; }
        
        public DateTime? Od { get; set; }
        public DateTime? Do { get; set; }
        public int ? StatusPretraga { get; set; }
        public IEnumerable<SelectListItem> statusRezervacije
        {
            get
            {
                List<SelectListItem> stavke = new List<SelectListItem>();
                stavke.Add(new SelectListItem()
                {
                    Value=null,
                    Text="Sve"
                });
                stavke.Add(new SelectListItem()
                {
                    Value = 1.ToString(),
                    Text = "Aktivne"
                });
                stavke.Add(new SelectListItem()
                {
                    Value = 2.ToString(),
                    Text = "Završene"
                });
                return stavke;
            }
        }
    }
}
