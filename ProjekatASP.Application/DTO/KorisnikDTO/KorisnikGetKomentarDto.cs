using ProjekatASP.Application.DTO.KomentarDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DTO.KorisnikDTO
{
    public class KorisnikGetKomentarDto
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public int? UlogaId { get; set; }
        public bool Obrisan { get; set; }
        public string NazivUloge { get; set; }
        public List<KomentarGetDto> TekstKomentara { get; set; }
    }
}
