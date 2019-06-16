using System;
using System.Collections.Generic;
using System.Text;
using EfDataAccess;
using ProjekatASP.Application.CommandsProjekat.KategorijaCommands;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.KategorijaCommands
{
    public class EFDeleteKategorijaCommand : EFBaseCommand, IDeleteKategorijaCommand
    {
        public EFDeleteKategorijaCommand(ProjekatASPContext context) : base(context)
        {
        }

        public void Execute(int id)
        {
            var kat = Context.Kategorijas.Find(id);
            if(kat == null || kat.Obrisano == true)
            {
                throw new DataNotFoundException("Kategorija koju zelite da obrisete");
            }

            kat.Obrisano = true;
            Context.SaveChanges();
           
        }
    }
}
