using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.DTO
{
    public class Komenda_Miasto_Region
    {
        public int ID_komendy { get; set; }
        public int ID_regionu { get; set; }
        public string Nazwa_regionu { get; set; }
        public string Nazwa_miasta { get; set; }
        public string Stopien_zagrozenia { get; set; }
        public string Adres { get; set; }


    }
}
