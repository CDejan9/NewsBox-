using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DTO.KorisnikDTO
{
    public class KorisnikGetDto
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public int? UlogaId { get; set; }

        public string NazivUloge { get; set; }

    }
}
