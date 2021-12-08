﻿using System;
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
        //funkcjonalność
        //dodawanie każdej z opcji prócz rangi
        //_context.Patrols.Add()
        //edytowanie linijek przekazujac obiekt i id obiektu do zmiany
        //usuwanie linijek po id

        //              zapytania do bazy
        //TODO: zbieranie podwładnych policjantów
        //TODO: zbieranie osób (przestepcow, oddzielnie wykroczenia), które złapał dany policjant (po id)
        //TODO: zbieranie przestepstw/wykroczen + filtry po atrybutach (przede wszystkim po datach)
        //TODO: zbieranie policjantów + filtr po atrybutach
        //TODO: zbieranie osób z kartoteki + filtr po atrybutach
        //TODO: zbieranie radiowozów + filtr po atrybutach
        //TODO: zbieranie patroli + filtr po atrybutach
        //TODO: komendy filtr po mieście, po strefie zagrożenia dzielnicy
        //TODO: zebranie wszystkich przestepstw/wykroczen danej osoby z kartoteki
        public ICollection<Ranga> GetRangas()
        {
            return _context.Rangas.ToList();
        }
        public ICollection<Uzytkownik> GetUzytkowniks()
        {
           
            return _context.Uzytkowniks.ToList();
        }
        public ICollection<Kartoteka> GetKartotekasCoughtByPolicjantId(int id)
        {
            //do zrobienia wciaz -> przykladowe zapytanie do podpatrzenia sb
            var query = from x in _context.Kartotekas
                        where x.ID_osoby == id
                        select x;
            var y = _context.Kartotekas.FromSqlRaw($"select * from * where id={id}");
            return query.ToList();
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
