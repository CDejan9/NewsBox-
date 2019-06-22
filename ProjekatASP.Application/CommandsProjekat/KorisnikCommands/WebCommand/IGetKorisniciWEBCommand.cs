using ProjekatASP.Application.DTO.KorisnikDTO;
using ProjekatASP.Application.DTO.KorisnikDTO.KorisnikWebDTO;
using ProjekatASP.Application.Interfaces;
using ProjekatASP.Application.SearchesProjekat;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.CommandsProjekat.KorisnikCommands.WebCommand
{
    public interface IGetKorisniciWEBCommand : ICommand<KorisnikSearch, IEnumerable <KorisnikGetWebDto>>
    {
    }
}
