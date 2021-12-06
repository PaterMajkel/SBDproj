﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Kartoteka
    {
        [Key]
        public int ID_osoby { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public byte[] Zdjecie { get; set; }
        public ICollection<Wykroczenia> Wykroczenias { get; set; }
        public ICollection<Przestepstwo> Przestepstwos { get; set; }
    }
}
