using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application.CommandsProjekat.UlogaCommands;
using ProjekatASP.Application.DTO.UlogaDTO;
using ProjekatASP.Application.ExceptionsProjekat;
using ProjekatASP.Application.SearchesProjekat;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjekatAsp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UlogaController : Controller
    {
        private readonly IAddUlogaCommand _addUloga;
        private readonly IGetUlogeCommand _getUloge;
        private readonly IGetUlogaCommand _getUloga;
        private readonly IDeleteUlogaCommand _deleteUloga;
        private readonly IEditUlogaCommand _editUloga;

        public UlogaController(IAddUlogaCommand addUloga, IGetUlogeCommand getUloge, IGetUlogaCommand getUloga, IDeleteUlogaCommand deleteUloga, IEditUlogaCommand editUloga)
        {
            _addUloga = addUloga;
            _getUloge = getUloge;
            _getUloga = getUloga;
            _deleteUloga = deleteUloga;
            _editUloga = editUloga;
        }




        // GET: api/uloga
        [HttpGet]
        public ActionResult<IEnumerable<UlogaGetDto>> Get([FromQuery] UlogaSearch search)
        {
            try
            {
                return Ok(_getUloge.Execute(search));
            }
            catch(DataNotFoundException)
            {
                return NotFound("Uloga sa tim nazivom ne postoji");
            }
            
        }

        // GET api/uloga/5
        [HttpGet("{id}", Name = "GetUloga")]
        public ActionResult<IEnumerable<UlogaGetDto>> Get(int id)
        {
            try
            {
                return Ok(_getUloga.Execute(id));
            }
            catch(DataNotFoundException)
            {
                return NotFound("Uloga sa tim ID-ijem ne postoji");
            }
        }

        // POST api/uloga
        [HttpPost]
        public ActionResult Post([FromBody] UlogaInsertDto value)
        {
            try
            {
                _addUloga.Execute(value);
                return StatusCode(201, "Uspesno ste kreirali ulogu");
            }
            catch(DataAlreadyExistsException)
            {
                return Conflict("Vec postoji Uloga sa tim nazivom");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske na serveru pokusajte ponovo");

            }
        }

        // PUT api/uloga/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UlogaGetDto dto)
        {
            try
            {
                _editUloga.Execute(dto);
                return StatusCode(204);
            }
            catch(DataAlreadyExistsException)
            {
                return Conflict("Vec postoji Uloga sa tim nazivom");
            }
            catch(DataNotFoundException)
            {
                return NotFound("Uloga sa tim ID-ijem ne postoji");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske na serveru pokusajte ponovo");
            }
        }

        // DELETE api/uloga/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteUloga.Execute(id);
                return StatusCode(204);
            }
            catch(DataNotFoundException)
            {
                return NotFound("Uloga sa tim ID-ijem ne postoji");
            }
            catch(DataAlreadyExistsException)
            {
                return Conflict("Postoje korisnici sa tom ulogom");
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
