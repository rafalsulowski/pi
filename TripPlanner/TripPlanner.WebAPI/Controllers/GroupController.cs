using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models;
using TripPlanner.Services.GroupService;
using TripPlanner.Services.UserService;
using TripPlanner.Services.TourService;
using TripPlanner.Models.DTO.GroupDTOs;
using TripPlanner.Services.ChatService;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = ProjectConfiguration.HideContorller)]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _GroupService;
        private readonly IUserService _UserService;
        private readonly IChatService _ChatService;
        private readonly ITourService _TourService;

        public GroupController(IGroupService GroupService, IUserService userService, ITourService tourService, IChatService chatService)
        {
            _GroupService = GroupService;
            _UserService = userService;
            _TourService = tourService;
            _ChatService = chatService;
        }

        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<GroupDTO>>>> Get()
        {
            var response = await _GroupService.GetGroupsAsync();
            List<GroupDTO> res = response.Data.Select(u => (GroupDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("GetWithParticipants/{id}")]
        public async Task<ActionResult<RepositoryResponse<GroupDTO>>> GetWithParticipants(int id)
        {
            var response = await _GroupService.GetGroupAsync(u => u.Id == id, "Participants");
            GroupDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<GroupDTO>>> GetById(int id)
        {
            var response = await _GroupService.GetGroupAsync(u => u.Id == id);
            GroupDTO res = response.Data;
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<RepositoryResponse<bool>>> Create([FromBody] CreateGroupDTO Group)
        {
            var resp3 = await _TourService.GetTourAsync(u => u.Id == Group.TourId, "Groups");
            if (resp3.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wycieczka o id = {Group.TourId}" };
            }

            if(resp3.Data.Groups.FirstOrDefault(u => u.Name == Group.Name) != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"W tej wycieczce istnieje grupa o takiej nazwie = {Group.Name}" };
            }

            Group newGroup = Group;

            var response = await _GroupService.CreateGroup(newGroup);
            return Ok(response.Data);
        }

        [HttpGet("{GroupId}/participants")]
        public async Task<ActionResult<RepositoryResponse<List<ParticipantGroupDTO>>>> GetParticipant(int GroupId)
        {
            var response = await _GroupService.GetParticipantsGroupAsync(u => u.GroupId == GroupId);
            List<ParticipantGroupDTO> res = response.Data.Select(u => (ParticipantGroupDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{GroupId}/participant/{userId}")]
        public async Task<ActionResult<RepositoryResponse<ParticipantGroupDTO>>> GetParticipantById(int GroupId, int userId)
        {
            var response = await _GroupService.GetParticipantGroupAsync(u => u.GroupId == GroupId && u.UserId == userId);
            ParticipantGroupDTO res = response.Data;
            return Ok(res);
        }

        [HttpPost("addParticipant")]
        public async Task<ActionResult<RepositoryResponse<bool>>> AddParticipant([FromBody] ParticipantGroupDTO Group)
        {
            var resp = await _UserService.GetUserAsync(u => u.Id == Group.UserId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {Group.UserId}" };
            }
            var resp2 = await _GroupService.GetGroupAsync(u => u.Id == Group.GroupId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje grupa o id = {Group.GroupId}" };
            }
            var resp3 = await _GroupService.GetParticipantsGroupAsync(u => u.GroupId == Group.GroupId);
            if (resp3.Data != null)
            {
                var user = resp3.Data.Find(u => u.UserId == Group.UserId);
                if (user != null)
                    return new RepositoryResponse<bool> { Success = false, Message = $"Grupa zawiera już użytkownika o id = {user.UserId}" };
            }

            ParticipantGroup elem = Group;

            var response = await _GroupService.AddParticipantToGroup(elem);
            return Ok(response.Data);
        }

        [HttpPut("{GroupId}/editParticipant/{userId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Edit(int GroupId, int userId, [FromBody] ParticipantGroupDTO Group)
        {
            var resp = await _UserService.GetUserAsync(u => u.Id == userId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {userId}" };
            }
            var resp2 = await _GroupService.GetGroupAsync(u => u.Id == GroupId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje grupa o id = {GroupId}" };
            }

            ParticipantGroup newParticipantGroup = Group;
            newParticipantGroup.GroupId = GroupId;
            newParticipantGroup.UserId = userId;

            var response = await _GroupService.UpdateParticipantGroup(newParticipantGroup);
            return Ok(response.Data);
        }

        [HttpDelete("{GroupId}/deleteParticipant/{userId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> DeleteParticipant(int GroupId, int userId)
        {
            var resp = await _UserService.GetUserAsync(u => u.Id == userId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {userId}" };
            }
            var resp2 = await _GroupService.GetGroupAsync(u => u.Id == GroupId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje grupa o id = {GroupId}" };
            }

            ParticipantGroup elem = new ParticipantGroup
            {
                UserId = userId,
                GroupId = GroupId
            };

            var response = await _GroupService.DeleteParticipantFromGroup(elem);
            return Ok(response.Data);
        }

        [HttpPut("{GroupId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Edit(int GroupId, [FromBody] EditGroupDTO Group)
        {
            var resp2 = await _GroupService.GetGroupAsync(u => u.Id == GroupId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje grupa o id = {GroupId}" };
            }

            var resp = await _GroupService.GetGroupAsync(u => u.Name == Group.Name && u.Id != GroupId);
            if (resp.Data != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Istnieje już taka grupa o nazwie = {Group.Name}" };
            }

            Group elem = resp2.Data;
            elem.Id = GroupId;
            elem.Name = Group.Name;
            elem.Volume = Group.Volume;

            var response = await _GroupService.UpdateGroup(elem);
            return Ok(response.Data);
        }

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
                return NotFound(response.Data);
            }
        }
    }
}
