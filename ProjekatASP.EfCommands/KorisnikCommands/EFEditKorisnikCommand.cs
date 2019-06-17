using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using ProjekatASP.Application.CommandsProjekat.KorisnikCommands;
using ProjekatASP.Application.DTO.KorisnikDTO;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.KorisnikCommands
{
    public class EFEditKorisnikCommand : EFBaseCommand, IEditKorisnikCommand
    {
        public EFEditKorisnikCommand(ProjekatASPContext context) : base(context)
        {
        }

        public void Execute(KorisnikGetDto request)
        {
            var korisnik = Context.Korisniks.Find(request.Id);

            if (korisnik == null || korisnik.Obrisano == true)
            {
                throw new DataNotFoundException();
            }
            if (korisnik.Email != request.Email)
            {
                if (Context.Korisniks.Any(u => u.Email == request.Email))
                {
                    throw new DataAlreadyExistsException();
                }
                korisnik.Ime = request.Ime;
                korisnik.Prezime = request.Prezime;
                korisnik.UlogaId = request.UlogaId;
                //korisnik.Uloga = request.NazivUloge;
                korisnik.Email = request.Email;
                korisnik.Lozinka = request.Lozinka;
                korisnik.Modifikovano = DateTime.Now;

                Context.SaveChanges();
            }
            else
            {
                throw new DataNotAlteredException();
            }

        }
    }
}
