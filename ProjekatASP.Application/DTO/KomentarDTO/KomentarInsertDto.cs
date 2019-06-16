using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DTO.KomentarDTO
{
    public class KomentarInsertDto
    {
        public string KomentarTekst { get; set; }
        public int KorisnikId { get; set; }
        public int VestId { get; set; }
    }
}
