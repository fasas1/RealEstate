using ExclusiveVillaApi.Data;
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
    }
}
