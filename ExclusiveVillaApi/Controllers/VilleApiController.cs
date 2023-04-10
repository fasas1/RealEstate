using AutoMapper;
using ExclusiveVillaApi.Data;
using ExclusiveVillaApi.Models;
using ExclusiveVillaApi.Models.DTO;
using ExclusiveVillaApi.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExclusiveVillaApi.Controllers
{
    [ApiController]
    [Route("api/VilleApi")]

    public class VilleApiController : ControllerBase
    {
        private readonly IVilleRepository _dbVille;
        private readonly IMapper _mapper;
        public VilleApiController(IVilleRepository dbVille, IMapper mapper)
        {
            _dbVille = dbVille;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult <IEnumerable<VilleDTO>>> GetVilles()
        {
            IEnumerable<Ville> villeList = await _dbVille.GetAllAsync();

            return Ok(_mapper.Map<List<VilleDTO>>(villeList));
        }

        [HttpGet("{id:int}", Name = "GetVille")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VilleDTO>> GetVille(int id)
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
            return Ok(_mapper.Map<VilleDTO>(ville));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VilleDTO>> CreateVilla([FromBody] VilleCreateDTO createDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (await _dbVille.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Custom Error", "Villa Already Exists!");
                return BadRequest(ModelState);
            }
            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }
      
            Ville model = _mapper.Map<Ville>(createDTO);
        
           await _dbVille.CreateAsync(model);
           return CreatedAtRoute("GetVille", new { id = model.Id}, model);
        }

        [HttpDelete("{id:int}", Name = "DeleteVille")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteVille(int id)
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
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VilleUpdateDTO updateDTO)
        {
            if(updateDTO == null || id != updateDTO.Id)
            {
                return BadRequest();
            }
       
            Ville model = _mapper.Map<Ville>(updateDTO);

            await _dbVille.UpdateAsync(model);
          
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VilleUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var ville = await _dbVille.GetAsync(u => u.Id == id, tracked:false);
            VilleUpdateDTO villeDTO = _mapper.Map<VilleUpdateDTO>(ville);
           
            if (ville == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(villeDTO, ModelState);

            Ville model = _mapper.Map<Ville>(villeDTO);
           
            await  _dbVille.UpdateAsync(model);
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
