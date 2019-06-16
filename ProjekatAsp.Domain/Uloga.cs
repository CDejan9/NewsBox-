using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatAsp.Domain
{
    public class Uloga : BaseEntity
    {
        public string Naziv { get; set; }
        public ICollection<Korisnik> Korisniks { get; set; }
    }
}
