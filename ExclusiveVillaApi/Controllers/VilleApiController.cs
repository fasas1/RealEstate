using AutoMapper;
using ExclusiveVillaApi.Data;
using ExclusiveVillaApi.Models;
using ExclusiveVillaApi.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExclusiveVillaApi.Controllers
{
    [ApiController]
    [Route("api/VilleApi")]

    public class VilleApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public VilleApiController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult <IEnumerable<VilleDTO>>> GetVilles()
        {
            IEnumerable<Ville> villeList = await _db.Villes.ToListAsync();

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
            var ville = await _db.Villes.FirstOrDefaultAsync(u => u.Id == id);
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
            if (await _db.Villes.FirstOrDefaultAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Custom Error", "Villa Already Exists!");
                return BadRequest(ModelState);
            }
            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }
            //if (villeDTO.Id > 0)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}
            Ville model = _mapper.Map<Ville>(createDTO);
            //Ville model = new()
            //{
            //    Amenity = createDTO.Amenity,
            //    Name = createDTO.Name,
            //    Occupancy = createDTO.Occupancy,
            //    Details = createDTO.Details,
            //    Rate = createDTO.Rate,
            //    Sqft = createDTO.Sqft
            //};
           await _db.Villes.AddAsync(model);
           await _db.SaveChangesAsync();

            return CreatedAtRoute("GetVille", new { id = model.Id}, model);
        }

        [HttpDelete("{id:int}", Name = "DeleteVill")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteVille(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var ville = await _db.Villes.FirstOrDefaultAsync(u => u.Id == id);
            if (ville == null)
            {
                return NotFound();
            }
            _db.Villes.Remove(ville);
           await _db.SaveChangesAsync();
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
           
            _db.Villes.Update(model);
            await _db.SaveChangesAsync();
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
            var ville = await _db.Villes.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            VilleUpdateDTO villeDTO = _mapper.Map<VilleUpdateDTO>(ville);
           
            if (ville == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(villeDTO, ModelState);

            Ville model = _mapper.Map<Ville>(villeDTO);
           
            _db.Villes.Update(model);
            await _db.SaveChangesAsync();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
