using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Wykroczenia
    {
        [Key]
        public int WykroczenieId { get; set; }
        public string Nazwa { get; set; }
        public string Data { get; set; }
        public string Godzina { get; set; }
        public ICollection<Policjant> Policjants {get; set;}
        public ICollection<Kartoteka> Kartotekas { get; set; }
    }
}
