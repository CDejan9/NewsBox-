using System;
using System.Collections.Generic;
using System.Text;
using EfDataAccess;
using ProjekatASP.Application.CommandsProjekat.KomentarCommand;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.KomentarCommands
{
    public class EFDeleteKomentarCommand : EFBaseCommand, IDeleteKomentarCommand
    {
        public EFDeleteKomentarCommand(ProjekatASPContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var komentar = Context.Komentars.Find(request);
            if (komentar == null || komentar.Obrisano)
                throw new DataNotFoundException();
            komentar.Obrisano = true;
            Context.SaveChanges();
        }
    }
}
