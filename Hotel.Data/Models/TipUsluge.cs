﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class TipUsluge
    {
        public int Id { set; get; }
        public string Naziv { set; get; }
        // vise check in-a

        public virtual List<CheckIN> CheckIN { get; set; }

    }
}
