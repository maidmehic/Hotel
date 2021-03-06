﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class RezervisanaUsluga
    {
        public int Id { set; get; }     
        // jedna uslugahotela
        public int UslugeHotelaId { get; set; }
        [ForeignKey(nameof(UslugeHotelaId))]
        public virtual UslugeHotela UslugeHotela { get; set; }
        // jedancheckin
        public int CheckINId { get; set; }
        [ForeignKey(nameof(CheckINId))]
        public virtual CheckIN CheckIN { get; set; }
    }
}
