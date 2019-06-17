using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.CommandsProjekat.VestCommands;
using ProjekatASP.Application.DTO.SlikaDTO1;
using ProjekatASP.Application.DTO.VestDTO;
using ProjekatASP.Application.ExceptionsProjekat;
using ProjekatASP.Application.Responsed;
using ProjekatASP.Application.SearchesProjekat;

namespace ProjekatASP.EfCommands.VestCommand
{
    public class EFGetVestiCommand : EFBaseCommand, IGetVestiCommand
    {
        public EFGetVestiCommand(ProjekatASPContext context) : base(context)
        {
        }

        public PagedRespone<VestGetDto> Execute(VestSearch request)
        {
            var vestObj = Context.Vests.Include(v => v.Kategorija).Include(v => v.Slikas).AsQueryable();

            if (request.KategorijaId != 0)
            {
                vestObj = vestObj.Where(v => v.KategorijaId == request.KategorijaId);
            }
            if (!String.IsNullOrEmpty(request.Naslov))
            {
                var dajNaslov = request.Naslov.ToLower();
                vestObj = vestObj.Where(v => v.Naslov.ToLower()
                .Contains(dajNaslov) 
                && v.Obrisano == false);
            }
            if (!String.IsNullOrEmpty(request.Naslov))
            {
                var dajNaslov = request.Naslov.ToLower();
                vestObj = vestObj.Where(v => v.Naslov.ToLower()
                .Contains(dajNaslov)
                && v.Obrisano != false);
                throw new DataNotFoundException();
            }

            vestObj = vestObj.Where(v => v.Obrisano == false);
           
            var totalCount = vestObj.Count();

            vestObj = vestObj.Skip((request.BrojStrane - 1) * request.PoStrani)
                .Take(request.PoStrani);

            var pageCount = (int)Math.Ceiling((double)totalCount / request.PoStrani);

            var response = new PagedRespone<VestGetDto>
            {
                TrenutnaStrana = request.BrojStrane,
                UkupnoPronadjeno = totalCount,
                BrojStrana = pageCount,
                Data = vestObj.Select(v => new VestGetDto
                {
                    Id = v.Id,
                    Naslov = v.Naslov,
                    KategorijaId = v.Kategorija.Id,
                    NazivKategorije = v.Kategorija.Naziv,
                    Tekst = v.Tekst,
                    putanjaSlike = v.Slikas.Select(s => new SlikaGetDto
                    {
                        Putanja = s.Putanja
                    }).ToList()
                })
            };
            return response;
        }
    }
}
