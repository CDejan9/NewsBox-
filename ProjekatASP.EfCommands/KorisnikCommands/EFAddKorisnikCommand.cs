using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using ProjekatAsp.Domain;
using ProjekatASP.Application.CommandsProjekat.KorisnikCommands;
using ProjekatASP.Application.DTO.KorisnikDTO;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.KorisnikCommands
{
    public class EFAddKorisnikCommand : EFBaseCommand,  IAddKorisnikCommand
    {
        public EFAddKorisnikCommand(ProjekatASPContext context) : base(context)
        {
        }

        public void Execute(KorisnikInsertDto request)
        {
            var uloga = Context.Ulogas.Find(request.UlogaId);
            if(uloga == null || uloga.Obrisano == true)
            {
                throw new DataNotFoundException("uloga koja je dodeljena tom korisniku");
            }
            if(Context.Korisniks.Any(k => k.Email == request.Email))
            {
                throw new DataAlreadyExistsException("korinsik sa tim E-mailom");
            }

            Context.Korisniks.Add(new Korisnik
            {
                Ime = request.Ime,
                Prezime = request.Prezime,
                Email = request.Email,
                Lozinka = request.Lozinka,
                UlogaId = request.UlogaId,
                Kreirano = DateTime.Now
            });

            Context.SaveChanges();
        }
    }
}
