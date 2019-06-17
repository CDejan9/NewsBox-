using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjekatASP.Application.DTO.KomentarDTO
{
    public class KomentarInsertDto
    {
        public string KomentarTekst { get; set; }

        [Required(ErrorMessage = "Komentar mora da ima korisnika koji ga je napisao")]
        public int KorisnikId { get; set; }

        [Required(ErrorMessage = "Komentar mora imati vest koji pripada")]
        public int VestId { get; set; }
    }
}
