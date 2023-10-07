using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models;
using TripPlanner.Services.ChatService;
using TripPlanner.Services.UserService;
using TripPlanner.Services.TourService;
using TripPlanner.Models.DTO.ChatDTOs;
using TripPlanner.Services.GroupService;
using TripPlanner.Models.Models.Message;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = ProjectConfiguration.HideContorller)]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _ChatService;
        private readonly IUserService _UserService;
        private readonly ITourService _TourService;
        private readonly IGroupService _GroupService;

        public ChatController(IChatService ChatService, IUserService userService, ITourService tourService, IGroupService groupService)
        {
            _ChatService = ChatService;
            _UserService = userService;
            _TourService = tourService;
            _GroupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<ChatDTO>>>> Get()
        {
            var response = await _ChatService.GetChatsAsync();
            List<ChatDTO> res = response.Data.Select(u => (ChatDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("GetWithMessages/{id}")]
        public async Task<ActionResult<RepositoryResponse<ChatDTO>>> GetWithMessages(int id)
        {
            var response = await _ChatService.GetChatAsync(u => u.Id == id, "Messages");
            ChatDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("GetWithQuestionnaires/{id}")]
        public async Task<ActionResult<RepositoryResponse<ChatDTO>>> GetWithQuestionnaires(int id)
        {
            var response = await _ChatService.GetChatAsync(u => u.Id == id, "Questionnaires");
            ChatDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("GetWithMessagesAndQuestionnaires/{id}")]
        public async Task<ActionResult<RepositoryResponse<ChatDTO>>> GetWithMessagesAndQuestionnaires(int id)
        {
            var response = await _ChatService.GetChatAsync(u => u.Id == id, "Messages,Questionnaires");
            ChatDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<ChatDTO>>> GetById(int id)
        {
            var response = await _ChatService.GetChatAsync(u => u.Id == id);
            ChatDTO res = response.Data;
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<RepositoryResponse<bool>>> Create([FromBody] CreateChatDTO Chat)
        {
            var resp3 = await _GroupService.GetGroupAsync(u => u.Id == Chat.GroupId, "Chat");
            if (resp3.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje grupa o id = {Chat.GroupId}" };
            }
            if (resp3.Data.Chat != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Grupa posiada już czat o id = {resp3.Data.Chat.Id}" };
            }

            Chat newChat = Chat;

            var response = await _ChatService.CreateChat(newChat);
            return Ok(response.Data);
        }

        [HttpPost("addMessage")]
        public async Task<ActionResult<RepositoryResponse<bool>>> AddMessage([FromBody] CreateMessageDTO ChatMessage)
        {
            var resp = await _ChatService.GetChatAsync(u => u.Id == ChatMessage.ChatId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje czat o id = {ChatMessage.ChatId}" };
            }
            var resp2 = await _UserService.GetUserAsync(u => u.Id == ChatMessage.UserId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {ChatMessage.UserId}" };
            }

            Message mes = ChatMessage;
            mes.Date = DateTime.Now;
            var response = await _ChatService.AddMessageToChat(mes);
            return Ok();
        }

        [HttpGet("{ChatId}/Messages")]
        public async Task<ActionResult<RepositoryResponse<List<MessageDTO>>>> GetMessage(int ChatId)
        {
            var response = await _ChatService.GetMessagesAsync(u => u.ChatId == ChatId);
            List<MessageDTO> res = response.Data.Select(u => (MessageDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{ChatId}/Message/{MessageId}")]
        public async Task<ActionResult<RepositoryResponse<MessageDTO>>> GetMessageById(int ChatId, int MessageId)
        {
            var response = await _ChatService.GetMessageAsync(u => u.ChatId == ChatId && u.Id == MessageId);
            MessageDTO res = response.Data;
            return Ok(res);
        }

        [HttpDelete("{ChatId}/deleteMessage/{MessageId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> DeleteMessage(int ChatId, int MessageId)
        {
            var resp = await _ChatService.GetMessageAsync(u => u.Id == MessageId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wiadomość o id = {MessageId}" };
            }
            var resp2 = await _ChatService.GetChatAsync(u => u.Id == ChatId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje czat o id = {ChatId}" };
            }

            Message elem = resp.Data;
            elem.ChatId = ChatId;
            elem.Id = MessageId;

            var response = await _ChatService.DeleteMessageFromChat(elem);
            return Ok(response.Data);
        }
    }
}
