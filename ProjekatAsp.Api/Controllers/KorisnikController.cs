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
        /// <summary>
        /// Dohvata korisnike uz mogucnost pretrage po E-mailu korisnika
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///     {
        ///        "Id": "ID korisnika",
        ///        "Ime": "Ime korisnika",
        ///        "Prezime" : "Prezime korisnik",
        ///        "Email" : "E=mail korisnika",
        ///        "Lozinka" : "null",
        ///        "UlogaId" : "ID uloge",
        ///        "Obrisan" : "bool",
        ///        "NazivUloge": "Naziv uloge korisnika"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Vraca trazene korisnike</response>
        /// <response code="404">Ako korisnik ne postoji</response>
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
        /// <summary>
        /// Dohvata korisnka po id-u.
        /// </summary>
        /// <response code="200">Vraca trazenog korisnika kao i njegove komentare</response>
        /// <response code="404">Ako ne postoji korinsik sa tim id-om</response> 
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
        /// <summary>
        /// Dodavanje novog korisnika
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "Id": "",
        ///        "Ime": "Ime korisnika",
        ///        "Prezime" : "Prezime korisnik",
        ///        "Email" : "E=mail korisnika",
        ///        "Lozinka" : "null",
        ///        "UlogaId" : "ID uloge",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Dodaje novog korisnika</response>
        /// <response code="404">Ako ne postoji dodeljena uloga</response>
        /// <response code="409">Ako korisnik sa tim E-mailom vec postoji</response>
        /// <response code="500">Serverska greska</response>
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
        /// <summary>
        /// Izmena postojeceg korisnika
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///    PUT
        ///     {
        ///         "Id": "ID korisnika",
        ///        "Ime": "Ime korisnika",
        ///        "Prezime" : "Prezime korisnik",
        ///        "Email" : "E=mail korisnika",
        ///        "Lozinka" : "null",
        ///        "UlogaId" : "ID uloge",
        ///        "Obrisan" : "bool",
        ///        "NazivUloge": "Naziv uloge korisnika"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Izmena korisnika</response>
        /// <response code="409">Korisnik sa tim E-mailom vec postoji</response>
        /// <response code="404">Korisnik sa tim ID-ijem ne postoji</response>
        /// <response code="500">Serverska greska</response> 
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
        /// <summary>
        /// Brise korinsika i sve njegove komentare
        /// </summary>
        /// <response code="204">Brise korinsika</response>
        /// <response code="404">Korinsik sa tim id-om ne postoji</response>
        /// <response code="500">Serverska greska</response> 
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
