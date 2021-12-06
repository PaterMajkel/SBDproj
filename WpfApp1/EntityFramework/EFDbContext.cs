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
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"F:\\student debil sem 5\\test\\WpfApp1\\EntityFramework\\Policja.mdf\";Integrated Security=True");

                return new EFDbContext(optionsBuilder.Options);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
