using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class UlogaConfiguration : IEntityTypeConfiguration<Uloga>

    {
        public void Configure(EntityTypeBuilder<Uloga> builder)
        {
            builder.Property(u => u.Naziv)
                 .HasMaxLength(30)
                 .IsRequired();

            builder.Property(u => u.Kreirano)
                .HasDefaultValueSql("GETDATE()");

            builder.HasMany(k => k.Korisniks)
                .WithOne(u => u.Uloga)
                .IsRequired();

            
        }
    }
}
