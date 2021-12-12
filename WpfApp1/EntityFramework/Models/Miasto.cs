using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Miasto
    {
        [Key]
        public int MiastoId { get; set; }
        public string Nazwa { get; set; }
    }
}
