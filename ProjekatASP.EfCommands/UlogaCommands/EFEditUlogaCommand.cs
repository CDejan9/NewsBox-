using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using ProjekatASP.Application.CommandsProjekat.UlogaCommands;
using ProjekatASP.Application.DTO.UlogaDTO;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.UlogaCommands
{
    public class EFEditUlogaCommand : EFBaseCommand, IEditUlogaCommand
    {
        public EFEditUlogaCommand(ProjekatASPContext context) : base(context)
        {
        }

        public void Execute(UlogaGetDto request)
        {
            var uloga = Context.Ulogas.Find(request.Id);
            if (uloga == null || uloga.Obrisano == true)
            {
                throw new DataNotFoundException();
            }
            if(request.Naziv == uloga.Naziv)
            {
                throw new DataAlreadyExistsException();
            }
            if(Context.Ulogas.Any(u => u.Naziv == request.Naziv))
            {
                throw new DataAlreadyExistsException();
            }

            uloga.Naziv = request.Naziv;
            uloga.Modifikovano = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
