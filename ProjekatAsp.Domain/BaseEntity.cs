using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatAsp.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Kreirano { get; set; } //Kada je kreirana vest, komentar, korisnik
        public DateTime? Modifikovano { get; set; }
        public bool Obrisano { get; set; }

    }
}
