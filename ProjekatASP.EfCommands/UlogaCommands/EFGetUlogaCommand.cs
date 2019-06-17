using EfDataAccess;
using ProjekatASP.Application.CommandsProjekat.UlogaCommands;
using ProjekatASP.Application.DTO.UlogaDTO;
using ProjekatASP.Application.ExceptionsProjekat;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.EfCommands.UlogaCommands
{
    public class EFGetUlogaCommand : EFBaseCommand, IGetUlogaCommand
    {
        public EFGetUlogaCommand(ProjekatASPContext context) : base(context)
        {
        }

        public UlogaGetDto Execute(int request)
        {
            var uloga = Context.Ulogas.Find(request);
            if(uloga == null || uloga.Obrisano == true)
            {
                throw new DataNotFoundException();
            }

            return new UlogaGetDto
            {
                Id = uloga.Id,
                Naziv = uloga.Naziv
            };
        }
    }
}
