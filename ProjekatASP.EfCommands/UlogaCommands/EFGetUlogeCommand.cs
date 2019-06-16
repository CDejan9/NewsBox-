using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using ProjekatASP.Application.CommandsProjekat.UlogaCommands;
using ProjekatASP.Application.DTO.UlogaDTO;
using ProjekatASP.Application.SearchesProjekat;

namespace ProjekatASP.EfCommands.UlogaCommands
{
    public class EFGetUlogeCommand : EFBaseCommand, IGetUlogeCommand
    {
        public EFGetUlogeCommand(ProjekatASPContext context) : base(context)
        {
        }

        public IEnumerable<UlogaGetDto> Execute(UlogaSearch request)
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
            }*/
            if (request.Aktivan == false)
            {
                uloga = uloga.Where(k => k.Obrisano == request.Aktivan);
            }

            return uloga.Select(u => new UlogaGetDto
            {
                Id = u.Id,
                Naziv = u.Naziv
            });
        }
    }
}
