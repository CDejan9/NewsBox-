using ProjekatASP.Application.DTO.KategorijaDTO;
using ProjekatASP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.CommandsProjekat.KategorijaCommands
{
    public interface IGetKategorijaCommand : ICommand<int , KategorijaGetDto>
    {
    }
}
