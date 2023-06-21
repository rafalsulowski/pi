using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models;
using TripPlanner.Models.DTO;
using TripPlanner.Services.BillService;
using TripPlanner.Services.UserService;
using TripPlanner.Services.TourService;
using TripPlanner.Models.DTO.BillDTOs;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
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

        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<BillDTO>>>> Get()
        {
            var response = await _BillService.GetBillsAsync();
            List<BillDTO> res = response.Data.Select(u => (BillDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("GetWithParticipants/{id}")]
        public async Task<ActionResult<RepositoryResponse<List<BillDTO>>>> GetWithParticipants(int id)
        {
            var response = await _BillService.GetBillsAsync(u => u.Id == id, "Participants");
            List<BillDTO> res = response.Data.Select(u => (BillDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<BillDTO>>> GetById(int id)
        {
            var response = await _BillService.GetBillAsync(u => u.Id == id);
            BillDTO res = response.Data;
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<RepositoryResponse<bool>>> Create([FromBody] CreateBillDTO Bill)
        {
            var resp = await _BillService.GetBillAsync(u => u.Name == Bill.Name);
            if (resp.Data != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Istnieje rachunek o nazwie {Bill.Name}" };
            }
            var resp2 = await _UserService.GetUserAsync(u => u.Id == Bill.UserId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {Bill.UserId}" };
            }
            var resp3 = await _TourService.GetTourAsync(u => u.Id == Bill.TourId);
            if (resp3.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wycieczka o id = {Bill.TourId}" };
            }

            Bill newBill = Bill;

            var response = await _BillService.CreateBill(newBill);
            return Ok(response.Data);
        }

        [HttpGet("{billId}/participants")]
        public async Task<ActionResult<RepositoryResponse<List<ParticipantBillDTO>>>> GetParticipant(int billId)
        {
            var response = await _BillService.GetParticipantsBillAsync();
            List<ParticipantBillDTO> res = response.Data.Select(u => (ParticipantBillDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{billId}/participant/{userId}")]
        public async Task<ActionResult<RepositoryResponse<ParticipantBillDTO>>> GetParticipantById(int billId, int userId)
        {
            var response = await _BillService.GetParticipantBillAsync(u => u.BillId == billId && u.UserId == userId);
            ParticipantBillDTO res = response.Data;
            return Ok(res);
        }

        [HttpPost("addParticipant")]
        public async Task<ActionResult<RepositoryResponse<bool>>> AddParticipant([FromBody] ParticipantBillDTO Bill)
        {
            var resp = await _UserService.GetUserAsync(u => u.Id == Bill.UserId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {Bill.UserId}" };
            }
            var resp2 = await _BillService.GetBillAsync(u => u.Id == Bill.BillId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje rachunek o id = {Bill.BillId}" };
            }
            var resp3 = await _BillService.GetParticipantsBillAsync(u => u.BillId == Bill.BillId);
            if (resp3.Data != null)
            {
                var user = resp3.Data.Find(u => u.UserId == Bill.UserId);
                if(user != null)
                    return new RepositoryResponse<bool> { Success = false, Message = $"Rachunek zawiera już użytkownika o id = {user.UserId}" };
            }

            ParticipantBill elem = Bill;

            var response = await _BillService.AddParticipantToBill(elem);
            return Ok(response.Data);
        }

        [HttpPut("{billId}/editParticipant/{userId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Edit(int billId, int userId, [FromBody] ParticipantBillDTO Bill)
        {
            var resp = await _UserService.GetUserAsync(u => u.Id == userId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {userId}" };
            }
            var resp2 = await _BillService.GetBillAsync(u => u.Id == billId);
            if (resp2.Data == null)
            {
                return NotFound(new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje rachunek o id = {billId}" });
            }

            ParticipantBill newParticipantBill = Bill;
            newParticipantBill.BillId = billId;
            newParticipantBill.UserId = userId;

            var response = await _BillService.UpdateParticipantBill(newParticipantBill);
            return Ok(response.Data);
        }

        [HttpDelete("{billId}/deleteParticipant/{userId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> DeleteParticipant(int billId, int userId)
        {
            var resp = await _UserService.GetUserAsync(u => u.Id == userId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {userId}" };
            }
            var resp2 = await _BillService.GetBillAsync(u => u.Id == billId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje rachunek o id = {billId}" };
            }

            ParticipantBill elem = new ParticipantBill
            {
                UserId = userId,
                BillId = billId
            };

            var response = await _BillService.DeleteParticipantFromBill(elem);
            return Ok(response.Data);
        }

        [HttpPost("addPicture")]
        public async Task<ActionResult<RepositoryResponse<bool>>> AddPicture([FromForm] CreateBillPictureDTO BillPicture)
        {
            var resp = await _BillService.GetBillAsync(u => u.Id == BillPicture.BillId);
            if (resp.Data == null)
            {
                return NotFound(new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje rachunek o id = {BillPicture.BillId}" });
            }

            return Ok();
        }

        [HttpGet("{billId}/pictures")]
        public async Task<ActionResult<RepositoryResponse<List<BillPictureDTO>>>> GetPicture(int billId)
        {
            var response = await _BillService.GetBillPicturesAsync();
            List<BillPictureDTO> res = response.Data.Select(u => (BillPictureDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{billId}/picture/{pictureId}")]
        public async Task<ActionResult<RepositoryResponse<BillPictureDTO>>> GetPictureById(int billId, int pictureId)
        {
            var response = await _BillService.GetBillPictureAsync(u => u.BillId == billId && u.Id == pictureId);
            BillPictureDTO res = response.Data;
            return Ok(res);
        }

        [HttpDelete("{billId}/deletePicture/{pictureId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> DeletePicture(int billId, int pictureId)
        {
            var resp = await _BillService.GetBillPictureAsync(u => u.Id == pictureId);
            if (resp.Data == null)
            {
                return NotFound(new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje zdjęcie rachunku o id = {pictureId}" });
            }
            var resp2 = await _BillService.GetBillAsync(u => u.Id == billId);
            if (resp2.Data == null)
            {
                return NotFound(new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje rachunek o id = {billId}" });
            }

            BillPicture elem = new BillPicture
            {
                Id = pictureId,
                BillId = billId
            };

            var response = await _BillService.DeletePictureFromBill(elem);
            return Ok(response.Data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Edit(int billId, [FromBody] BillDTO Bill)
        {
            var resp2 = await _BillService.GetBillAsync(u => u.Id == billId);
            if (resp2.Data == null)
            {
                return NotFound(new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje rachunek o id = {billId}" });
            }

            Bill elem = Bill;
            elem.Id = billId;

            var response = await _BillService.UpdateBill(elem);
            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _BillService.DeleteBill(new Bill() { Id = id });
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
