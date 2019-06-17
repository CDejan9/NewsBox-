using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application.CommandsProjekat.KorisnikCommands;
using ProjekatASP.Application.DTO.KorisnikDTO;
using ProjekatASP.Application.ExceptionsProjekat;
using ProjekatASP.Application.SearchesProjekat;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjekatAsp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : Controller
    {
        private readonly IAddKorisnikCommand _addKorisnik;
        private readonly IGetKorisniciCommand _getKorisnici;
        private readonly IGetKorisnikCommand _getKorisnik;
        private readonly IEditKorisnikCommand _editKorisnik;
        private readonly IDeleteKorisnikCommand _deleteKorisnik;

        public KorisnikController(IAddKorisnikCommand addKorisnik, IGetKorisniciCommand getKorisnici, IGetKorisnikCommand getKorisnik, IEditKorisnikCommand editKorisnik, IDeleteKorisnikCommand deleteKorisnik)
        {
            _addKorisnik = addKorisnik;
            _getKorisnici = getKorisnici;
            _getKorisnik = getKorisnik;
            _editKorisnik = editKorisnik;
            _deleteKorisnik = deleteKorisnik;
        }



        // GET: api/korisnik
        [HttpGet]
        public ActionResult<IEnumerable<KorisnikGetDto>> Get([FromQuery] KorisnikSearch search)
        {
            try
            {
                return Ok(_getKorisnici.Execute(search));
            }
            catch(DataNotFoundException)
            {
                return NotFound("Ne postoji korisnik sa tom E-mail adresom");
            }
        }

        // GET api/korisnik/5
        [HttpGet("{id}", Name = "GetKorisnik")]
        public ActionResult<IEnumerable<KorisnikGetKomentarDto>> Get(int id)
        {
            try
            {
                return Ok(_getKorisnik.Execute(id));
            }
            catch (DataNotFoundException)
            {
                return NotFound("Korisnik sa tim ID-ijem ne postoji");
            }
        }

        // POST api/korisnik
        [HttpPost]
        public ActionResult Post([FromBody]KorisnikInsertDto value)
        {
            try
            {
                _addKorisnik.Execute(value);
                return StatusCode(201, "Korisnik uspesno kreiran");
            }
            catch(DataNotFoundException)
            {
                return NotFound("Ne  postoji uloga koja je dodeljena korisniku");
            }
            catch(DataAlreadyExistsException)
            {
                return Conflict("Korinsik sa tim E - mailom vec postoji");
            }
            catch(Exception)
            {
                return StatusCode(500, "Greska na serveru, pokusajte ponovo");
            }
        }

        // PUT api/korisnik/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]KorisnikGetDto dto)
        {
            try
            {
                _editKorisnik.Execute(dto);
                return NoContent();
            }
            catch (DataNotFoundException)
            {
                return NotFound();
            }
            catch (DataAlreadyExistsException)
            {
                return Conflict("Korisnik sa tim Email-om vec postoji");
            }
            catch (DataNotAlteredException)
            {
                return Conflict();
            }
            catch (Exception)
            {
                return StatusCode(500, "Greska na serveru, pokusajte ponovo");
            }
        }

        // DELETE api/korisnik/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteKorisnik.Execute(id);
                return StatusCode(204);
            }
            catch (DataNotFoundException)
            {
                return NotFound("Korisnik koga zelite da obrisete ne postoji");
            }
            catch (Exception)
            {
                return StatusCode(500, "Greska na serveru, pokusajte ponovo");
            }
        }
    }
}
