using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using ProjekatAsp.Domain;
using ProjekatASP.Application.CommandsProjekat.VestCommands;
using ProjekatASP.Application.DTO.VestDTO;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.VestCommand
{
    public class EFAddVestCommand : EFBaseCommand, IAddVestCommand
    {
        public EFAddVestCommand(ProjekatASPContext context) : base(context)
        {
        }

        public void Execute(VestInsertDto request)
        {
            if (Context.Vests.Where(v => v.Obrisano != true).Any(v => v.Naslov == request.Naslov))
            {
                throw new DataNotFoundException("vest sa tim naslovom");
            }
            if (!Context.Kategorijas.Where(k => k.Obrisano != true).Any(k => k.Id == request.KategorijaId))
            {
                throw new DataNotFoundException("kategorija kojoj ste dodelili vest");
            }

            var vest = new Vest
            {
                Naslov = request.Naslov,
                Tekst = request.Tekst,
                KategorijaId = request.KategorijaId,
                Kreirano = DateTime.Now
            };

            var slika = new Slika
            {
                Alt = request.Naslov,
                Kreirano = DateTime.Now,
                Putanja = request.PutanjaSlike
            };

            slika.Vest = vest;
            Context.Slikas.Add(slika);
            Context.SaveChanges();
        }
    }
}

