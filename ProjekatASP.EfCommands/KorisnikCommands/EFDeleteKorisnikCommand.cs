using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.CommandsProjekat.KorisnikCommands;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.KorisnikCommands
{
    public class EFDeleteKorisnikCommand : EFBaseCommand, IDeleteKorisnikCommand
    {
        public EFDeleteKorisnikCommand(ProjekatASPContext context) : base(context)
        {
        }

        public void Execute(int id)
        {
            var korisnik = Context.Korisniks.Include(kom => kom.Komentars)
                .Where(k => k.Id == id).First();
            if(korisnik.Obrisano || korisnik == null)
            {
                throw new DataNotFoundException("Korisnik koga zelite da obrisete");
            }

            korisnik.Obrisano = true;
            var komentari = korisnik.Komentars;
            foreach(var k in komentari)
            {
                k.Obrisano = true;
            }
            Context.SaveChanges();
        }
    }
}
