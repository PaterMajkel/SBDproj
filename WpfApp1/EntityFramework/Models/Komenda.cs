using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Komenda
    {
        [Key]
        public int ID_komendy { get; set; }
        public string Adres { get; set; }
        public int ID_regionu { get; set; }
        public Region_Miasta Region { get; set; }

    }
}
