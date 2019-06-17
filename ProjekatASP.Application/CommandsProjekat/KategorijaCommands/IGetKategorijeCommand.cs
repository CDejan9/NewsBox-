using ProjekatASP.Application.DTO.KategorijaDTO;
using ProjekatASP.Application.Interfaces;
using ProjekatASP.Application.Responsed;
using ProjekatASP.Application.SearchesProjekat;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.CommandsProjekat.KategorijaCommands
{
    public interface IGetKategorijeCommand : ICommand<KategorijaSearch, PagedRespone<KategorijaGetDtoBezVesti>>
    {   
    }
}
