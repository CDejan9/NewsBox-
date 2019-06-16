using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class KorisnikConfiguration : IEntityTypeConfiguration<Korisnik>
    {
        public void Configure(EntityTypeBuilder<Korisnik> builder)
        {
            builder.Property(k => k.Ime)
                 .HasMaxLength(30)
                 .IsRequired();

            builder.Property(k => k.Prezime)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(k => k.Email)
                .IsRequired();

            builder.HasIndex(k => k.Email)
                .IsUnique();

            builder.Property(k => k.Lozinka)
                .IsRequired();

            builder.Property(k => k.Kreirano)
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(k => k.Uloga)
                .WithMany(g => g.Korisniks)
                .IsRequired();

            builder.HasMany(kom => kom.Komentars)
                .WithOne(k => k.Korisnik)
                .OnDelete(DeleteBehavior.Cascade);


            


            
        }
    }
}
