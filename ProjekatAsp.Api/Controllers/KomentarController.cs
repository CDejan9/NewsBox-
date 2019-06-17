using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application.CommandsProjekat.KomentarCommand;
using ProjekatASP.Application.DTO.KomentarDTO;
using ProjekatASP.Application.ExceptionsProjekat;
using ProjekatASP.Application.SearchesProjekat;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjekatAsp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KomentarController : Controller
    {
        private readonly IAddKomentarCommand _addKomentar;
        private readonly IDeleteKomentarCommand _deleteKomentar;
        private readonly IEditKomentarCommand _editKomentar;
        private readonly IGetKomentariCommmand _getKomentari;
        private readonly IGetKomentarCommand _getKomentar;

        public KomentarController(IAddKomentarCommand addKomentar, IDeleteKomentarCommand deleteKomentar, IEditKomentarCommand editKomentar, IGetKomentariCommmand getKomentari, IGetKomentarCommand getKomentar)
        {
            _addKomentar = addKomentar;
            _deleteKomentar = deleteKomentar;
            _editKomentar = editKomentar;
            _getKomentari = getKomentari;
            _getKomentar = getKomentar;
        }



        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<KomentarKorisnikVestGetDto>> Get([FromQuery] KomentarSearch search)
        {
            try
            {
                return Ok(_getKomentari.Execute(search));
            }
            catch(DataNotFoundException)
            {
                return NotFound("Ne postoji komentar sa tim sadrzajem");
            }
            
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetKomentar")]
        public ActionResult<IEnumerable<KomentarKorisnikVestGetDto>> Get(int id)
        {
            try
            {
                return Ok(_getKomentar.Execute(id));
            }
            catch (DataNotFoundException)
            {
                return NotFound("Ne postoji komentar");
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] KomentarInsertDto value)
        {
            try
            {
                _addKomentar.Execute(value);
                return StatusCode(201,"Komentar uspesno dodat");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]KomentarGetDto dto)
        {
            try
            {
                _editKomentar.Execute(dto);
                return NoContent();
            }
            catch (DataNotFoundException)
            {
                return NotFound("Ne postoji komentar sa tim ID-ijem");
            }
            catch (DataAlreadyExistsException)
            {
                return Conflict();
            }
            catch (Exception)
            {
                return StatusCode(500, "Greska na serveru, pokusajte ponovo");
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteKomentar.Execute(id);
                return NoContent();
            }
            catch (DataNotFoundException)
            {
                return NotFound("Ne postoji komentar sa tim Id-ijem");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
