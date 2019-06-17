using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.CommandsProjekat.KategorijaCommands;
using ProjekatASP.Application.DTO.KategorijaDTO;
using ProjekatASP.Application.DTO.SlikaDTO1;
using ProjekatASP.Application.DTO.VestDTO;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.KategorijaCommands
{
    public class EFGetKategorijaCommand : EFBaseCommand, IGetKategorijaCommand
    {
        public EFGetKategorijaCommand(ProjekatASPContext context) : base(context)
        {
        }

        public KategorijaGetDto Execute(int request)
        {
            var data = Context.Kategorijas.Include(k => k.Vests)
                .ThenInclude(s => s.Slikas)
                .SingleOrDefault(k => k.Id == request);

            if (data == null || data.Obrisano == true)
            {
                throw new DataNotFoundException();
            }

            return new KategorijaGetDto
            {
                Id = data.Id,
                Naziv = data.Naziv,
                VestiKategorije = data.Vests.Select(v => new VestGetDto
                {
                    Id = v.Id,
                    Naslov = v.Naslov,
                    Tekst = v.Tekst,
                    KategorijaId = v.Kategorija.Id,
                    NazivKategorije = v.Kategorija.Naziv,
                    putanjaSlike = v.Slikas.Select(s => new SlikaGetDto
                    {
                        Putanja = s.Putanja
                    }).ToList()
                }).ToList()
            };
        }
    }
}
