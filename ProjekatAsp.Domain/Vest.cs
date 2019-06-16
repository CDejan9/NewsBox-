using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatAsp.Domain
{
    public class Vest : BaseEntity
    {
        public string Naslov { get; set; }
        public string Tekst { get; set; }
        public int? KategorijaId { get; set; }
        public Kategorija Kategorija { get; set; }
        public ICollection<Slika> Slikas { get; set; }
        public ICollection<Komentar> Komentars { get; set; }

    }
}
