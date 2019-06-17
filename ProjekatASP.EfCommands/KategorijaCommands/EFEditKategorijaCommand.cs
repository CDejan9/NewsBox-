using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using ProjekatASP.Application.CommandsProjekat.KategorijaCommands;
using ProjekatASP.Application.DTO.KategorijaDTO;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.KategorijaCommands
{
    public class EFEditKategorijaCommand : EFBaseCommand, IEditKategorijaCommand
    {
        public EFEditKategorijaCommand(ProjekatASPContext context) : base(context)
        {
        }

        public void Execute(KategorijaGetDto request)
        {
            var kat = Context.Kategorijas.Find(request.Id);
            if (kat == null || kat.Obrisano == true)
            {
                throw new DataNotFoundException();
            }
            if(request.Naziv == kat.Naziv)
            {
                throw new DataAlreadyExistsException();
            }
            if(Context.Kategorijas.Any(k => k.Naziv == request.Naziv))
            {
                throw new DataAlreadyExistsException();
            }

            kat.Naziv = request.Naziv;
            kat.Modifikovano = DateTime.Now;
            Context.SaveChanges();
       
        }
    }
}
