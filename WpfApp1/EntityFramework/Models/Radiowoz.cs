using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Radiowoz
    {
        [Key]
        public int RadiowozId { get; set; }
        public string Model { get; set; }
        public string Marka { get; set; }
        public int Rok_produkcji { get; set; }
    }
}
