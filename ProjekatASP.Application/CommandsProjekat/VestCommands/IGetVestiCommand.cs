using ProjekatASP.Application.DTO.VestDTO;
using ProjekatASP.Application.Interfaces;
using ProjekatASP.Application.SearchesProjekat;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.CommandsProjekat.VestCommands
{
    public interface IGetVestiCommand : ICommand<VestSearch, IEnumerable<VestGetDto>>
    {
    }
}
