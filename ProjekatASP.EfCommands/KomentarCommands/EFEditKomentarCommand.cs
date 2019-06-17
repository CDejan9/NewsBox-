using System;
using System.Collections.Generic;
using System.Text;
using EfDataAccess;
using ProjekatASP.Application.CommandsProjekat.KomentarCommand;
using ProjekatASP.Application.DTO.KomentarDTO;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.KomentarCommands
{
    public class EFEditKomentarCommand : EFBaseCommand, IEditKomentarCommand
    {
        public EFEditKomentarCommand(ProjekatASPContext context) : base(context)
        {
        }

        public void Execute(KomentarGetDto request)
        {
            var kom = Context.Komentars.Find(request.Id);
            if (kom == null || kom.Obrisano == true)
            {
                throw new DataNotFoundException();
            }
            
            if (kom.Komentar_Tekst != request.TekstKomentara)
            {
                kom.Komentar_Tekst = request.TekstKomentara;
                kom.Modifikovano = DateTime.Now;
                Context.SaveChanges();
            }
            else
            {
                throw new DataNotAlteredException();
            }
               
        }
    }
}
