using ProjekatASP.Application.DTO.KorisnikDTO;
using ProjekatASP.Application.Interfaces;
using ProjekatASP.Application.Responsed;
using ProjekatASP.Application.SearchesProjekat;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.CommandsProjekat.KorisnikCommands
{
    public interface IGetKorisniciCommand : ICommand<KorisnikSearch, PagedRespone<KorisnikGetDto>>
    {
    }
}
