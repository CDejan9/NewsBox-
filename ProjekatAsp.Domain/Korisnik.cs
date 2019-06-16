using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatAsp.Domain
{
    public class Korisnik : BaseEntity
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public int? UlogaId { get; set; }
        public Uloga Uloga { get; set; }
        public ICollection<Komentar> Komentars { get; set; }
    }
}
