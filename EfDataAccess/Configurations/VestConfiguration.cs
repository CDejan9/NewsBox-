using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class VestConfiguration : IEntityTypeConfiguration<Vest>
    {
        public void Configure(EntityTypeBuilder<Vest> builder)
        {
            builder.Property(v => v.Naslov)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(v => v.Tekst)
                .IsRequired();

            builder.Property(v => v.Kreirano)
                .HasDefaultValueSql("GETDATE()");

            builder.HasMany(v => v.Slikas)
                .WithOne(s => s.Vest)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(v => v.Kategorija)
                .WithMany(kat => kat.Vests)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(v => v.Komentars)
                .WithOne(kom => kom.Vest)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
