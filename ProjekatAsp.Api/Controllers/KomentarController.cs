using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application.CommandsProjekat.KomentarCommand;
using ProjekatASP.Application.DTO.KomentarDTO;
using ProjekatASP.Application.ExceptionsProjekat;

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

        public KomentarController(IAddKomentarCommand addKomentar, IDeleteKomentarCommand deleteKomentar, IEditKomentarCommand editKomentar)
        {
            _addKomentar = addKomentar;
            _deleteKomentar = deleteKomentar;
            _editKomentar = editKomentar;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] KomentarInsertDto value)
        {
            try
            {
                _addKomentar.Execute(value);
                return StatusCode(201);
            }
            catch (DataAlreadyExistsException)
            {
                return Conflict();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]KomentarGetDto dto)
        {
            try
            {
                _editKomentar.Execute(dto);
                return NoContent();
            }
            catch (DataNotFoundException)
            {
                return NotFound("Komentar");
            }
            catch (DataAlreadyExistsException)
            {
                return Conflict();
            }
            catch (DataNotAlteredException)
            {
                return Conflict();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteKomentar.Execute(id);
                return NoContent();
            }
            catch (DataNotFoundException)
            {
                return NotFound("Komentar sa tim Id-ijem");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
