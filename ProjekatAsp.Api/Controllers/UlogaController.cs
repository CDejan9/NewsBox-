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
        public IActionResult Get([FromQuery] UlogaSearch search)
        {
            return Ok(_getUloge.Execute(search));
        }

        // GET api/uloga/5
        [HttpGet("{id}", Name = "GetUloga")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_getUloga.Execute(id));
            }
            catch(DataNotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/uloga
        [HttpPost]
        public IActionResult Post([FromBody] UlogaInsertDto value)
        {
            try
            {
                _addUloga.Execute(value);
                return StatusCode(201, "Uspesno kreirano");
            }
            catch(DataAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                // return StatusCode(500, "Doslo je do greske na serveru");
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/uloga/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UlogaGetDto dto)
        {
            try
            {
                _editUloga.Execute(dto);
                return StatusCode(204, "Uspesno izmenjena Uloga");
            }
            catch(DataAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
            catch(DataNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Serverska greska pri izmeni uloge, pokusajte ponovo!");
            }
        }

        // DELETE api/uloga/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteUloga.Execute(id);
                return StatusCode(204);
            }
            catch(DataNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
