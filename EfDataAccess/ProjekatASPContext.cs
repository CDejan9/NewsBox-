using EfDataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess
{
    public class ProjekatASPContext : DbContext
    {
        public DbSet<Korisnik> Korisniks { get; set; }
        public DbSet<Uloga> Ulogas { get; set; }
        public DbSet<Vest> Vests { get; set; }
        public DbSet<Kategorija> Kategorijas { get; set; }
        public DbSet<Slika> Slikas { get; set; }
        public DbSet<Komentar> Komentars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-MGRPM6K2\SQLEXPRESS;Initial Catalog=ProjekatASP;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KorisnikConfiguration());
            modelBuilder.ApplyConfiguration(new UlogaConfiguration());
            modelBuilder.ApplyConfiguration(new KategorijaConfiguration());
            modelBuilder.ApplyConfiguration(new SlikaConfiguration());
            modelBuilder.ApplyConfiguration(new VestConfiguration());
            modelBuilder.ApplyConfiguration(new KomentarConfiguration());
        }
    }
}
