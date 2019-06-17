using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
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
            var uloga = Context.Ulogas.Include(k => k.Korisniks).Where(u => u.Id == id).First();
            if (uloga == null || uloga.Obrisano == true)
            {
                throw new DataNotFoundException();
            }

            if(uloga.Korisniks.Count() > 0)
            {
                throw new DataAlreadyExistsException();
            }
            uloga.Obrisano = true;
            Context.SaveChanges(); 
        }
    }
}
