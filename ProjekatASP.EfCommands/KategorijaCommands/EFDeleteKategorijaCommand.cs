using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
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
            var kategorija = Context.Kategorijas.Include(v => v.Vests).Where(v => v.Id == id).First();
            if (kategorija == null || kategorija.Obrisano == true)
            {
                throw new DataNotFoundException("Kategorija koju zelite da obrisete");
            }

            if (kategorija.Vests.Count() > 0)
            {
                throw new DataAlreadyExistsException();
            }
            kategorija.Obrisano = true;
            Context.SaveChanges();
        }
    }
}
