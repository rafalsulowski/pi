using Microsoft.AspNetCore.Mvc;
using TripPlanner.Services.UserService;
using TripPlanner.Services.TourService;
using TripPlanner.Models.DTO.BillDTOs;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.BillModels;
using TripPlanner.Services.BillService;
using System.Collections.Generic;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.Models.TourModels;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = ProjectConfiguration.HideContorller)]
    public class BillController : ControllerBase
    {
        private readonly IBillService _BillService;
        private readonly IUserService _UserService;
        private readonly ITourService _TourService;

        public BillController(IBillService BillService, IUserService userService, ITourService tourService)
        {
            _BillService = BillService;
            _UserService = userService;
            _TourService = tourService;
        }


        [HttpGet("GetSharesPresentation/{userId}/{tourId}")]
        public async Task<ActionResult<RepositoryResponse<List<SharePresentationDTO>>>> GetSharesPresentation(int userId, int tourId)
        {
            var response = await _BillService.GetSharesPresentationAsync(userId, tourId);
            if (response.Success)
                return Ok(new RepositoryResponse<List<SharePresentationDTO>> { Data = response.Data, Message = "", Success = true });
            else
                return BadRequest(new RepositoryResponse<BillPresentationDTO> { Data = null, Message = response.Message, Success = false });
        }

        [HttpGet("GetBillPresentation/{userId}/{billId}")]
        public async Task<ActionResult<RepositoryResponse<BillPresentationDTO>>> GetBillPresentation(int userId, int billId, int tourId)
        {
            var response = await _BillService.GetBillPresentation(userId, billId, tourId);
            if (response.Success)
                return Ok(new RepositoryResponse<BillPresentationDTO> { Data = response.Data, Message = "", Success = true });
            else
                return BadRequest(new RepositoryResponse<BillPresentationDTO> { Data = null, Message = response.Message, Success = false });
        }

        [HttpGet("GetTransferPresentation/{userId}/{transferId}")]
        public async Task<ActionResult<RepositoryResponse<TransferPresentationDTO>>> GetTransferPresentation(int userId, int transferId, int tourId)
        {
            var response = await _BillService.GetTransferPresentation(userId, transferId, tourId);
            if (response.Success)
                return Ok(new RepositoryResponse<TransferPresentationDTO> { Data = response.Data, Message = "", Success = true });
            else
                return BadRequest(new RepositoryResponse<BillPresentationDTO> { Data = null, Message = response.Message, Success = false });
        }

        [HttpGet("GetBalance/{tourId}")]
        public async Task<ActionResult<RepositoryResponse<Balance>>> GetBalance(int tourId)
        {
            var response = await _BillService.GetBalance(tourId);
            if (response.Success)
                return Ok(new RepositoryResponse<Balance> { Data = response.Data, Message = "", Success = true });
            else
                return BadRequest(new RepositoryResponse<BillPresentationDTO> { Data = null, Message = response.Message, Success = false });
        }


        [HttpPost("CreateBill")]
        public async Task<ActionResult<RepositoryResponse<bool>>> CreateBill([FromBody] CreateBillDTO Bill)
        {
            var resp = await _TourService.GetTourAsync(u => u.Id == Bill.TourId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wycieczka o id = {Bill.TourId}" };
            }
            if (resp.Data.Shares.FirstOrDefault(u => ((Bill)u).Name == Bill.Name) != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Dana wycieczka posiada już rachunek o nazwie = {Bill.Name}" };
            }
            var resp2 = await _UserService.GetUserAsync(u => u.Id == Bill.CreatorId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {Bill.CreatorId}" };
            }
            var resp3 = await _UserService.GetUserAsync(u => u.Id == Bill.PayerId);
            if (resp3.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {Bill.PayerId}" };
            }

            Bill newBill = Bill;

            var response = await _BillService.CreateBill(newBill);
            if (response.Success)
                return Ok(new RepositoryResponse<bool> { Data = true, Success = true, Message = "" });
            else
                return BadRequest(new RepositoryResponse<bool> { Data = true, Success = false, Message = response.Message });
        }

        [HttpPost("CreateTransfer")]
        public async Task<ActionResult<RepositoryResponse<bool>>> CreateTransfer([FromBody] CreateTransferDTO transfer)
        {
            var resp = await _TourService.GetTourAsync(u => u.Id == transfer.TourId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Data = false, Success = false, Message = $"Nie istnieje wycieczka o id = {transfer.TourId}" };
            }
            var resp2 = await _UserService.GetUserAsync(u => u.Id == transfer.CreatorId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Data = false, Success = false, Message = $"Nie istnieje użytkownik o id = {transfer.CreatorId}" };
            }
            var resp3 = await _UserService.GetUserAsync(u => u.Id == transfer.SenderId);
            if (resp3.Data == null)
            {
                return new RepositoryResponse<bool> { Data = false, Success = false, Message = $"Nie istnieje użytkownik o id = {transfer.SenderId}" };
            }
            var resp4 = await _UserService.GetUserAsync(u => u.Id == transfer.RecipientId);
            if (resp4.Data == null)
            {
                return new RepositoryResponse<bool> { Data = false, Success = false, Message = $"Nie istnieje użytkownik o id = {transfer.RecipientId}" };
            }

            Transfer newTranfser = transfer;
            var response = await _BillService.CreateTransfer(newTranfser);
            if (response.Success)
                return Ok(new RepositoryResponse<bool> { Data = true, Success = true, Message = "" });
            else
                return BadRequest(new RepositoryResponse<bool> { Data = true, Success = false, Message = response.Message });
        }

        // PUT api/<ValuesController>/5
        [HttpPut("updateBill/{billId}/{userId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> UpdateBill(int billid, int userId, [FromBody] CreateBillDTO bill)
        {
            var resp2 = await _BillService.GetBillAsync(u => u.Id == billid);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje rachunek o id = {billid}" };
            }

            var resp = await _UserService.GetUserAsync(u => u.Id == userId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {userId}" };
            }

            //walidacja uczesnika czy moze modyfikować



            Bill newBill = resp2.Data;
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
                return Ok(new RepositoryResponse<bool> { Data = true, Message = "", Success = true });
            else
                return BadRequest(new RepositoryResponse<bool> { Data = false, Message = response.Message, Success = false });
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
                return Ok(new RepositoryResponse<bool> { Data = true, Message = "", Success = true });
            else
                return BadRequest(new RepositoryResponse<bool> { Data = false, Message = response.Message, Success = false });
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
                return Ok(new RepositoryResponse<bool> { Data = true, Message = "", Success = true });
            else
                return BadRequest(new RepositoryResponse<bool> { Data = false, Message = response.Message, Success = false });
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
                return Ok(new RepositoryResponse<bool> { Data = true, Message = "", Success = true });
            else
                return BadRequest(new RepositoryResponse<bool> { Data = false, Message = response.Message, Success = false });
        }
    }
}
