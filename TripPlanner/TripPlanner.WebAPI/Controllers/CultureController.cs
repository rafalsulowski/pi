using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models.Models;
using TripPlanner.Models.DTO;
using TripPlanner.Services.CultureService;
namespace TripPlanner.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultureController : ControllerBase
    {
        private readonly ICultureService _CultureService;

        public CultureController(ICultureService CultureService)
        {
            _CultureService = CultureService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<Culture>>>> Get()
        {
            var response = await _CultureService.GetCulturesAsync();
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Culture>>> Get(int id)
        {
            var response = await _CultureService.GetCultureAsync(u => u.Id == id);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Data);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<RepositoryResponse<Culture>>> Post([FromBody] CultureDTO Culture)
        {
            
            Culture newCulture = new Culture
            {
                
            };

            var response = await _CultureService.CreateCulture(newCulture);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Culture>>> Put([FromBody] Culture Culture)
        {
            var response = await _CultureService.UpdateCulture(Culture);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _CultureService.DeleteCulture(new Culture() { Id = id });
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Data);
            }
        }
    }
}
