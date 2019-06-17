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
