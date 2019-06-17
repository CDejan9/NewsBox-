using ProjekatASP.Application.DTO.UlogaDTO;
using ProjekatASP.Application.Interfaces;
using ProjekatASP.Application.Responsed;
using ProjekatASP.Application.SearchesProjekat;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.CommandsProjekat.UlogaCommands
{
    public interface IGetUlogeCommand : ICommand<UlogaSearch, PagedRespone<UlogaGetDto>>
    {
    }
}
