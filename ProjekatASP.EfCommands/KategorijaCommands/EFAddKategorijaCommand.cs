using EfDataAccess;
using ProjekatAsp.Domain;
using ProjekatASP.Application.CommandsProjekat.KategorijaCommands;
using ProjekatASP.Application.DTO.KategorijaDTO;
using ProjekatASP.Application.ExceptionsProjekat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.EfCommands.KategorijaCommands
{
    public class EFAddKategorijaCommand : EFBaseCommand, IAddKategorijaCommand
    {
        public EFAddKategorijaCommand(ProjekatASPContext context) : base(context)
        {
        }

        public void Execute(KategorijaInsertDto request)
        {
            if(Context.Kategorijas.Any(k => k.Naziv == request.Naziv ))
            {
                throw new DataAlreadyExistsException();
            }
                
            Context.Kategorijas.Add(new Kategorija
            {
                Naziv = request.Naziv, //U naziv iz domena upisuje Naziv koji je dobio od requesta
                Kreirano = DateTime.Now
            });

            Context.SaveChanges();
        }
    }
}
