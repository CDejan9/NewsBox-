using ProjekatASP.Application.DTO.KomentarDTO;
using ProjekatASP.Application.Interfaces;
using ProjekatASP.Application.Responsed;
using ProjekatASP.Application.SearchesProjekat;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.CommandsProjekat.KomentarCommand
{
    public interface IGetKomentariCommmand : ICommand<KomentarSearch, PagedRespone<KomentarKorisnikVestGetDto>>
    {

    }
}
