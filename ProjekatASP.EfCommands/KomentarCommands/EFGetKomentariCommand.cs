using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using ProjekatASP.Application.CommandsProjekat.KomentarCommand;
using ProjekatASP.Application.DTO.KomentarDTO;
using ProjekatASP.Application.ExceptionsProjekat;
using ProjekatASP.Application.Responsed;
using ProjekatASP.Application.SearchesProjekat;

namespace ProjekatASP.EfCommands.KomentarCommands
{
    public class EFGetKomentariCommand : EFBaseCommand, IGetKomentariCommmand
    {
        public EFGetKomentariCommand(ProjekatASPContext context) : base(context)
        {
        }

        public PagedRespone<KomentarKorisnikVestGetDto> Execute(KomentarSearch request)
        {
            var query = Context.Komentars.AsQueryable();

            if (request.TekstKomentara != null)
            {
                var dajTekst = request.TekstKomentara.ToLower();
                query = query.Where(c => c.Komentar_Tekst.ToLower().Contains(dajTekst) &&
                 c.Obrisano == false);
            }

            if (request.TekstKomentara != null)
            {
                var dajTekst = request.TekstKomentara.ToLower();
                query = query.Where(c => c.Komentar_Tekst.ToLower().Contains(dajTekst) &&
                 c.Obrisano != false);
                throw new DataNotFoundException();
            }
            query = query.Where(c => c.Obrisano == false);

            var totalCount = query.Count();

            query = query.Skip((request.BrojStrane - 1) * request.PoStrani)
                .Take(request.PoStrani);

            var pageCount = (int)Math.Ceiling((double)totalCount / request.PoStrani);

            var res = new PagedRespone<KomentarKorisnikVestGetDto>
            {
                TrenutnaStrana = request.BrojStrane,
                UkupnoPronadjeno = totalCount,
                BrojStrana = pageCount,
                Data = query.Select(c => new KomentarKorisnikVestGetDto
                {
                    Id = c.Id,
                    VestId = c.VestId,
                    VestNaslov = c.Vest.Naslov,
                    KorisnikId = c.KorisnikId,
                    KorisnikEmail = c.Korisnik.Email
                })
            };
            return res;
        }
    }
}
