using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjekatASP.Application.DTO.KategorijaDTO
{
    public class KategorijaInsertDto
    {
        [Required(ErrorMessage = "Naziv je obavezan")]
        [MinLength(3, ErrorMessage = "Naziv mora da ima bar 3 karaktera")]
        public string Naziv { get; set; }
    }
}
