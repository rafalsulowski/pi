using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models.Models;
using TripPlanner.Models.DTO;
using TripPlanner.Services.RouteService;
using Route = TripPlanner.Models.Models.Route;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _RouteService;

        public RouteController(IRouteService RouteService)
        {
            _RouteService = RouteService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<RouteDTO>>>> Get()
        {
            var response = await _RouteService.GetRoutesAsync();
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<RouteDTO>>> Get(int id)
        {
            var response = await _RouteService.GetRouteAsync(u => u.Id == id);
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
        public async Task<ActionResult<RepositoryResponse<RouteDTO>>> Post([FromBody] RouteDTO Route)
        {
            
            Route newRoute = new Route
            {
                
            };

            var response = await _RouteService.CreateRoute(newRoute);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Put([FromBody] Route Route)
        {
            var response = await _RouteService.UpdateRoute(Route);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _RouteService.DeleteRoute(new Route() { Id = id });
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
