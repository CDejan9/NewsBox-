using ProjekatASP.Application.DTO.KomentarDTO;
using ProjekatASP.Application.DTO.SlikaDTO1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DTO.VestDTO
{
    public class VestKomentarGetDto
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Tekst { get; set; }
        public int KategorijaId { get; set; }
        public string NazivKategorije { get; set; }
        public List<SlikaGetDto> putanjaSlike { get; set; }
        public List<KomentarGetDto> TekstKomentara { get; set; }
    }
}
