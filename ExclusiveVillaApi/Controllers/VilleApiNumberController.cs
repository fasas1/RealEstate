using AutoMapper;
using ExclusiveVillaApi.Data;
using ExclusiveVillaApi.Models;
using ExclusiveVillaApi.Models.DTO;
using ExclusiveVillaApi.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Data;

namespace ExclusiveVillaApi.Controllers
{
    [Route("api/VilleApiNumber")]
    [ApiController]

    public class VilleApiNumberController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IVilleNumberRepository _dbVilleNumber;
        private readonly IVilleRepository _dbVille;
        private readonly IMapper _mapper;
        public VilleApiNumberController(IVilleNumberRepository dbVilleNumber, IMapper mapper,
            IVilleRepository dbVille)
        {
            _dbVilleNumber = dbVilleNumber;
            _mapper = mapper;
            this._response = new();
            _dbVille = dbVille;
        }


        //[HttpGet("GetString")]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "String1", "string2" };
        //}

        [HttpGet]

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVilleNumbers()
        {
            try
            {

                IEnumerable<VilleNumber> villeNumberList = await _dbVilleNumber.GetAllAsync();
                _response.Result = _mapper.Map<List<VilleNumberDTO>>(villeNumberList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;

        }


        [HttpGet("{id:int}", Name = "GetVilleNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villaNumber = await _dbVilleNumber.GetAsync(u => u.VilleNo == id);
                if (villaNumber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<VilleNumberDTO>(villaNumber);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VilleNumberCreateDTO createDTO)
        {
            try
            {

                //if (await _dbVilleNumber.GetAsync(u => u.VilleNo == createDTO.VilleNo) != null)
                //{
                //    ModelState.AddModelError("ErrorMessages", "Villa Number already Exists!");
                //    return BadRequest(ModelState);
                //}
                //if (await _dbVilla.GetAsync(u => u.Id == createDTO.VillaID) == null)
                //{
                //    ModelState.AddModelError("ErrorMessages", "Villa ID is Invalid!");
                //    return BadRequest(ModelState);
                //}
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                VilleNumber villaNumber = _mapper.Map<VilleNumber>(createDTO);


                await _dbVilleNumber.CreateAsync(villaNumber);
                _response.Result = _mapper.Map<VilleNumberDTO>(villaNumber);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = villaNumber.VilleNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteVilleNumber")]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villeNumber = await _dbVilleNumber.GetAsync(u => u.VilleNo == id);
                if (villeNumber == null)
                {
                    return NotFound();
                }
                await _dbVilleNumber.RemoveAsync(villeNumber);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateVilleNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VilleNumberUpdateDTO updateDTO)
        {
            try
            {
                //if (updateDTO == null || id != updateDTO.VilleNo)
                //{
                //    return BadRequest();
                //}
                //if (await _dbVille.GetAsync(u => u.Id == updateDTO.VilleID) == null)
                //{
                //    ModelState.AddModelError("ErrorMessages", "Villa ID is Invalid!");
                //    return BadRequest(ModelState);
                //}
                VilleNumber model = _mapper.Map<VilleNumber>(updateDTO);

                await _dbVilleNumber.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


    }
}