using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class HistorijaIzdavanjaVM
    {
        public List<RezervisanSmjestaj> RezervacijeZaSmjestaj { get; set; }
        public List<Feedback> FeedbaciZaSmjestaj { get; set; }
        public DateTime CheckInDatum { set; get; }
        public DateTime CheckOutDatum { set; get; }
        public int id { get; set; }
    }
}
