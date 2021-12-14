using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Ranga
    {
        [Key]
        public int RangaId { get; set; }
        public string Nazwa { get; set; }
        public double Pensja { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
