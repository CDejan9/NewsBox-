using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.SearchesProjekat
{
    public class UlogaSearch
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public bool Aktivan { get; set; }

        public int PoStrani { get; set; } = 4;
        public int BrojStrane { get; set; } = 1;
    }
}
