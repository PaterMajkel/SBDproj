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
        public int KomendaId { get; set; }
        public string Adres { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        public int Region_MiastaId { get; set; }
        public Region_Miasta Region_Miasta { get; set; }

    }
}
