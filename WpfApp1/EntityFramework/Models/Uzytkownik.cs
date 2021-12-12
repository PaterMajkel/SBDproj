using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Uzytkownik
    {
        [Key]
        public int UzytkownikId { get; set; }

        public string Rola { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }
        public int? PolicjantId { get; set; }
        public Policjant Policjant { get; set; }
    }
}
