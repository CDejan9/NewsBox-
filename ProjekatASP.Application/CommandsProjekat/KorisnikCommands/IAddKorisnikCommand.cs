using ProjekatASP.Application.DTO.KorisnikDTO;
using ProjekatASP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.CommandsProjekat.KorisnikCommands
{
    public interface IAddKorisnikCommand : ICommand<KorisnikInsertDto>
    {
    }
}
