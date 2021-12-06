using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Region_Miasta
    {
        [Key]
        public int ID_regionu { get; set; }
        public int ID_miasta { get; set; }
        public Miasto Miasto { get; set; }
        public string Nazwa { get; set; }
        public string Stopien_zagrozenia { get; set; }
    }
}
