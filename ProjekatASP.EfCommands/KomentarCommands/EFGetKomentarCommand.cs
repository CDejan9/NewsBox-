using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using ProjekatASP.Application.CommandsProjekat.KomentarCommand;
using ProjekatASP.Application.DTO.KomentarDTO;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.KomentarCommands
{
    public class EFGetKomentarCommand : EFBaseCommand, IGetKomentarCommand
    {
        public EFGetKomentarCommand(ProjekatASPContext context) : base(context)
        {
        }

        public KomentarKorisnikVestGetDto Execute(int request)
        {
            var kom = Context.Komentars.Find(request);

            if (kom == null || kom.Obrisano == true)
            {
                throw new DataNotFoundException();
            }

            return new KomentarKorisnikVestGetDto
            {
                Id = kom.Id,
                KomentarTekst = kom.Komentar_Tekst,
                VestId = kom.VestId,
               // VestNaslov = kom.Vest.Naslov,
                KorisnikId = kom.KorisnikId,
               // KorisnikEmail = kom.Korisnik.Email
            };
        }
    }
}
