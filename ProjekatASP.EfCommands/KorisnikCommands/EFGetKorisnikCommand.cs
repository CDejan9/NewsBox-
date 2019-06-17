using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.CommandsProjekat.KorisnikCommands;
using ProjekatASP.Application.DTO.KomentarDTO;
using ProjekatASP.Application.DTO.KorisnikDTO;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.KorisnikCommands
{
    public class EFGetKorisnikCommand : EFBaseCommand, IGetKorisnikCommand
    {
        public EFGetKorisnikCommand(ProjekatASPContext context) : base(context)
        {
        }

        public KorisnikGetKomentarDto Execute(int request)
        {
            var data = Context.Korisniks
                .Include(u => u.Uloga)
                .Include(kom => kom.Komentars)
                .SingleOrDefault(k => k.Id == request);


            if (data.Obrisano == true || data == null)
            {
                throw new DataNotFoundException("Korisnik ne postoji");
            }

            return new KorisnikGetKomentarDto
            {
                Id = data.Id,
                Ime = data.Ime,
                Prezime = data.Prezime,
                Email = data.Email,
                UlogaId = data.Uloga.Id,
                NazivUloge = data.Uloga.Naziv,
                TekstKomentara = data.Komentars.Select(k => new KomentarGetDto
                {
                    Id = k.Id,
                    TekstKomentara = k.Komentar_Tekst,
                }).ToList()              
            };
        }
    }
}
