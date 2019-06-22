using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.CommandsProjekat.KorisnikCommands.WebCommand;
using ProjekatASP.Application.DTO.KorisnikDTO.KorisnikWebDTO;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.KorisnikCommands.WebCommand
{
    public class EFGetKorisnikWebCommand : EFBaseCommand, IGetKorisnikGetWebCommand
    {
        public EFGetKorisnikWebCommand(ProjekatASPContext context) : base(context)
        {
        }

        public KorisnikGetWebDto Execute(int request)
        {
            var data = Context.Korisniks
                .Include(u => u.Uloga)
                .Include(kom => kom.Komentars)
                .SingleOrDefault(k => k.Id == request);

            if (data == null || data.Obrisano == true)
            {
                throw new DataNotFoundException();
            }

            return new KorisnikGetWebDto
            {
                Id = data.Id,
                Ime = data.Ime,
                Prezime = data.Prezime,
                Email = data.Email,
                NazivUloge = data.Uloga.Naziv
                
            };

        }
    }
}
