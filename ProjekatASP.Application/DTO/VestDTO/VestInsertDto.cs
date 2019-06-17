using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjekatASP.Application.DTO.VestDTO
{
    public class VestInsertDto
    {
        [Required(ErrorMessage = "Naslov je obavezan")]
        [MinLength(4, ErrorMessage = "Vest mora sadrzati tekst duzine barem 10 karaktera")]
        public string Naslov { get; set; }

        [MinLength(10, ErrorMessage = "Vest mora sadrzati tekst duzine barem 10 karaktera")]
        public string Tekst { get; set; }

        [Required(ErrorMessage = "Kategorija mora biti izabrana")]
        public int KategorijaId { get; set; }
        public string PutanjaSlike { get; set; }
    }
}
