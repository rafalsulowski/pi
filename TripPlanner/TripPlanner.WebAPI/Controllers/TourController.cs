using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models.Models;
using TripPlanner.Models.DTO;
using TripPlanner.Services.TourService;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _TourService;

        public TourController(ITourService TourService)
        {
            _TourService = TourService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<Tour>>>> Get()
        {
            var response = await _TourService.GetToursAsync();
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Tour>>> Get(int id)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == id);
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
        public async Task<ActionResult<RepositoryResponse<Tour>>> Post([FromBody] TourDTO Tour)
        {
            //sprawdzenie czy uzytkownik nie stworzyl juz takiej wycieczki

            Tour newTour = new Tour
            {
                EndDate = Tour.EndDate,
                StartDate = Tour.StartDate,
                MaxParticipant = Tour.MaxParticipant,
                TargetCountry = Tour.TargetCountry,
                Title = Tour.Title,
            };

            var response = await _TourService.CreateTour(newTour);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Tour>>> Put([FromBody] Tour Tour)
        {
            var response = await _TourService.UpdateTour(Tour);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _TourService.DeleteTour(new Tour() { Id = id });
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
