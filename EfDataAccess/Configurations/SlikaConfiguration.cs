using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class SlikaConfiguration : IEntityTypeConfiguration<Slika>
    {
        public void Configure(EntityTypeBuilder<Slika> builder)
        {
            builder.Property(s => s.Putanja)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(s => s.Vest)
                .WithMany(v => v.Slikas)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(s => s.Putanja)
                .IsUnique();
        }
    }
}
