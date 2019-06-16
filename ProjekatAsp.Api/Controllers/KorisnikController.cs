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
        public readonly IAddKorisnikCommand _addKorisnik;
        public readonly IGetKorisniciCommand _getKorisnici;

        public KorisnikController(IAddKorisnikCommand addKorisnik, IGetKorisniciCommand getKorisnici)
        {
            _addKorisnik = addKorisnik;
            _getKorisnici = getKorisnici;
        }



        // GET: api/korisnik
        [HttpGet]
        public IActionResult Get([FromQuery] KorisnikSearch search)
        {
            return Ok(_getKorisnici.Execute(search));
        }

        // GET api/korisnik/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/korisnik
        [HttpPost]
        public IActionResult Post([FromBody]KorisnikInsertDto value)
        {
            try
            {
                _addKorisnik.Execute(value);
                return StatusCode(201, "Korisnik uspesno kreiran");
            }
            catch(DataNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(DataAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/korisnik/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/korisnik/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
