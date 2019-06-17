using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.CommandsProjekat.KategorijaCommands;
using ProjekatASP.Application.DTO.KategorijaDTO;
using ProjekatASP.Application.Responsed;
using ProjekatASP.Application.SearchesProjekat;

namespace ProjekatASP.EfCommands.KategorijaCommands
{
    public class EFGetKategorijeCommand : EFBaseCommand , IGetKategorijeCommand
    {
        public EFGetKategorijeCommand(ProjekatASPContext context) : base(context)
        {
        }

        public PagedRespone<KategorijaGetDtoBezVesti> Execute(KategorijaSearch request)
        {
            var query = Context.Kategorijas.AsQueryable();

            if (request.Naziv != null)
            {
                var dajNaziv = request.Naziv.ToLower();
                query = query.Where(k => k.Naziv.ToLower().Contains(dajNaziv) && k.Obrisano == false);
            }
            if (request.Aktivan == false)
            {
                query = query.Where(k => k.Obrisano == request.Aktivan);
            }

            var totalCount = query.Count();

            query = query.Skip((request.BrojStrane - 1) * request.PoStrani)
                .Take(request.PoStrani);

            var pageCount = (int)Math.Ceiling((double)totalCount / request.PoStrani);


            var response = new PagedRespone<KategorijaGetDtoBezVesti>
            {
                TrenutnaStrana = request.BrojStrane,
                UkupnoPronadjeno = totalCount,
                BrojStrana = pageCount,
                Data = query.Select(kat => new KategorijaGetDtoBezVesti
                {
                    Id = kat.Id,
                    Naziv = kat.Naziv
                })
            };
            return response;
        }

        
    }
}
