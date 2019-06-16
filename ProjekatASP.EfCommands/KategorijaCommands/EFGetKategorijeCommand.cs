using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.CommandsProjekat.KategorijaCommands;
using ProjekatASP.Application.DTO.KategorijaDTO;
using ProjekatASP.Application.SearchesProjekat;

namespace ProjekatASP.EfCommands.KategorijaCommands
{
    public class EFGetKategorijeCommand : EFBaseCommand , IGetKategorijeCommand
    {
        public EFGetKategorijeCommand(ProjekatASPContext context) : base(context)
        {
        }

        public IEnumerable<KategorijaGetDto> Execute(KategorijaSearch request)
        {
            var query = Context.Kategorijas.AsQueryable();

            if (request.Naziv != null)
            {
                var dajNaziv = request.Naziv;
                query = query.Where(k => k.Naziv.Contains(dajNaziv) && k.Obrisano == false);
            }

             if (request.Aktivan == false)
            {
                query = query.Where(k => k.Obrisano == request.Aktivan);
            }

            return query.Select(k => new KategorijaGetDto
            {
                Id = k.Id,
                Naziv = k.Naziv
            });
        }
    }
}
