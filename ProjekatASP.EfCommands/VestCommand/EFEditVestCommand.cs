using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using ProjekatASP.Application.CommandsProjekat.VestCommands;
using ProjekatASP.Application.DTO.VestDTO;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.VestCommand
{
    public class EFEditVestCommand : EFBaseCommand, IEditVestCommand
    {
        public EFEditVestCommand(ProjekatASPContext context) : base(context)
        {
        }

        public void Execute(VestGetDto request)
        {
            var vest = Context.Vests.Find(request.Id);
            if(vest == null || vest.Obrisano == true)
            {
                throw new DataNotFoundException("Vest ne postoji");
            }
            if(!String.IsNullOrEmpty(request.Naslov))
            {
                if(Context.Vests.Any(v => v.Naslov == request.Naslov))
                {
                    throw new DataAlreadyExistsException("Postoji vest da tim imenom");
                }
                else
                {
                    vest.Naslov = request.Naslov;
                }
            }

            if (!String.IsNullOrEmpty(request.Tekst))
            {
                vest.Tekst = request.Tekst;
            }

            if(!Context.Kategorijas.Any(k => k.Id == request.KategorijaId))
            {
                throw new DataNotFoundException("Kategorija");
            }
            else
            {
                vest.KategorijaId = request.KategorijaId;
            }

            vest.Modifikovano = DateTime.Now;
            Context.SaveChanges();
        }
    }
}
