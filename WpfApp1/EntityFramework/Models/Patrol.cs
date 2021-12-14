using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Patrol
    {
        [Key]
        public int PatrolId { get; set; }
        public int RadiowozId { get; set; }
        public Radiowoz Radiowoz { get; set; }
        public int PolicjantId { get; set; }
        public Policjant Policjant { get; set; }
        public string Data_rozpoczecia { get; set; }
        public string Data_zakonczenia { get; set; }
        public string Godzina_rozpoczecia { get; set; }
        public string Godzina_zakonczenia { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
