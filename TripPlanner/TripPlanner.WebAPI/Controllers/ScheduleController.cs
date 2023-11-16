using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models.DTO.ScheduleDTOs;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.ScheduleModels;
using TripPlanner.Services.ScheduleService;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = ProjectConfiguration.HideContorller)]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _ScheduleService;

        public ScheduleController(IScheduleService ScheduleService)
        {
            _ScheduleService = ScheduleService;
        }

        [HttpGet("{tourId}/GetWholeSchedule")]
        public async Task<ActionResult<RepositoryResponse<List<ScheduleDayDTO>>>> GetWholeSchedule(int tourId)
        {
            var response = await _ScheduleService.GetWholeSchedule(tourId);
            if(response.Data == null)
            {
                return new RepositoryResponse<List<ScheduleDayDTO>> { Data = null, Success = false, Message = $"Nie istnieje wycieczka o id = {tourId}" };
            }

            List<ScheduleDayDTO> ScheduleList = response.Data.Select(u => (ScheduleDayDTO)u).ToList();
            return Ok(new RepositoryResponse<List<ScheduleDayDTO>> { Data = ScheduleList, Message = "", Success = true});
        }

        [HttpPost("ScheduleEvent")]
        public async Task<ActionResult<RepositoryResponse<bool>>> CreateScheduleEvent([FromBody] CreateScheduleEventDTO Event)
        {
            ScheduleEvent newEvent = Event;

            var response = await _ScheduleService.CreateScheduleEvent(newEvent);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        [HttpPut("{ScheduleDayId}/editEvent/{ScheduleEventId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> EditScheduleEvent(int ScheduleDayId, int ScheduleEventId, [FromBody] EditScheduleEventDTO editEvent)
        {
            ScheduleEvent newEvent = editEvent;
            newEvent.ScheduleDayId = ScheduleDayId;
            newEvent.Id= ScheduleEventId;

            var response = await _ScheduleService.UpdateScheduleEvent(newEvent);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpDelete("{ScheduleDayId}/deleteEvent/{ScheduleEventId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> DeleteScheduleEvent(int ScheduleDayId, int ScheduleEventId)
        {
            ScheduleEvent newEvent = new ScheduleEvent
            {
                ScheduleDayId = ScheduleDayId,
                Id = ScheduleEventId
            };
          
            var response = await _ScheduleService.DeleteScheduleEvent(newEvent);
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
