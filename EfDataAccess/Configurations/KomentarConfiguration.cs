using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    class KomentarConfiguration : IEntityTypeConfiguration<Komentar>
    {
        public void Configure(EntityTypeBuilder<Komentar> builder)
        {
            builder.Property(kom => kom.Komentar_Tekst);
            builder.HasOne(v => v.Vest)
                .WithMany(kom => kom.Komentars)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(k => k.Korisnik)
                .WithMany(kom => kom.Komentars)
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
