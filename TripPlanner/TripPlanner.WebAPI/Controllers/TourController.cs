using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.CultureDTOs;
using TripPlanner.Services.CultureService;
using TripPlanner.Services.TourService;
using TripPlanner.Services.UserService;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.TourModels;
using TripPlanner.Models.Models.CultureModels;
using TripPlanner.Services.ChatService;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _TourService;
        private readonly IUserService _UserService;
        private readonly ICultureService _CultureService;
        private readonly IChatService _ChatService;

        public TourController(ITourService TourService, IUserService userService, ICultureService cultureService, IChatService chatService)
        {
            _TourService = TourService;
            _UserService = userService;
            _CultureService = cultureService;
            _ChatService = chatService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<TourDTO>>>> Get()
        {
            var response = await _TourService.GetToursAsync();
            return Ok(response.Data);
        }

        [HttpGet("{tourId}/GetWithParticipants")]
        public async Task<ActionResult<RepositoryResponse<TourDTO>>> GetWithParticipant(int tourId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == tourId, "Participants");
            TourDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{tourId}/GetWithMessages")]
        public async Task<ActionResult<RepositoryResponse<TourDTO>>> GetWithMessages(int tourId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == tourId, "Messages");
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

            Tour newTour = Tour;
            var response = await _TourService.CreateTour(newTour, Tour.UserId);
            if (response.Success)
            {
                return Ok(newTour);
            }
            else
            {
                return NotFound(response);
            }
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
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost("addCultureAssistance")]
        public async Task<ActionResult<RepositoryResponse<bool>>> AddCultureAssistance([FromBody] CultureAssistanceDTO Tour)
        {
            var resp = await _CultureService.GetCultureAsync(u => u.Id == Tour.CultureId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje nota kulturowa o id = {Tour.CultureId}" };
            }
            var resp2 = await _TourService.GetTourAsync(u => u.Id == Tour.TourId, "Cultures");
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wycieczka o id = {Tour.TourId}" };
            }
            var resp3 = resp2.Data.Cultures.FirstOrDefault(u => u.CultureId == Tour.CultureId);
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
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}/{userId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Put(int id, int userId, [FromBody] EditTourDTO Tour)
        {
            var resp2 = await _TourService.GetTourAsync(u => u.Id == id, "Participants");
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje Wycieczka o id = {id}" };
            }

            var resp = await _UserService.GetUserAsync(u => u.Id == userId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {userId}" };
            }

            ParticipantTour? participant = resp2.Data.Participants.Where(p => p.UserId == resp.Data.Id).First();
            if (participant == null || participant?.IsOrganizer == false)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Odmowa dostępu!" };
            }

            Tour tour = resp2.Data;
            tour.Id = id;
            tour.MaxParticipant = Tour.MaxParticipant;
            tour.StartDate = Tour.StartDate;
            tour.EndDate = Tour.EndDate;
            tour.CreateDate = Tour.CreateDate;
            tour.TargetCountry = Tour.TargetCountry;
            tour.TargetRegion = Tour.TargetRegion;
            tour.WeatherCords = Tour.WeatherCords;
            tour.Title = Tour.Title;
            tour.Description = Tour.Description;

            var response = await _TourService.UpdateTour(tour);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{tourId}/{userId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int userId, int tourId)
        {
            var resp2 = await _TourService.GetTourAsync(u => u.Id == tourId, "Participants");
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje Wycieczka o id = {tourId}" };
            }

            var resp = await _UserService.GetUserAsync(u => u.Id == userId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {userId}" };
            }

            ParticipantTour? participant = resp2.Data.Participants.Where(p => p.UserId == resp.Data.Id).First();
            if (participant == null || participant?.IsOrganizer == false)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Odmowa dostępu!" };
            }

            var response = await _TourService.DeleteTour(new Tour() { Id = tourId });
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
