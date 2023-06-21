using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models;
using TripPlanner.Models.DTO;
using TripPlanner.Services.GroupService;
namespace TripPlanner.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = ProjectConfiguration.HideContorller)]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _GroupService;

        public GroupController(IGroupService GroupService)
        {
            _GroupService = GroupService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<Group>>>> Get()
        {
            var response = await _GroupService.GetGroupsAsync();
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Group>>> Get(int id)
        {
            var response = await _GroupService.GetGroupAsync(u => u.Id == id);
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
        public async Task<ActionResult<RepositoryResponse<Group>>> Post([FromBody] GroupDTO Group)
        {
            
            Group newGroup = new Group
            {
                
            };

            var response = await _GroupService.CreateGroup(newGroup);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Group>>> Put([FromBody] Group Group)
        {
            var response = await _GroupService.UpdateGroup(Group);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _GroupService.DeleteGroup(new Group() { Id = id });
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
