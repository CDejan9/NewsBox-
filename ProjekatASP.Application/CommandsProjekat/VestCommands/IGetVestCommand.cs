using ProjekatASP.Application.DTO.VestDTO;
using ProjekatASP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.CommandsProjekat.VestCommands
{
    public interface IGetVestCommand : ICommand<int, VestKomentarGetDto>
    {
    }
}
