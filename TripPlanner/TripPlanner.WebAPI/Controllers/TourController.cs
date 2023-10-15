using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.CultureDTOs;
using TripPlanner.Services.CultureService;
using TripPlanner.Services.TourService;
using TripPlanner.Services.UserService;
using TripPlanner.Models.DTO.CheckListDTOs;
using TripPlanner.Models.DTO.GroupDTOs;
using TripPlanner.Services.GroupService;
using TripPlanner.Models.DTO.ChatDTOs;
using TripPlanner.Models.Models.Tour;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _TourService;
        private readonly IUserService _UserService;
        private readonly ICultureService _CultureService;
        private readonly IGroupService _GroupService;

        public TourController(ITourService TourService, IUserService userService, ICultureService cultureService, IGroupService groupService)
        {
            _TourService = TourService;
            _UserService = userService;
            _CultureService = cultureService;
            _GroupService = groupService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<TourDTO>>>> Get()
        {
            var response = await _TourService.GetToursAsync();
            return Ok(response.Data);
        }

        [HttpGet("GetNearestTour/{userId}")]
        public async Task<ActionResult<RepositoryResponse<List<TourDTO>>>> GetNearestTour(int userId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == userId);
            TourDTO res = response.Data;
            return Ok(res);
        }

        //[HttpGet("GetUserTours/{userId}")]
        //public async Task<ActionResult<RepositoryResponse<List<TourDTO>>>> GetUserTours(int userId)
        //{
        //    var response = await _TourService.GetUserToursAsync(userId);
        //    List<TourDTO> res = response.Data.Select(u => (TourDTO)u).ToList();
        //    return Ok(res);
        //}

        [HttpGet("{tourId}/GetWithOrganizers")]
        public async Task<ActionResult<RepositoryResponse<TourDTO>>> GetWithOrganizers(int tourId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == tourId, "Organizers");
            TourDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{tourId}/GetWithParticipants")]
        public async Task<ActionResult<RepositoryResponse<TourDTO>>> GetWithParticipant(int tourId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == tourId, "Participants");
            TourDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{tourId}/GetWithCheckLists")]
        public async Task<ActionResult<RepositoryResponse<TourDTO>>> GetWithCheckLists(int tourId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == tourId, "CheckLists");
            TourDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{tourId}/GetWithQuestionnaires")]
        public async Task<ActionResult<RepositoryResponse<TourDTO>>> GetWithQuestionnaires(int tourId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == tourId, "Questionnaires");
            TourDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{tourId}/GetWithGroups")]
        public async Task<ActionResult<RepositoryResponse<TourDTO>>> GetWithGroups(int tourId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == tourId, "Groups");
            TourDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{tourId}/GetWithRoutes")]
        public async Task<ActionResult<RepositoryResponse<TourDTO>>> GetWithRoutes(int tourId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == tourId, "Routes");
            TourDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{tourId}/GetWithBills/{id}")]
        public async Task<ActionResult<RepositoryResponse<TourDTO>>> GetWithBills(int tourId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == tourId, "Bills");
            TourDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{tourId}/GetWithCultureAssistance")]
        public async Task<ActionResult<RepositoryResponse<TourDTO>>> GetWithCultureAssistance(int tourId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == tourId, "CultureAssistance");
            TourDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{tourId}/GetWithBudget")]
        public async Task<ActionResult<RepositoryResponse<TourDTO>>> GetWithBudget(int tourId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == tourId, "Budget");
            TourDTO res = response.Data;
            return Ok(res);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{tourId}")]
        public async Task<ActionResult<RepositoryResponse<TourDTO>>> Get(int tourId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == tourId);
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
        public async Task<ActionResult<RepositoryResponse<int>>> Create([FromBody] CreateTourDTO Tour)
        {
            var resp3 = await _TourService.GetTourAsync(u => u.Title == Tour.Title);
            if (resp3.Data != null)
            {
                return new RepositoryResponse<int> { Data = -1, Success = false, Message = $"Istnieje wycieczka o tytule = {Tour.Title}" };
            }
            var resp = await _UserService.GetUserAsync(u => u.Id == Tour.UserId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<int> { Data = -1, Success = false, Message = $"Nie istnieje użytkownik o id = {Tour.UserId}" };
            }

            //1. Create new Tour
            Tour newTour = Tour;
            var response = await _TourService.CreateTour(newTour);

            if(response.Success == false)
            {
                return new RepositoryResponse<int> { Data = -1, Success = false, Message = $"Nie udało się utowrzyć wycieczki" };
            }

            //2. Add first ogranizer
            OrganizerTourDTO organizer = new OrganizerTourDTO();
            organizer.UserId = Tour.UserId;
            organizer.TourId = newTour.Id;
            var response2 = await _TourService.AddOrganizerToTour(organizer);

            if (response2.Success == false)
            {
                return new RepositoryResponse<int> { Data = -1, Success = false, Message = $"Nie udało się utowrzyć wycieczki ze względu na błąd podczas dodawania ogranizatora" };
            }

            //3. Add first participant (organizer is also participant)
            ParticipantTourDTO participant = new ParticipantTourDTO();
            participant.UserId = Tour.UserId;
            participant.TourId = newTour.Id;
            var response3 = await _TourService.AddParticipantToTour(participant);

            if (response3.Success == false)
            {
                return new RepositoryResponse<int> { Data = -1, Success = false, Message = $"Nie udało się utowrzyć wycieczki ze względu na błąd podczas dodawania pierwszego uczestnika (organizatora)" };
            }

            //4. Add main chat
            Chat chat = new Chat();
            chat.TourId = newTour.Id;
            chat.GroupId = -1; //TODO sprawdzic czy nie wywala blad podczas dodawania//
            var response4 = await _TourService.AddChatToTour(chat);

            if(response4.Success == false)
            {
                return new RepositoryResponse<int> { Data = -1, Success = false, Message = $"Nie udało się utowrzyć wycieczki ze względu na błąd podczas dodawania czatu głównego" };
            }

            return Ok(newTour.Id);
        }

        [HttpPost("addOrganizer")]
        public async Task<ActionResult<RepositoryResponse<bool>>> AddOrganizer([FromBody] OrganizerTourDTO Tour)
        {
            var resp = await _UserService.GetUserAsync(u => u.Id == Tour.UserId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {Tour.UserId}" };
            }
            var resp2 = await _TourService.GetTourAsync(u => u.Id == Tour.TourId, "Organizers");
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wycieczka o id = {Tour.TourId}" };
            }
            var resp3 = resp2.Data.Organizers.FirstOrDefault(u => u.UserId == Tour.UserId);
            if (resp3 != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Wycieczka zawiera już organizatora o UserId = {Tour.UserId}" };
            }

            OrganizerTour elem = Tour;

            var response = await _TourService.AddOrganizerToTour(elem);
            return Ok(response.Data);
        }

        [HttpGet("{TourId}/Organizers")]
        public async Task<ActionResult<RepositoryResponse<List<OrganizerTourDTO>>>> GetOrganizer(int TourId)
        {
            var response = await _TourService.GetOrganizersAsync(u => u.TourId == TourId);
            List<OrganizerTourDTO> res = response.Data.Select(u => (OrganizerTourDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{TourId}/Organizer/{userId}")]
        public async Task<ActionResult<RepositoryResponse<OrganizerTourDTO>>> GetOrganizerById(int TourId, int userId)
        {
            var response = await _TourService.GetOrganizerAsync(u => u.TourId == TourId && u.UserId == userId);
            OrganizerTourDTO res = response.Data;
            return Ok(res);
        }

        [HttpDelete("{TourId}/deleteOrganizer/{userId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> DeleteOrganizer(int TourId, int userId)
        {
            var resp = await _UserService.GetUserAsync(u => u.Id == userId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {userId}" };
            }
            var resp2 = await _TourService.GetTourAsync(u => u.Id == TourId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje Wycieczka o id = {TourId}" };
            }

            OrganizerTour elem = new OrganizerTour
            {
                UserId = userId,
                TourId = TourId
            };

            var response = await _TourService.DeleteOrganizerFromTour(elem);
            return Ok(response.Data);
        }

        [HttpPost("addParticipant")]
        public async Task<ActionResult<RepositoryResponse<bool>>> AddParticipant([FromBody] ParticipantTourDTO Tour)
        {
            var resp = await _UserService.GetUserAsync(u => u.Id == Tour.UserId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {Tour.UserId}" };
            }
            var resp2 = await _TourService.GetTourAsync(u => u.Id == Tour.TourId, "Participants");
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wycieczka o id = {Tour.TourId}" };
            }
            var resp3 = resp2.Data.Participants.FirstOrDefault(u => u.UserId == Tour.UserId);
            if (resp3 != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Wycieczka zawiera już uczestnika o UserId = {Tour.UserId}" };
            }

            ParticipantTour elem = Tour;

            var response = await _TourService.AddParticipantToTour(elem);
            return Ok(response.Data);
        }

        [HttpGet("{TourId}/Participants")]
        public async Task<ActionResult<RepositoryResponse<List<ParticipantTourDTO>>>> GetParticipant(int TourId)
        {
            var response = await _TourService.GetParticipantsAsync(u => u.TourId == TourId);
            List<ParticipantTourDTO> res = response.Data.Select(u => (ParticipantTourDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{TourId}/Participant/{userId}")]
        public async Task<ActionResult<RepositoryResponse<ParticipantTourDTO>>> GetParticipantById(int TourId, int userId)
        {
            var response = await _TourService.GetParticipantAsync(u => u.TourId == TourId && u.UserId == userId);
            ParticipantTourDTO res = response.Data;
            return Ok(res);
        }

        [HttpDelete("{TourId}/deleteParticipant/{userId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> DeleteParticipant(int TourId, int userId)
        {
            var resp = await _UserService.GetUserAsync(u => u.Id == userId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {userId}" };
            }
            var resp2 = await _TourService.GetTourAsync(u => u.Id == TourId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje Wycieczka o id = {TourId}" };
            }

            ParticipantTour elem = new ParticipantTour
            {
                UserId = userId,
                TourId = TourId
            };

            var response = await _TourService.DeleteParticipantFromTour(elem);
            return Ok(response.Data);
        }

        [HttpPost("addCultureAssistance")]
        public async Task<ActionResult<RepositoryResponse<bool>>> AddCultureAssistance([FromBody] CultureAssistanceDTO Tour)
        {
            var resp = await _CultureService.GetCultureAsync(u => u.Id == Tour.CultureId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje nota kulturowa o id = {Tour.CultureId}" };
            }
            var resp2 = await _TourService.GetTourAsync(u => u.Id == Tour.TourId, "CultureAssistances");
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wycieczka o id = {Tour.TourId}" };
            }
            var resp3 = resp2.Data.CultureAssistances.FirstOrDefault(u => u.CultureId == Tour.CultureId);
            if (resp3 != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Wycieczka zawiera już note kulturowa o id = {Tour.CultureId}" };
            }

            CultureAssistance elem = Tour;

            var response = await _TourService.AddCultureAssistanceToTour(elem);
            return Ok(response.Data);
        }

        [HttpGet("{TourId}/CultureAssistances")]
        public async Task<ActionResult<RepositoryResponse<List<CultureAssistanceDTO>>>> GetCulturesAssistance(int TourId)
        {
            var response = await _TourService.GetCulturesAssistanceAsync(u => u.TourId == TourId);
            List<CultureAssistanceDTO> res = response.Data.Select(u => (CultureAssistanceDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{TourId}/CultureAssistance/{CultureId}")]
        public async Task<ActionResult<RepositoryResponse<CultureAssistanceDTO>>> GetCultureAssistanceById(int TourId, int CultureId)
        {
            var response = await _TourService.GetCultureAssistanceAsync(u => u.TourId == TourId && u.CultureId == CultureId);
            CultureAssistanceDTO res = response.Data;
            return Ok(res);
        }

        [HttpDelete("{TourId}/deleteCultureAssistance/{cultureId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> DeleteCultureAssistance(int TourId, int cultureId)
        {
            var resp = await _CultureService.GetCultureAsync(u => u.Id == cultureId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje nota kulturowa o id = {cultureId}" };
            }
            var resp2 = await _TourService.GetTourAsync(u => u.Id == TourId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje Wycieczka o id = {TourId}" };
            }

            CultureAssistance elem = new CultureAssistance
            {
                CultureId = cultureId,
                TourId = TourId
            };

            var response = await _TourService.DeleteCultureAssistanceFromTour(elem);
            return Ok(response.Data);
        }

        [HttpPost("addGroup")]
        public async Task<ActionResult<RepositoryResponse<bool>>> AddGroup([FromBody] GroupDTO group)
        {
            var resp = await _GroupService.GetGroupAsync(u => u.Id == group.Id);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje grupa o id = {group.Id}" };
            }
            var resp2 = await _TourService.GetTourAsync(u => u.Id == group.TourId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wycieczka o id = {group.TourId}" };
            }
            
            Group elem = group;

            var response = await _TourService.AddGroupToTour(elem);
            return Ok(response.Data);
        }

        [HttpGet("{TourId}/Groups")]
        public async Task<ActionResult<RepositoryResponse<List<GroupDTO>>>> GetGroups(int TourId)
        {
            var response = await _TourService.GetGroupsAsync(u => u.TourId == TourId);
            List<GroupDTO> res = response.Data.Select(u => (GroupDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{TourId}/Group/{groupId}")]
        public async Task<ActionResult<RepositoryResponse<GroupDTO>>> GetGroupById(int TourId, int groupId)
        {
            var response = await _TourService.GetGroupAsync(u => u.TourId == TourId && u.Id == groupId);
            GroupDTO res = response.Data;
            return Ok(res);
        }

        [HttpDelete("{TourId}/deleteGroup/{groupId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> DeleteGroup(int TourId, int groupId)
        {
            var resp = await _GroupService.GetGroupAsync(u => u.Id == groupId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje grupa o id = {groupId}" };
            }
            var resp2 = await _TourService.GetTourAsync(u => u.Id == TourId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wycieczka o id = {TourId}" };
            }

            Group elem = new Group
            {
                Id = groupId,
                TourId = TourId
            };

            var response = await _TourService.DeleteGroupFromTour(elem);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Put(int id, [FromBody] EditTourDTO Tour)
        {
            var resp2 = await _TourService.GetTourAsync(u => u.Id == id);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje Wycieczka o id = {id}" };
            }

            Tour tour = resp2.Data;
            tour.MaxParticipant = Tour.MaxParticipant;
            tour.StartDate = Tour.StartDate;
            tour.EndDate = Tour.EndDate;
            tour.CreateDate = Tour.CreateDate;
            tour.TargetCountry = Tour.TargetCountry;
            tour.Title = Tour.Title;
            tour.Description = Tour.Description;
            tour.Id = id;

            var response = await _TourService.UpdateTour(tour);
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
