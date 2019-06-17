using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.CommandsProjekat.VestCommands;
using ProjekatASP.Application.ExceptionsProjekat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.EfCommands.VestCommand
{
    public class EFDeleteVestCommand : EFBaseCommand, IDeleteVestCommand
    {
        public EFDeleteVestCommand(ProjekatASPContext context) : base(context)
        {
        }

        public void Execute(int id)
        {
            var vest = Context.Vests.Include(v => v.Komentars).Where(v => v.Id == id)
               .Include(s => s.Slikas).Where(v => v.Id == id).First();

            if(vest == null || vest.Obrisano == true)
            {
                throw new DataNotFoundException();
            }

            vest.Obrisano = true;
            var komentari = vest.Komentars;
            foreach (var k in komentari)
            {
                k.Obrisano = true;
            }
            var slika = vest.Slikas;
            foreach (var s in slika)
            {
                s.Obrisano = true;
            }
            Context.SaveChanges();

        }
    }
}
