using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models;
using TripPlanner.Models.DTO;
using TripPlanner.Services.CheckListService;
namespace TripPlanner.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = ProjectConfiguration.HideContorller)]
    public class CheckListController : ControllerBase
    {
        private readonly ICheckListService _CheckListService;

        public CheckListController(ICheckListService CheckListService)
        {
            _CheckListService = CheckListService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<CheckList>>>> Get()
        {
            var response = await _CheckListService.GetCheckListsAsync();
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<CheckList>>> Get(int id)
        {
            var response = await _CheckListService.GetCheckListAsync(u => u.Id == id);
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
        public async Task<ActionResult<RepositoryResponse<CheckList>>> Post([FromBody] CheckListDTO CheckList)
        {
            
            CheckList newCheckList = new CheckList
            {
                
            };

            var response = await _CheckListService.CreateCheckList(newCheckList);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<CheckList>>> Put([FromBody] CheckList CheckList)
        {
            var response = await _CheckListService.UpdateCheckList(CheckList);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _CheckListService.DeleteCheckList(new CheckList() { Id = id });
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
