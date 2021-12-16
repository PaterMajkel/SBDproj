using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DTO;
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
            return _context.Rangas.Where(p => p.IsActive).ToList();
        }
        public ICollection<Radiowoz> GetRadiowozs()
        {
            return _context.Radiowozs.Where(p => p.IsActive).ToList();
        }
        public ICollection<Przestepstwo> GetPrzestepstwos()
        {
            return _context.Przestepstwos.Where(p => p.IsActive).ToList();
        }
        public ICollection<Wykroczenia> GetWykroczenias()
        {
            return _context.Wykroczenias.Where(p => p.IsActive).ToList();
        }
        public ICollection<Policjant> GetPolicjants()
        {
            return _context.Policjants.Where(p => p.IsActive).ToList();
        }
        public ICollection<Policjant>GetPolicjantsAndRank()
        {
            return _context.Policjants.Where(p => p.IsActive).Include(k => k.Ranga).ToList();
        }
        public ICollection<Kartoteka> GetKartotekasCoughtByPolicjantId(int id)
        {
            //do zrobienia wciaz -> przykladowe zapytanie do podpatrzenia sb
            var query = from x in _context.Kartotekas
                        where x.KartotekaId == id
                        select x;
            var y = _context.Kartotekas.FromSqlRaw($"select * from * where id={id}");
            return query.ToList();
        }
        public ICollection<Kartoteka> GetKartotekas()
        {
            var x = _context.Kartotekas.Where(p => p.IsActive).ToList();
            return x;
        }
        public Uzytkownik GetUzytkownik(string login, string password)
        {
            if (login == null || password == null)
                return null;
            var uzytkownik = _context.Uzytkowniks.Where(p => p.IsActive).Where(x => x.Login == login).Where(x => x.Password == password).FirstOrDefault();
            return uzytkownik;
        }
        //xD kocham SQL ;* od majkela
        public ICollection<Komenda> GetKomendas()
        {
            /* Tworzenie kwerendy
             * return _context.Komendas
                .Join(_context.Miastos.Join(_context.Region_Miastas, miasto=>miasto.ID_miasta, region=>region.ID_miasta, (miasto, region) => new { ID=region.ID_regionu, Nazwa_regionu= region.Nazwa, Nazwa_miasta = miasto.Nazwa, Stopien_Zagrozenia = region.Stopien_zagrozenia })
                , komenda=>komenda.ID_regionu, _a=>_a.ID, (komenda, _a) => new Komenda_Miasto_Region { ID_komendy = komenda.ID_komendy, ID_regionu=komenda.ID_regionu, Nazwa_regionu=_a.Nazwa_regionu, Nazwa_miasta=_a.Nazwa_miasta, Stopien_zagrozenia=_a.Stopien_Zagrozenia, Adres=komenda.Adres} )
                .ToList();*/
            return _context.Komendas.Where(p => p.IsActive).Include(k => k.Region_Miasta).ThenInclude(kr => kr.Miasto).ToList();
        }
        public void DeleteKomendas(ICollection<Komenda> data)
        {
            foreach (var element in data)
            {
                //var temp = _context.Komendas.Find(element.KomendaId);
                //if (temp != null)
                //    _context.Remove(temp);
                var temp = _context.Komendas.Find(element.KomendaId);
                if (temp != null)
                {
                    temp.IsActive = false;
                }
            }
            _context.SaveChanges();
        }
        public void EditKomenda(Komenda data)
        {
            var edited = _context.Komendas.Where(p => p.KomendaId == data.KomendaId).FirstOrDefault();
            if (edited == null)
                return;
            edited = data;
            _context.SaveChanges();
        }

        public void DeletePrzestepstwos(ICollection<Przestepstwo> data)
        {
            foreach (var element in data)
            {
                var temp = _context.Przestepstwos.Find(element.PrzestepstwoId);
                if (temp != null)
                    //_context.Remove(temp);
                    temp.IsActive = false;
            }
            _context.SaveChanges();
        }
        public void DeleteKartotekas(ICollection<Kartoteka> data)
        {
            foreach (var element in data)
            {
                var temp = _context.Kartotekas.Find(element.KartotekaId);
                if (temp != null)
                    //_context.Remove(temp);
                    temp.IsActive = false;
            }
            _context.SaveChanges();
        }
        public void DeleteRadiowozos(ICollection<Radiowoz> data)
        {
            foreach (var element in data)
            {
                var temp = _context.Radiowozs.Find(element.RadiowozId);
                if (temp != null)
                    //_context.Remove(temp);
                    temp.IsActive = false;

            }
            _context.SaveChanges();
        }
        public ICollection<Miasto> GetMiastos()
        {
            return _context.Miastos.Where(p => p.IsActive).ToList();
        }

        public ICollection<Region_Miasta> getRegionsOfMiasto(Miasto miasto)
        {
            return _context.Region_Miastas.Where(p => p.IsActive).Where(r => r.MiastoId == miasto.MiastoId).ToList();
        }

        public void AddKomenda(Komenda komenda)
        {
            _context.Add(komenda);
            _context.SaveChanges();
        }
        public void AddKartotekas(Kartoteka kartoteka)
        {
            _context.Add(kartoteka);
            _context.SaveChanges();
        }
        public void AddRadiowozos(Radiowoz radiowoz)
        {
            _context.Add(radiowoz);
            _context.SaveChanges();
        }
        public void AddPrzstepstwos(Przestepstwo przestepstwo)
        {
            _context.Add(przestepstwo);
            _context.SaveChanges();
        }

        public ICollection<Uzytkownik> GetUzytkowniks()
        {
            return _context.Uzytkowniks.Where(p => p.IsActive)
                .Include(p => p.Policjant).ThenInclude(p => p.Komenda)
                .ToList();

        }
        public void DeleteUzytkowniks(ICollection<Uzytkownik> data)
        {
            foreach (var element in data)
            {
                var temp = _context.Uzytkowniks.Find(element.UzytkownikId);
                if (temp != null && temp.Rola.ToUpper() != "ADMIN")
                    //_context.Remove(temp);
                    temp.IsActive = false;

            }
        }
        public void AddUzytkownik(Uzytkownik uzytkownik, Policjant policjant)
        {
            if (uzytkownik == null)
                return;
            if (uzytkownik.Rola.ToUpper() == "ADMIN")
            {
                uzytkownik.PolicjantId = 1;
                _context.Uzytkowniks.Add(uzytkownik);
            }
            else
            {
                _context.Policjants.Add(policjant);
                _context.SaveChanges();

                uzytkownik.PolicjantId = policjant.PolicjantId;
                _context.Uzytkowniks.Add(uzytkownik);

            }
            _context.SaveChanges();
        }
        public void AddWykroczenias(Wykroczenia wykroczenia)
        {
            _context.Add(wykroczenia);
            _context.SaveChanges();
        }
        public void EditUzytkownik(Uzytkownik uzytkownik)
        {
            var edited = _context.Uzytkowniks.Where(p => p.UzytkownikId == uzytkownik.UzytkownikId).FirstOrDefault();
            if (edited == null)
                return;
            edited = uzytkownik;
            _context.SaveChanges();
        }
        public void EditRadiowoz(Radiowoz data)
        {
            var edited = _context.Radiowozs.Where(p => p.RadiowozId == data.RadiowozId).FirstOrDefault();
            if (edited == null)
                return;
            edited = data;
            _context.SaveChanges();
        }
        public Kartoteka getKartotekaByObj(Kartoteka kartoteka)
        {
            //var x =File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "Police.png"));
            ////var y = Path.Combine(Directory.GetCurrentDirectory(), "Police.png");
            ;
            return _context.Kartotekas.Where(p => p == kartoteka).Include(p => p.Wykroczenias).Include(p => p.Przestepstwos).First();
        }
        public Wykroczenia getWykroczenieByObj(Wykroczenia wykroczenia)
        {
            return _context.Wykroczenias.Where(p => p == wykroczenia).Include(p => p.Kartotekas).Include(p => p.Policjants).First();
        }
        public Przestepstwo getPrzestepstwoByObj(Przestepstwo przestepstwo)
        {
            return _context.Przestepstwos.Where(p => p == przestepstwo).Include(p => p.Kartotekas).Include(p => p.Policjants).First();
        }
        public ICollection<Region_Miasta> getRegions()
        {
            return _context.Region_Miastas.Where(p => p.IsActive).Include(p => p.Miasto).ToList();
        }
        public void editRegion(Region_Miasta data)
        {
            var edited = _context.Region_Miastas.Where(p => p.Region_MiastaId == data.Region_MiastaId).FirstOrDefault();
            if (edited == null)
                return;
            edited = data;
            _context.SaveChanges();
        }
        public void AddKartotekaToPrzestepstwo(Przestepstwo przestepstwo, Kartoteka kartoteka)
        {
            var temp = _context.Przestepstwos.Where(p => p.IsActive).Where(p => p.PrzestepstwoId == przestepstwo.PrzestepstwoId).Include(p => p.Kartotekas).First();
            if (temp != null)
            {
                temp.Kartotekas.Add(kartoteka);
                _context.SaveChanges();
            }
        }

        public Uzytkownik GetUzytkownikByObj(Uzytkownik data)
        {
            if (data != null)
            {
                return _context.Uzytkowniks.Where(p => p.IsActive && p.PolicjantId == data.PolicjantId).Include(p => p.Policjant).ThenInclude(p => p.Patrols).ThenInclude(p => p.Radiowoz).First();
            }
            return null;
        }
        public void AddPolicjatToPrzestepstwo(Przestepstwo przestepstwo, Policjant policjant)
        {
            var temp = _context.Przestepstwos.Where(p => p.IsActive).Where(p => p.PrzestepstwoId == przestepstwo.PrzestepstwoId).Include(p => p.Policjants).First();
            if (temp != null)
            {
                temp.Policjants.Add(policjant);
                _context.SaveChanges();
            }
        }
        public void AddKartotekaToWykroczenie(Wykroczenia wykroczenia, Kartoteka kartoteka)
        {
            var temp = _context.Wykroczenias.Where(p => p.IsActive).Where(p => p.WykroczenieId == wykroczenia.WykroczenieId).Include(p => p.Kartotekas).First();
            if (temp != null)
            {
                temp.Kartotekas.Add(kartoteka);
                _context.SaveChanges();
            }
        }
        public void AddPolicjantToWykroczenie(Wykroczenia wykroczenia, Policjant policjant)
        {
            var temp = _context.Wykroczenias.Where(p => p.IsActive).Where(p => p.WykroczenieId == wykroczenia.WykroczenieId).Include(p => p.Policjants).First();
            if (temp != null)
            {
                temp.Policjants.Add(policjant);
                _context.SaveChanges();
            }

        }
        public ICollection<Policjant> GetPodwladni(Policjant policjant)
        {
            return _context.Policjants.Where(p=>p.IsActive).Where(p=>p.KomendaId==policjant.KomendaId && p.RangaId< policjant.RangaId).Include(p=>p.Ranga).Include(p => p.Komenda).ToList();
        }
        public void AddPatrol(Patrol patrol)
        {
            _context.Patrols.Add(patrol);
            _context.SaveChanges();

        }
        public Policjant GetPolicjantByObj(Policjant data)
        {
            if (data != null)
            {
                return _context.Policjants.Where(p => p.IsActive && p.PolicjantId == data.PolicjantId).Include(p => p.Patrols).ThenInclude(p => p.Radiowoz).First();
            }
            return null;
        }
    }
}
