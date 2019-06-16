using System;
using System.Collections.Generic;
using System.Text;
using EfDataAccess;
using ProjekatAsp.Domain;
using ProjekatASP.Application.CommandsProjekat.KomentarCommand;
using ProjekatASP.Application.DTO.KomentarDTO;

namespace ProjekatASP.EfCommands.KomentarCommands
{
    public class EFAddKomentarCommand : EFBaseCommand, IAddKomentarCommand
    {
        public EFAddKomentarCommand(ProjekatASPContext context) : base(context)
        {
        }

            public void Execute(KomentarInsertDto request)
            {
                Context.Komentars.Add(new Komentar
                {
                    Komentar_Tekst = request.KomentarTekst,
                    KorisnikId = request.KorisnikId,
                    VestId = request.VestId,
                    Kreirano = DateTime.Now
                });
                Context.SaveChanges();
            }
    }
}
