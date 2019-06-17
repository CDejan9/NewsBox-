using ProjekatASP.Application.DTO.KomentarDTO;
using ProjekatASP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.CommandsProjekat.KomentarCommand
{
    public interface IGetKomentarCommand : ICommand<int, KomentarKorisnikVestGetDto>
    {
    }
}
