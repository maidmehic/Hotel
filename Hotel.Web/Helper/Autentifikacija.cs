using Hotel.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Helper
{
    public static class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        public static void SetLogiraniKorisnik(this HttpContext context, Zaposlenik zaposlenik)
        {
            context.Session.SetObjectAsJson(LogiraniKorisnik,zaposlenik);
        }

        public static Zaposlenik GetLogiraniKorisnik(this HttpContext context)
        {
            Zaposlenik zaposlenik = context.Session.GetObjectFromJson<Zaposlenik>(LogiraniKorisnik);
            if (zaposlenik == null)
            {
                context.Session.SetObjectAsJson(LogiraniKorisnik, zaposlenik);
            }
            return zaposlenik;
        }
    }
}
