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
        public int Region_MiastaId { get; set; }
        public int MiastoId { get; set; }
        public Miasto Miasto { get; set; }
        public string Nazwa { get; set; }
        public string Stopien_zagrozenia { get; set; }
    }
}
