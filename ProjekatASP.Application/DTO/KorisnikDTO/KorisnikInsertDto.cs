using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjekatASP.Application.DTO.KorisnikDTO
{
    public class KorisnikInsertDto
    {
        [MaxLength(30, ErrorMessage = "Ime moze imati najvise 30 karaktera")]
        [MinLength(3, ErrorMessage = "Ime je kratko, mora imati minimum 3 karaktera")]
        public string Ime { get; set; }

        [MaxLength(30, ErrorMessage = "Prezime moze imati najvise 30 karaktera")]
        [MinLength(3, ErrorMessage = "Prezime je kratko, mora imati minimum 3 karaktera")]
        public string Prezime { get; set; }
        public string Email { get; set; }

        [MaxLength(20, ErrorMessage = "Lozinka moze imati najvise 30 karaktera")]
        [MinLength(8, ErrorMessage = "Lozinka je slaba, mora imati minimum 8 karaktera")]
        public string Lozinka { get; set; }
        public int? UlogaId { get; set; }
    }
}
