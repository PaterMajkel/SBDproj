using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DTO
{
    public class Kartoteka_Przestepstwo
    {
        public int ID_kartoteka { get; set; }
        public int ID_Przestepstwo { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public int Wiek { get; set; }
        //photo todo
        public string nazwa_wykroczenia { get; set; }
        //date to do
        // time to do

    }
}
