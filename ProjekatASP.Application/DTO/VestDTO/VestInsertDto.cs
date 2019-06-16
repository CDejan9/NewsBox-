using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjekatASP.Application.DTO.VestDTO
{
    public class VestInsertDto
    {
        public string Naslov { get; set; }

        [MinLength(10, ErrorMessage = "Vest mora sadrzati tekst duzine barem 10 karaktera")]
        public string Tekst { get; set; }

        //[RegularExpression("^[1-9]{1,}$", ErrorMessage = "Morate proslediti kategoriju kojoj vest pripada")]
        public int KategorijaId { get; set; }
        public string PutanjaSlike { get; set; }
    }
}
