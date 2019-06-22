using ProjekatASP.Application.DTO.KorisnikDTO.KorisnikWebDTO;
using ProjekatASP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.CommandsProjekat.KorisnikCommands.WebCommand
{
    public interface IGetKorisnikGetWebCommand : ICommand<int, KorisnikGetWebDto>
    {
    }
}
