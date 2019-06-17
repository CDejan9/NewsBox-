using System;
using System.Collections.Generic;
using System.Text;
using EfDataAccess;
using ProjekatASP.Application.CommandsProjekat.UlogaCommands;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.UlogaCommands
{
    public class EFDeleteUlogaCommand : EFBaseCommand, IDeleteUlogaCommand
    {
        public EFDeleteUlogaCommand(ProjekatASPContext context) : base(context)
        {
        }

        public void Execute(int id)
        {
            var uloga = Context.Ulogas.Find(id);
            if(uloga == null || uloga.Obrisano == true)
            {
                throw new DataNotFoundException("Uloga koju zelite da obrisete");
            }

            uloga.Obrisano = true;
            Context.SaveChanges();
        }
    }
}
