using ProjekatASP.Application.DTO.VestDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DTO.KategorijaDTO
{
    public class KategorijaGetDto
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public List<VestGetDto> VestiKategorije { get; set; }
    }
}
