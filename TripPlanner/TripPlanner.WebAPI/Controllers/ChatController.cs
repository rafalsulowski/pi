using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models;
using TripPlanner.Models.DTO;
using TripPlanner.Services.ChatService;
namespace TripPlanner.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = ProjectConfiguration.HideContorller)]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _ChatService;

        public ChatController(IChatService ChatService)
        {
            _ChatService = ChatService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<Chat>>>> Get()
        {
            var response = await _ChatService.GetChatsAsync();
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Chat>>> Get(int id)
        {
            var response = await _ChatService.GetChatAsync(u => u.Id == id);
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
        public async Task<ActionResult<RepositoryResponse<Chat>>> Post([FromBody] ChatDTO Chat)
        {
            
            Chat newChat = new Chat
            {
                
            };

            var response = await _ChatService.CreateChat(newChat);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Chat>>> Put([FromBody] Chat Chat)
        {
            var response = await _ChatService.UpdateChat(Chat);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _ChatService.DeleteChat(new Chat() { Id = id });
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
