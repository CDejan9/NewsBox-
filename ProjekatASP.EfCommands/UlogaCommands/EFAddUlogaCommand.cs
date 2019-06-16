using EfDataAccess;
using ProjekatAsp.Domain;
using ProjekatASP.Application.CommandsProjekat.UlogaCommands;
using ProjekatASP.Application.DTO.UlogaDTO;
using ProjekatASP.Application.ExceptionsProjekat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.EfCommands.UlogaCommands
{
    public class EFAddUlogaCommand : EFBaseCommand, IAddUlogaCommand
    {
        public EFAddUlogaCommand(ProjekatASPContext context) : base(context)
        {
        }

        public void Execute(UlogaInsertDto request)
        {
            if(Context.Ulogas.Any(u => u.Naziv == request.Naziv))
            {
                throw new DataAlreadyExistsException("Uloga sa tim imenom");
            }

            Context.Ulogas.Add(new Uloga
            {
                Naziv = request.Naziv,
                Kreirano = DateTime.Now
            });

            Context.SaveChanges();
        }
    }
}
