using ProjekatASP.Application.DTO.UlogaDTO;
using ProjekatASP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.CommandsProjekat.UlogaCommands
{
    public interface IAddUlogaCommand : ICommand<UlogaInsertDto>
    {
    }
}
