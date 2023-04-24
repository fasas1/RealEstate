using AutoMapper;
using ExclusiveVillaApi.Data;
using ExclusiveVillaApi.Models;
using ExclusiveVillaApi.Models.DTO;
using ExclusiveVillaApi.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ExclusiveVillaApi.Controllers
{
    [ApiController]
    [Route("api/VilleApi")]

    public class VilleApiController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IVilleRepository _dbVille;
        private readonly IMapper _mapper;
        public VilleApiController(IVilleRepository dbVille, IMapper mapper)
        {
            _dbVille = dbVille;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> GetVilles()
        {
            try
            {
                IEnumerable<Ville> villeList = await _dbVille.GetAllAsync();
                _response.Result = _mapper.Map<List<VilleDTO>>(villeList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetVille")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVille(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var ville = await _dbVille.GetAsync((u => u.Id == id));
                if (ville == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<VilleDTO>(ville);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VilleCreateDTO createDTO)
        {
            try
            {
                if (await _dbVille.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Custom Error", "Villa Already Exists!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Ville ville = _mapper.Map<Ville>(createDTO);

                await _dbVille.CreateAsync(ville);
                _response.Result = _mapper.Map<VilleDTO>(ville);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVille", new { id = ville.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteVille")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> DeleteVille(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var ville = await _dbVille.GetAsync(u => u.Id == id);
                if (ville == null)
                {
                    return NotFound();
                }
                await _dbVille.RemoveAsync(ville);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateVille")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVille(int id, [FromBody] VilleUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }
                Ville ville= _mapper.Map<Ville>(updateDTO);

                await _dbVille.UpdateAsync(ville);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVille")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdatePartialVille(int id, JsonPatchDocument<VilleUpdateDTO> patchDTO)
        {

            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var ville = await _dbVille.GetAsync(u => u.Id == id, tracked: false);
            VilleUpdateDTO villeDTO = _mapper.Map<VilleUpdateDTO>(ville);

            if (ville == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(villeDTO, ModelState);

            Ville model = _mapper.Map<Ville>(villeDTO);

            await _dbVille.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

    }

}
