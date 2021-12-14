using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Policjant
    {
        [Key]
        public int PolicjantId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int RangaId { get; set; }
        public Ranga Ranga { get; set; }
        public int KomendaId { get; set; }
        public Komenda Komenda { get; set; }
        public ICollection<Wykroczenia> Wykroczenias { get; set; }
        public ICollection<Przestepstwo> Przestepstwos { get; set; }
        public ICollection<Patrol> Patrols { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
