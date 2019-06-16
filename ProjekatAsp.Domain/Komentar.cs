using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatAsp.Domain
{
    public class Komentar : BaseEntity
    {
        public string Komentar_Tekst { get; set; }
        public int VestId { get; set; }
        public int KorisnikId { get; set; }
        public Vest Vest { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
