using ExclusiveVillaApi.Data;
using ExclusiveVillaApi.Models;
using ExclusiveVillaApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult <IEnumerable<VilleDTO>> GetVilles()
        {
            return Ok(_db.Villes.ToList());
        }

        [HttpGet("{id:int}", Name = "GetVille")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VilleDTO> GetVille(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var ville = _db.Villes.FirstOrDefault(u => u.Id == id);
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
        public ActionResult<VilleDTO> CreateVilla([FromBody] VilleDTO villeDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (_db.Villes.FirstOrDefault(u => u.Name.ToLower() == villeDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Custom Error", "Villa Already Exists!");
                return BadRequest(ModelState);
            }
            if (villeDTO == null)
            {
                return BadRequest(villeDTO);
            }
            if (villeDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
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
            _db.Villes.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetVille", new { id = villeDTO.Id }, villeDTO);
        }

        [HttpDelete("{id:int}", Name = "DeleteVill")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult DeleteVille(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var ville = _db.Villes.FirstOrDefault(u => u.Id == id);
            if (ville == null)
            {
                return NotFound();
            }
            _db.Villes.Remove(ville);
            _db.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VilleDTO villeDTO)
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
            _db.SaveChanges();
            return NoContent();
        }

    }
}
