using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models;
using TripPlanner.Models.DTO.BudgetDTOs;
using TripPlanner.Services.BudgetService;
namespace TripPlanner.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _BudgetService;

        public BudgetController(IBudgetService BudgetService)
        {
            _BudgetService = BudgetService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<Budget>>>> Get()
        {
            var response = await _BudgetService.GetBudgetsAsync();
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Budget>>> Get(int id)
        {
            var response = await _BudgetService.GetBudgetAsync(u => u.Id == id);
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
        public async Task<ActionResult<RepositoryResponse<Budget>>> Post([FromBody] CreateBudgetDTO Budget)
        {
            Budget newBudget = Budget;

            var response = await _BudgetService.CreateBudget(newBudget);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Budget>>> Put([FromBody] Budget Budget)
        {
            var response = await _BudgetService.UpdateBudget(Budget);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _BudgetService.DeleteBudget(new Budget() { Id = id });
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
