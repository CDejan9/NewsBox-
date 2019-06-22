using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.CommandsProjekat.KorisnikCommands.WebCommand;
using ProjekatASP.Application.DTO.KorisnikDTO;
using ProjekatASP.Application.DTO.KorisnikDTO.KorisnikWebDTO;
using ProjekatASP.Application.ExceptionsProjekat;
using ProjekatASP.Application.SearchesProjekat;

namespace ProjekatASP.EfCommands.KorisnikCommands.WebCommand
{
    public class EFGetKorisniciWEBCommand : EFBaseCommand, IGetKorisniciWEBCommand
    {
        public EFGetKorisniciWEBCommand(ProjekatASPContext context) : base(context)
        {
        }

        public IEnumerable<KorisnikGetWebDto> Execute(KorisnikSearch request)
        {
             var korisnik = Context.Korisniks.AsQueryable();

            if (request.Email != null)
            {
                var dajMail = request.Email;
                korisnik = korisnik.Where(kor => kor.Email.ToLower().Contains(dajMail.ToLower()) && kor.Obrisano == false);
            }

            if (request.Email != null)
            {
                var dajMail = request.Email;
                korisnik = korisnik.Where(kor => kor.Email.ToLower().Contains(dajMail.ToLower()) && kor.Obrisano == true);
                throw new DataNotFoundException();
            }

            if (request.Aktivan == false)
            {
                korisnik = korisnik.Where(k => k.Obrisano == request.Aktivan);
            }

            var ko = korisnik.Include(u => u.Uloga).Select(kor => new KorisnikGetWebDto
            {
                Id = kor.Id,
                Ime = kor.Ime,
                Prezime = kor.Prezime,
                Email = kor.Email,
                NazivUloge = kor.Uloga.Naziv
            });
            return ko;
        }
        }
    
}
