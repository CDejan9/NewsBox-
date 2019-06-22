using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DTO.KorisnikDTO.KorisnikWebDTO
{
    public class KorisnikGetWebDto
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public bool Obrisan { get; set; }
        public string NazivUloge { get; set; }
    }
}
