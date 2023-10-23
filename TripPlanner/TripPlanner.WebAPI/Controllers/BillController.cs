using Microsoft.AspNetCore.Mvc;
using TripPlanner.Services.UserService;
using TripPlanner.Services.TourService;
using TripPlanner.Models.DTO.BillDTOs;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.BillModels;
using TripPlanner.Services.BillService;

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


        [HttpGet("{tourId}")]
        public async Task<ActionResult<RepositoryResponse<List<ShareDTO>>>> GetAllTourShares(int tourId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == tourId, "Shares");
            if(response.Data == null)
            {
                return new RepositoryResponse<List<ShareDTO>> { Data = null, Success = false, Message = $"Nie istnieje wyjazd o id = {tourId}" };
            }

            List<ShareDTO> Shares = response.Data.Shares.Select(u => (ShareDTO)u).ToList();
            return Ok(new RepositoryResponse<List<ShareDTO>> { Data = Shares, Message = "", Success = true});
        }

        [HttpGet("GetBilans/{tourId}")]
        public async Task<ActionResult<RepositoryResponse<Balance>>> GetBilans(int tourId)
        {
            var response = await _TourService.GetTourAsync(u => u.Id == tourId, "Shares,Participants.User");
            if (response.Data == null)
            {
                return new RepositoryResponse<Balance> { Data = null, Success = false, Message = $"Nie istnieje wyjazd o id = {tourId}" };
            }

            var Shares = response.Data.Shares;

            Balance balance = new Balance(response.Data.Participants.ToList());

            foreach(var share in Shares)
            {
                if(share != null && share is Bill)
                {
                    Bill bill = (Bill)share;
                    balance.TotalBalance -= bill.Value;
                    balance.UserBalances.First(u => u.UserId == bill.PayerId).Due -= bill.Value;

                    //TODO problem wartosci null!!!
                    //dla wsyzstkich skladajacych sie
                    foreach(var billContributor in bill.Contributors)
                    {
                        balance.UserBalances.First(u => u.UserId == billContributor.UserId).Due += billContributor.Due;
                    }

                }
                else if (share != null && share is Transfer)
                {
                    Transfer tranfser = (Transfer)share;
                    balance.TotalBalance += tranfser.Value;
                    balance.UserBalances.First(u => u.UserId == tranfser.SenderId).Due += tranfser.Value;
                    balance.UserBalances.First(u => u.UserId == tranfser.RecipientId).Due -= tranfser.Value;
                }
            }
            return Ok(new RepositoryResponse<Balance> { Data = balance, Message = "", Success = true });
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
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost("CreateTransfer")]
        public async Task<ActionResult<RepositoryResponse<bool>>> CreateTransfer([FromBody] CreateTransferDTO transfer)
        {
            var resp = await _TourService.GetTourAsync(u => u.Id == transfer.TourId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wycieczka o id = {transfer.TourId}" };
            }
            var resp2 = await _UserService.GetUserAsync(u => u.Id == transfer.CreatorId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {transfer.CreatorId}" };
            }
            var resp3 = await _UserService.GetUserAsync(u => u.Id == transfer.SenderId);
            if (resp3.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {transfer.SenderId}" };
            }
            var resp4 = await _UserService.GetUserAsync(u => u.Id == transfer.RecipientId);
            if (resp4.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {transfer.RecipientId}" };
            }

            Transfer newTranfser = transfer;

            var response = await _BillService.CreateTransfer(newTranfser);
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
