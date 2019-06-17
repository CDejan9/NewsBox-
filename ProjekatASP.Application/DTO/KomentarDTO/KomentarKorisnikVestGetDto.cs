using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DTO.KomentarDTO
{
    public class KomentarKorisnikVestGetDto
    {
        public int Id { get; set; }
        public string KomentarTekst { get; set; }
        public int VestId { get; set; }
        public string VestNaslov { get; set; }
        public int KorisnikId { get; set; }
        public string KorisnikEmail { get; set; }
    }
}
