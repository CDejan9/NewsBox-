using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.CommandsProjekat.UlogaCommands;
using ProjekatASP.Application.DTO.UlogaDTO;
using ProjekatASP.Application.Responsed;
using ProjekatASP.Application.SearchesProjekat;

namespace ProjekatASP.EfCommands.UlogaCommands
{
    public class EFGetUlogeCommand : EFBaseCommand, IGetUlogeCommand
    {
        public EFGetUlogeCommand(ProjekatASPContext context) : base(context)
        {
        }

        public PagedRespone<UlogaGetDto> Execute(UlogaSearch request)
        {
            var uloga = Context.Ulogas.AsQueryable();
            if (request.Naziv != null)
            {
                var dajNaziv = request.Naziv;
                uloga = uloga.Where(u => u.Naziv.Contains(dajNaziv) && u.Obrisano == false);
            }
            /*if (request.Id != 0)
            {
                uloga = Context.Ulogas.Where(u => u.Id == request.Id);
            }
            */
            if (request.Aktivan == false)
            {
                uloga = uloga.Where(k => k.Obrisano == request.Aktivan);
            }

            var totalCount = uloga.Count();

            uloga = uloga.Skip((request.BrojStrane - 1) * request.PoStrani)
                .Take(request.PoStrani);

            var pageCount = (int)Math.Ceiling((double)totalCount / request.PoStrani);

            var response = new PagedRespone<UlogaGetDto>
            {
                TrenutnaStrana = request.BrojStrane,
                UkupnoPronadjeno = totalCount,
                BrojStrana = pageCount,
                Data = uloga.Select(ul => new UlogaGetDto
                {
                    Id = ul.Id,
                    Naziv = ul.Naziv,    
                })
            };
            return response;
        }
    }
}
