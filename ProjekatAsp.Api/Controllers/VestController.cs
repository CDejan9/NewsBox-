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
        [HttpGet]
        public IActionResult Get([FromQuery] VestSearch search)
        {
            return Ok(_getVesti.Execute(search));
        }

        // GET api/vest/5
        [HttpGet("{id}", Name = "getVest")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_getVest.Execute(id));
            }
            catch (DataNotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/vest
        [HttpPost]
        public IActionResult Post([FromForm] ApiVestDto apiDto)
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
                catch (DataAlreadyExistsException e)
                {
                    return Conflict(e.Message);
                }
                catch (DataNotFoundException e)
                {
                    return NotFound(e.Message);
                }
                catch (Exception e)
                {
                    return StatusCode(500,e.Message);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT api/vest/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]VestGetDto dto)
        {
            try
            {
                _editVest.Execute(dto);
                return NoContent();
            }
            catch (DataNotFoundException)
            {
                return NotFound();
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

        // DELETE api/vest/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteVest.Execute(id);
                return StatusCode(204);
            }
            catch (DataNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
