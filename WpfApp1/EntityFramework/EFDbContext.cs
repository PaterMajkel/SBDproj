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
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"F:\\student debil sem 5\\test\\SBDproj\\WpfApp1\\EntityFramework\\Policja.mdf\";Integrated Security=True");

                return new EFDbContext(optionsBuilder.Options);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Uzytkownicy
            modelBuilder.Entity<Uzytkownik>().HasData(
                new Uzytkownik { ID_uzytkownika = 1, Login = "Admin", Password = "Admin", Rola = "admin" }
                );

            //Miasta
            modelBuilder.Entity<Miasto>().HasData(
                new Miasto { ID_miasta = 1, Nazwa = "Białystok"},
                new Miasto { ID_miasta = 2, Nazwa = "Kraków"},
                new Miasto { ID_miasta = 3, Nazwa = "Warszawa"},
                new Miasto { ID_miasta = 4, Nazwa = "Rzeszów"},
                new Miasto { ID_miasta = 5, Nazwa = "Łódź" },
                new Miasto { ID_miasta = 6, Nazwa = "Gdańsk" },
                new Miasto { ID_miasta = 7, Nazwa = "Katowice" },
                new Miasto { ID_miasta = 8, Nazwa = "Wrocław" },
                new Miasto { ID_miasta = 9, Nazwa = "Poznań" }
                );

            //Komendy
            /*
                public int ID_komendy { get; set; }
                public string Adres { get; set; }
                public int ID_regionu { get; set; }
                public Region_Miasta Region { get; set; }
             */
            modelBuilder.Entity<Komenda>().HasData(
               new Komenda { ID_komendy = 1, Adres = "Muchomorska 9", ID_regionu = 1 },
               new Komenda { ID_komendy = 2, Adres = "Zawadiaków 14", ID_regionu = 2 },
               new Komenda { ID_komendy = 3, Adres = "Mirosławska 15", ID_regionu = 4 },
               new Komenda { ID_komendy = 4, Adres = "Piątków 21/7", ID_regionu = 5 },
               new Komenda { ID_komendy = 5, Adres = "Miłosierdzia Pańskiego 2137", ID_regionu = 6 },
               new Komenda { ID_komendy = 6, Adres = "Obi-Wana Kenobiego 3", ID_regionu = 7 },
               new Komenda { ID_komendy = 7, Adres = "Plackowa 98", ID_regionu = 8 },
               new Komenda { ID_komendy = 8, Adres = "Iglasta 41", ID_regionu = 3 },
               new Komenda { ID_komendy = 9, Adres = "Chrobrego 21", ID_regionu = 9 }
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
              new Region_Miasta { ID_regionu = 1, ID_miasta = 1, Stopien_zagrozenia="Niski", Nazwa="Piasta" },
              new Region_Miasta { ID_regionu = 2, ID_miasta = 1, Stopien_zagrozenia="Wysoki", Nazwa="Skorupy" },
              new Region_Miasta { ID_regionu = 3, ID_miasta = 5, Stopien_zagrozenia="Śmiertelny", Nazwa="Bałuty" },
              new Region_Miasta { ID_regionu = 4, ID_miasta = 9, Stopien_zagrozenia="Średni", Nazwa="Paciorków" },
              new Region_Miasta { ID_regionu = 5, ID_miasta = 4, Stopien_zagrozenia="Niski", Nazwa="Puchatkowo" },
              new Region_Miasta { ID_regionu = 6, ID_miasta = 3, Stopien_zagrozenia="Wysoki", Nazwa="Niski Stok" },
              new Region_Miasta { ID_regionu = 7, ID_miasta = 3, Stopien_zagrozenia="Niski", Nazwa="Średnia Górka" },
              new Region_Miasta { ID_regionu = 8, ID_miasta = 8, Stopien_zagrozenia="Średni", Nazwa="Swoja" },
              new Region_Miasta { ID_regionu = 9, ID_miasta = 7, Stopien_zagrozenia="Śmiertelny", Nazwa="Chmurzyńska Wieś" }
              );

        }
    }
}
