using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using ProjekatASP.Application.CommandsProjekat.KorisnikCommands;
using ProjekatASP.Application.DTO.KorisnikDTO;
using ProjekatASP.Application.ExceptionsProjekat;
using ProjekatASP.Application.SearchesProjekat;

namespace ProjekatASP.EfCommands.KorisnikCommands
{
    public class EFGetKorisniciCommand : EFBaseCommand , IGetKorisniciCommand
    {
        public EFGetKorisniciCommand(ProjekatASPContext context) : base(context)
        {
        }

        public IEnumerable<KorisnikGetDto> Execute(KorisnikSearch request)
        {
            var korisnik = Context.Korisniks.AsQueryable();
            /*if(request.Aktivan == false)
            {
                korisnik = korisnik.Where(kor => kor.Obrisano == request.Aktivan);
                throw new DataNotFoundException("ne postoji");
            }*/
            if(request.Email != null)
            {
                var dajMail = request.Email;
                korisnik = korisnik.Where(kor => kor.Email.ToLower().Contains(dajMail.ToLower()) && kor.Obrisano == false);
            }

            return korisnik.Select(kor => new KorisnikGetDto
            {
                Id = kor.Id,
                Ime = kor.Ime,
                Prezime = kor.Prezime,
                Email = kor.Email,
                UlogaId = kor.UlogaId,
                NazivUloge = kor.Uloga.Naziv
            });
        }
    }
}
