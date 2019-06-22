using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application.CommandsProjekat.KategorijaCommands;
using ProjekatASP.Application.DTO.KategorijaDTO;
using ProjekatASP.Application.ExceptionsProjekat;
using ProjekatASP.Application.SearchesProjekat;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjekatAsp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorijaController : ControllerBase
    {
        private readonly IAddKategorijaCommand _addKategorija;
        private readonly IGetKategorijeCommand _getKategorije;
        private readonly IGetKategorijaCommand _getKategorija;
        private readonly IDeleteKategorijaCommand _deleteKategorija;
        private readonly IEditKategorijaCommand _editKategorija;

        public KategorijaController(IAddKategorijaCommand addKategorija, IGetKategorijeCommand getKategorije, IGetKategorijaCommand getKategorija, IDeleteKategorijaCommand deleteKategorija, IEditKategorijaCommand editKategorija)
        {
            _addKategorija = addKategorija;
            _getKategorije = getKategorije;
            _getKategorija = getKategorija;
            _deleteKategorija = deleteKategorija;
            _editKategorija = editKategorija;
        }

        // GET: api/kategorija
        /// <summary>
        /// Dohvata kategorije uz mogucnost pretrage po nazivu kategoije
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///     {
        ///        "Id": "",
        ///        "Naziv": "Naziv kategoije",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Vraca trazene kategorije</response>
        /// /// <response code="404">Ako kategorija ne postoji</response>
        [HttpGet]
        public ActionResult<IEnumerable<KategorijaGetDto>> Get([FromQuery] KategorijaSearch search)
        {
            try
            {
                return Ok(_getKategorije.Execute(search));
            }
            
              catch (DataNotFoundException)
            {
                return NotFound("Kategorija sa tim Nazivom ne postoji");
            }
        }

        // GET api/kategorija/5
        /// <summary>
        /// Dohvata kategoriju po id-u.
        /// </summary>
        /// <response code="200">Vraca trazenog kategoriju</response>
        /// <response code="404">Ako ne postoji kategoriju sa tim id-om</response> 
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<KategorijaGetDto>> Get(int id)
        {
            try
            {
                return Ok(_getKategorija.Execute(id));
            }
            catch(DataNotFoundException)
            {
                return NotFound("Kategorija sa tim ID-ijem ne postoji");
            }
        }

        // POST api/kategorija
        /// <summary>
        /// Dodavanje nove kategorije
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "Naziv": "Neki naziv",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Dodaje novu kategoriju</response>
        /// <response code="409">Postoiji kategorija sa tim nazivom</response>
        /// <response code="500">Serverska greska</response>

        [HttpPost]
        public ActionResult Post([FromBody] KategorijaInsertDto value)
        {
            try
            {
                _addKategorija.Execute(value);
                return StatusCode(201, "Uspesno ste kreirali kategoriju");
            }
            catch (DataAlreadyExistsException)
            {
                return Conflict("Postoji kategorija sa tim nazivom");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        // PUT api/kategorija/5
        /// <summary>
        /// Izmena postojeceg kategorije
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///    PUT
        ///     {
        ///        "Naziv": "Neki naziv",
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Izmena kategorije</response>
        /// <response code="409">Kategorija sa tim nazivom vec postoji</response>
        /// <response code="404">Kategorija sa tim ID-ijem ne postoji</response>
        /// <response code="500">Serverska greska</response> 
        [HttpPut("{id}")]
        [Produces("application/json")]
        public ActionResult Put(int id, [FromBody]KategorijaGetDto dto)
        {
            try
            {
                _editKategorija.Execute(dto);
                return StatusCode(204);
            }
            catch (DataAlreadyExistsException)
            {
                return Conflict("Postoji kategorija sa tim nazivom");
            }
            catch (DataNotAlteredException)
            {
                return NotFound("Ne postoji kategorija koju zelite da izmenite");
            }
            catch (Exception)
            {
                return StatusCode(500, "Serverska greska pri izmeni kategorije, pokusajte ponovo!");
            }
        }

        // DELETE api/kategorija/5
        /// <summary>
        /// Brise kategoriju
        /// </summary>
        /// <response code="204">Brise kategoriju</response>
        /// <response code="409">Postoje vesti za izabranu kategoriju</response>
        /// <response code="404">Kategorija sa tim id-om ne postoji</response>
        /// <response code="500">Serverska greska</response> 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteKategorija.Execute(id);
                return StatusCode(204);
            }
            catch(DataAlreadyExistsException)
            {
                return Conflict("Postoje vesti za izabranu kategoriju");
            }
            catch (DataNotFoundException)
            {
                return NotFound("Ne postoji kategorija koju zelite da obrisete");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
    }
}
