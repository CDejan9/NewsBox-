using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.CommandsProjekat.KorisnikCommands;
using ProjekatASP.Application.DTO.KorisnikDTO;
using ProjekatASP.Application.ExceptionsProjekat;
using ProjekatASP.Application.Responsed;
using ProjekatASP.Application.SearchesProjekat;

namespace ProjekatASP.EfCommands.KorisnikCommands
{
    public class EFGetKorisniciCommand : EFBaseCommand , IGetKorisniciCommand
    {
        public EFGetKorisniciCommand(ProjekatASPContext context) : base(context)
        {
        }

        public PagedRespone<KorisnikGetDto> Execute(KorisnikSearch request)
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

            var totalCount = korisnik.Count();

            korisnik = korisnik.Skip((request.BrojStrane - 1) * request.PoStrani)
                .Take(request.PoStrani);

            var pageCount = (int)Math.Ceiling((double)totalCount / request.PoStrani);


            var response = new PagedRespone<KorisnikGetDto>
            {
                TrenutnaStrana = request.BrojStrane,
                UkupnoPronadjeno = totalCount,
                BrojStrana = pageCount,
                Data = korisnik.Include(u => u.Uloga)
                .Select(kor => new KorisnikGetDto
                {
                    Id = kor.Id,
                    Ime = kor.Ime,
                    Prezime = kor.Prezime,
                    Email = kor.Email,
                    UlogaId = kor.UlogaId,
                    NazivUloge = kor.Uloga.Naziv,
                    Obrisan = kor.Obrisano
                })
            };
            return response;           
        }

        
    }
}
