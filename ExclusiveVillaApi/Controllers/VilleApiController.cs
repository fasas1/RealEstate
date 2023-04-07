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
        public VilleApiController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult <IEnumerable<VilleDTO>>> GetVilles()
        {
            return Ok(await _db.Villes.ToListAsync());
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
            return Ok(ville);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VilleDTO>> CreateVilla([FromBody] VilleCreateDTO villeDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (await _db.Villes.FirstOrDefaultAsync(u => u.Name.ToLower() == villeDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Custom Error", "Villa Already Exists!");
                return BadRequest(ModelState);
            }
            if (villeDTO == null)
            {
                return BadRequest(villeDTO);
            }
            //if (villeDTO.Id > 0)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}
            Ville model = new()
            {
                Amenity = villeDTO.Amenity,
                Name = villeDTO.Name,
                Occupancy = villeDTO.Occupancy,
                Details = villeDTO.Details,
                Rate = villeDTO.Rate,
                Sqft = villeDTO.Sqft
            };
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
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VilleUpdateDTO villeDTO)
        {
            if (villeDTO == null || id != villeDTO.Id)
            {
                return BadRequest();
            }
            //var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
            //villa.Name = villaDTO.Name;
            //villa.Sqft = villaDTO.Sqft;
            //villa.Occupancy = villaDTO.Occupancy;
            Ville model = new()
            {
                Amenity = villeDTO.Amenity,
                Name = villeDTO.Name,
                Id = villeDTO.Id,
                Occupancy = villeDTO.Occupancy,
                Details = villeDTO.Details,
                Rate = villeDTO.Rate,
                Sqft = villeDTO.Sqft
            };
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

            VilleUpdateDTO villeDTO = new()
            {
                Amenity = ville.Amenity,
                Name = ville.Name,
                Id = ville.Id,
                Occupancy = ville.Occupancy,
                Details = ville.Details,
                Rate = ville.Rate,
                Sqft = ville.Sqft
            };
            if (ville == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(villeDTO, ModelState);
            Ville    model = new()
            {
                Amenity = villeDTO.Amenity,
                Name = villeDTO.Name,
                Id = villeDTO.Id,
                Occupancy = villeDTO.Occupancy,
                Details = villeDTO.Details,
                Rate = villeDTO.Rate,
                Sqft = villeDTO.Sqft
            };
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
