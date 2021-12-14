using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Kartoteka> Kartotekas { get; set; }
        public DbSet<Komenda> Komendas { get; set; }
        public DbSet<Miasto> Miastos { get; set; }
        public DbSet<Patrol> Patrols { get; set; }
        public DbSet<Policjant> Policjants { get; set; }
        public DbSet<Przestepstwo> Przestepstwos { get; set; }
        public DbSet<Radiowoz> Radiowozs { get; set; }
        public DbSet<Ranga> Rangas { get; set; }
        public DbSet<Region_Miasta> Region_Miastas { get; set; }
        public DbSet<Uzytkownik> Uzytkowniks { get; set; }
        public DbSet<Wykroczenia> Wykroczenias { get; set; }

        public class EFDbContextFactory : IDesignTimeDbContextFactory<EFDbContext>
        {
            public EFDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<EFDbContext>();
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HP\\Desktop\\SS\\SBDproj\\WpfApp1\\EntityFramework\\Database1.mdf;Integrated Security=True");
                // MICHAŁ Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"F:\\student debil sem 5\\test\\SBDproj\\WpfApp1\\EntityFramework\\Policja.mdf\";Integrated Security=True
                // FILIP Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=I:\\Filip\\SEMESTR5\\Projekt\\SBDproj\\WpfApp1\\EntityFramework\\Database1.mdf;Integrated Security=True
                return new EFDbContext(optionsBuilder.Options);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Uzytkownicy
            modelBuilder.Entity<Uzytkownik>().HasData(
                new Uzytkownik { UzytkownikId = 1, Login = "Admin", Password = "Admin", Rola = "admin" }
                );

            //Miasta
            modelBuilder.Entity<Miasto>().HasData(
                new Miasto { MiastoId = 1, Nazwa = "Białystok"},
                new Miasto { MiastoId = 2, Nazwa = "Kraków"},
                new Miasto { MiastoId = 3, Nazwa = "Warszawa"},
                new Miasto { MiastoId = 4, Nazwa = "Rzeszów"},
                new Miasto { MiastoId = 5, Nazwa = "Łódź" },
                new Miasto { MiastoId = 6, Nazwa = "Gdańsk" },
                new Miasto { MiastoId = 7, Nazwa = "Katowice" },
                new Miasto { MiastoId = 8, Nazwa = "Wrocław" },
                new Miasto { MiastoId = 9, Nazwa = "Poznań" }
                );

            //Komendy
            /*
                public int ID_komendy { get; set; }
                public string Adres { get; set; }
                public int ID_regionu { get; set; }
                public Region_Miasta Region { get; set; }
             */
            modelBuilder.Entity<Komenda>().HasData(
               new Komenda { KomendaId = 1, Adres = "Muchomorska 9", Region_MiastaId = 1 },
               new Komenda { KomendaId = 2, Adres = "Zawadiaków 14", Region_MiastaId = 2 },
               new Komenda { KomendaId = 3, Adres = "Mirosławska 15", Region_MiastaId = 4 },
               new Komenda { KomendaId = 4, Adres = "Piątków 21/7", Region_MiastaId = 5 },
               new Komenda { KomendaId = 5, Adres = "Miłosierdzia Pańskiego 2137", Region_MiastaId = 6 },
               new Komenda { KomendaId = 6, Adres = "Obi-Wana Kenobiego 3", Region_MiastaId = 7 },
               new Komenda { KomendaId = 7, Adres = "Plackowa 98", Region_MiastaId = 8 },
               new Komenda { KomendaId = 8, Adres = "Iglasta 41", Region_MiastaId = 3 },
               new Komenda { KomendaId = 9, Adres = "Chrobrego 21", Region_MiastaId = 9 }
               );
            //Region-Miata
            /*
                public int ID_regionu { get; set; }
                public int ID_miasta { get; set; }
                public Miasto Miasto { get; set; }
                public string Nazwa { get; set; }
                public string Stopien_zagrozenia { get; set; }
            */
            modelBuilder.Entity<Region_Miasta>().HasData(
              new Region_Miasta { Region_MiastaId = 1, MiastoId = 1, Stopien_zagrozenia="Niski", Nazwa="Piasta" },
              new Region_Miasta { Region_MiastaId = 2, MiastoId = 1, Stopien_zagrozenia="Wysoki", Nazwa="Skorupy" },
              new Region_Miasta { Region_MiastaId = 3, MiastoId = 5, Stopien_zagrozenia="Śmiertelny", Nazwa="Bałuty" },
              new Region_Miasta { Region_MiastaId = 4, MiastoId = 9, Stopien_zagrozenia="Średni", Nazwa="Paciorków" },
              new Region_Miasta { Region_MiastaId = 5, MiastoId = 4, Stopien_zagrozenia="Niski", Nazwa="Puchatkowo" },
              new Region_Miasta { Region_MiastaId = 6, MiastoId = 3, Stopien_zagrozenia="Wysoki", Nazwa="Niski Stok" },
              new Region_Miasta { Region_MiastaId = 7, MiastoId = 3, Stopien_zagrozenia="Niski", Nazwa="Średnia Górka" },
              new Region_Miasta { Region_MiastaId = 8, MiastoId = 8, Stopien_zagrozenia="Średni", Nazwa="Swoja" },
              new Region_Miasta { Region_MiastaId = 9, MiastoId = 7, Stopien_zagrozenia="Śmiertelny", Nazwa="Chmurzyńska Wieś" }
              );
            modelBuilder.Entity<Kartoteka>().HasData(
                new Kartoteka {KartotekaId=1,Imie="Zuzanna", Nazwisko="Bagińska",Wiek=21 },
                new Kartoteka { KartotekaId = 2, Imie = "Lewis", Nazwisko = "Hamilto", Wiek = 37 },
                new Kartoteka { KartotekaId = 3, Imie = "Bruno", Nazwisko = "Czech", Wiek = 20 },
                new Kartoteka { KartotekaId = 4, Imie = "Stachu", Nazwisko = "Jones", Wiek = 74 },
                new Kartoteka { KartotekaId = 5, Imie = "Stanisław", Nazwisko = "Wokulski", Wiek = 30 },
                new Kartoteka { KartotekaId = 6, Imie = "Witold", Nazwisko = "Gombrowicz", Wiek = 43 },
                new Kartoteka { KartotekaId = 7, Imie = "Piotrek", Nazwisko = "Parker", Wiek = 30 },
                new Kartoteka { KartotekaId = 8, Imie = "Sara", Nazwisko = "Sudoł", Wiek = 23 }
                );
            modelBuilder.Entity<Policjant>().HasData(
                new Policjant { PolicjantId = 1, Imie = "Adam", Nazwisko="Pogorzelski", RangaId=1, KomendaId=1 },
                new Policjant { PolicjantId = 2, Imie = "Krzysztof", Nazwisko = "Gonciarz", RangaId = 2, KomendaId = 1 },
                new Policjant { PolicjantId = 3, Imie = "Tomasz", Nazwisko = "Działowy", RangaId = 3, KomendaId = 1 },
                new Policjant { PolicjantId = 4, Imie = "Antoni", Nazwisko = "Macierewicz", RangaId = 4, KomendaId = 1 },
                new Policjant { PolicjantId = 5, Imie = "Darth", Nazwisko = "Vader", RangaId = 5, KomendaId = 1 }
            );
            modelBuilder.Entity<Ranga>().HasData(
                new Ranga { RangaId = 1, Nazwa = "Posterunkowy", Pensja = 2800 },
                new Ranga { RangaId = 2, Nazwa = "Starszy Posterunkowy", Pensja = 2900 },
                new Ranga { RangaId = 3, Nazwa = "Sierżant", Pensja = 3000 },
                new Ranga { RangaId = 4, Nazwa = "Starszy Sierżant", Pensja = 3100 },
                new Ranga { RangaId = 5, Nazwa = "Sierżant Sztabowy", Pensja = 3200 },
                new Ranga { RangaId = 6, Nazwa = "Młodszy Aspirant", Pensja = 3300 },
                new Ranga { RangaId = 7, Nazwa = "Aspirant", Pensja = 3400 },
                new Ranga { RangaId = 8, Nazwa = "Starszy Aspirant", Pensja = 3500 },
                new Ranga { RangaId = 9, Nazwa = "Aspirant Sztabowy", Pensja = 3600 },
                new Ranga { RangaId = 10, Nazwa = "Podkomisarz", Pensja = 3700 },
                new Ranga { RangaId = 11, Nazwa = "Komisarz", Pensja = 3800 },
                new Ranga { RangaId = 12, Nazwa = "Nadkomisarz", Pensja = 3900 },
                new Ranga { RangaId = 13, Nazwa = "Podinspektor", Pensja = 4000 },
                new Ranga { RangaId = 14, Nazwa = "Młodszy Inspektor", Pensja = 4100 },
                new Ranga { RangaId = 15, Nazwa = "Inspektor", Pensja = 4200 },
                new Ranga { RangaId = 16, Nazwa = "Nadinspektor", Pensja = 4300 },
                new Ranga { RangaId = 17, Nazwa = "Generalny Inspektor", Pensja = 4400 }
                );
            modelBuilder.Entity<Radiowoz>().HasData(
                new Radiowoz { RadiowozId = 1, Model = "M3", Marka = "BMW", Rok_produkcji = 2016 },
                new Radiowoz { RadiowozId = 2, Model = "M3", Marka = "BMW", Rok_produkcji = 2016 },
                new Radiowoz { RadiowozId = 3, Model = "M3", Marka = "BMW", Rok_produkcji = 2016 },
                new Radiowoz { RadiowozId = 4, Model = "M3", Marka = "BMW", Rok_produkcji = 2016 },
                new Radiowoz { RadiowozId = 5, Model = "M3", Marka = "BMW", Rok_produkcji = 2016 },
                new Radiowoz { RadiowozId = 6, Model = "M3", Marka = "BMW", Rok_produkcji = 2016 }
                );
        }
    }
}
