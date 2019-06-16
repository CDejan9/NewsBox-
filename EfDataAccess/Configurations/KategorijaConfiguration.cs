using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class KategorijaConfiguration : IEntityTypeConfiguration<Kategorija>
    {
        public void Configure(EntityTypeBuilder<Kategorija> builder)
        {
            builder.Property(kat => kat.Naziv)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(kat => kat.Kreirano)
                .HasDefaultValueSql("GETDATE()");

            builder.HasMany(v => v.Vests)
                .WithOne(kat => kat.Kategorija)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
