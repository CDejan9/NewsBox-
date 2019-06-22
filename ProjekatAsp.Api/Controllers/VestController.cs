using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjekatAsp.Api.Models;
using ProjekatASP.Application.CommandsProjekat.VestCommands;
using ProjekatASP.Application.DTO.VestDTO;
using ProjekatASP.Application.ExceptionsProjekat;
using ProjekatASP.Application.Helpers;
using Microsoft.AspNetCore.Http;
using ProjekatASP.Application.SearchesProjekat;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjekatAsp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VestController : Controller
    {
        private readonly IAddVestCommand _addVest;
        private readonly IGetVestiCommand _getVesti;
        private readonly IGetVestCommand _getVest;
        private readonly IEditVestCommand _editVest;
        private readonly IDeleteVestCommand _deleteVest;

        public VestController(IAddVestCommand addVest, IGetVestiCommand getVesti, IGetVestCommand getVest, IEditVestCommand editVest, IDeleteVestCommand deleteVest)
        {
            _addVest = addVest;
            _getVesti = getVesti;
            _getVest = getVest;
            _editVest = editVest;
            _deleteVest = deleteVest;
        }

        // GET: api/vest
        /// <summary>
        /// Dohvata Vest uz mogucnost pretrage po Naslovu vesti
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///     {
        ///        "Id": "ID vesti",
        ///        "Naslov": "Naslov vesti",
        ///        "Tekst" : "Teskt veti",
        ///        "KategorijaId" : "ID kategorije kojoj pripada",
        ///        "NazivKategorije" : "Naziv kategorije kojoj pripada",
        ///        "putanjaSlike" : "Putanja slike",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Vraca trazene vesti</response>
        /// <response code="404">Ako vest ne postoji</response>
        [HttpGet]
        public ActionResult<IEnumerable<VestGetDto>> Get([FromQuery] VestSearch search)
        {
            try
            {
                return Ok(_getVesti.Execute(search));
            }
            catch(DataNotFoundException)
            {
                return NotFound("Vest sa tim Nazivom ne postoji");
            }
        }

        // GET api/vest/5
        /// <summary>
        /// Dohvata vest po id-u.
        /// </summary>
        /// <response code="200">Vraca trazene vesti i njene komentare</response>
        /// <response code="404">Ako ne postoji vest sa tim id-om</response> 
        [HttpGet("{id}", Name = "getVest")]
        public ActionResult<IEnumerable<VestKomentarGetDto>> Get(int id)
        {
            try
            {
                return Ok(_getVest.Execute(id));
            }
            catch (DataNotFoundException)
            {
                return NotFound("Ne postoji vest");
            }
        }

        // POST api/vest
        /// <summary>
        /// Dodavanje nove vesti
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "Naslov": "Naslov vesti",
        ///        "Tekst" : "Teskt veti",
        ///        "KategorijaId" : "ID kategorije kojoj pripada",
        ///        "putanjaSlike" : "Putanja slike",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Dodaje novu vest</response>
        /// <response code="409">Ako vest sa tim Nazivom vec postoji</response>
        /// <response code="404">Ako ne postoji kategorija koja je dodeljena vesti</response>
        /// <response code="500">Serverska greska</response>
        [HttpPost]
        public ActionResult Post([FromForm] ApiVestDto apiDto)
        {
            try
            {
                var ext = Path.GetExtension(apiDto.Slika.FileName);

                if (!FileUpload.ValidExtensions.Contains(ext))
                {
                    return UnprocessableEntity("Format slike nije dozvoljen.");
                }
                try
                {                   //daje vrednost da slika bude jednistvena
                    var newFileName = Guid.NewGuid().ToString() + "_" + apiDto.Slika.FileName;

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "Vest", newFileName);

                    apiDto.Slika.CopyTo(new FileStream(filePath, FileMode.Create));

                    var dto = new VestInsertDto
                    {
                        Naslov = apiDto.Naslov,
                        Tekst = apiDto.Tekst,
                        KategorijaId = apiDto.KategorijaId,
                        PutanjaSlike = newFileName
                    };
                    _addVest.Execute(dto);
                    return StatusCode(201, "Uspesno kreirana vest");
                }
                catch (DataAlreadyExistsException)
                {
                    return Conflict("Vest sa tim naslovom vec postoji");
                }
                catch (DataNotFoundException)
                {
                    return NotFound("Kategorija koju ste dodelili vesti ne postoji");
                }
                catch (Exception)
                {
                    return StatusCode(500,"Greska na serveru pri unosu vesti, pokusajte ponovo");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Greska na serveru pri unosu slike, pokusajte ponovo");
            }
        }

        // PUT api/vest/5
        /// <summary>
        /// Izmena postojece vesti
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///    PUT
        ///     {
        ///        "Id": "ID vesti",
        ///        "Naslov": "Naslov vesti",
        ///        "Tekst" : "Teskt veti",
        ///        "KategorijaId" : "ID kategorije kojoj pripada",
        ///        "NazivKategorije" : "Naziv kategorije kojoj pripada"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Izmena vesti</response>
        /// <response code="409">Vec postoji vest sa tim nazivom</response>
        /// <response code="404">Vest sa tim ID-ijem ne postoji</response>
        /// <response code="500">Serverska greska</response> 
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]VestGetDto dto)
        {
            try
            {
                _editVest.Execute(dto);
                return NoContent();
            }
            catch (DataNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (DataAlreadyExistsException)
            {
                return Conflict("Postoji vest sa tim imenom");
            }
            catch (Exception)
            {
                return StatusCode(500, "Greska na serveru pokusajte ponovo");
            }
        }

        // DELETE api/vest/5
        /// <summary>
        /// Brise vest i sve njene komentare
        /// </summary>
        /// <response code="204">Brise vest</response>
        /// <response code="404">Vest sa tim id-om ne postoji</response>
        /// <response code="500">Serverska greska</response> 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteVest.Execute(id);
                return StatusCode(204);
            }
            catch (DataNotFoundException)
            {
                return NotFound("Vest sa tim ID-ijem ne postoji");
            }
            catch (Exception)
            {
                return StatusCode(500, "Greska na serveru pokusajte ponovo");
            }
        }
    }
}
