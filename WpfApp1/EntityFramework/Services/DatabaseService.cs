using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Services
{
    public class DatabaseService
        {
        private EFDbContext _context;

        public DatabaseService()
        {
            var x = new EFDbContext.EFDbContextFactory();
            _context = x.CreateDbContext(null);
        }
       

        public ICollection<Uzytkownik> GetUzytkowniks()
        {
            return _context.Uzytkowniks.ToList();
        }
        public Uzytkownik GetUzytkownik(string login, string password)
        {
            if (login == null || password == null)
                return null;
            var uzytkownik = _context.Uzytkowniks.Where(x => x.Login == login).Where(x => x.Password == password).FirstOrDefault();
            return uzytkownik;
        }

    }
}
