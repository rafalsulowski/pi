using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models.Models;
using TripPlanner.Models.DTO;
using TripPlanner.Services.BillService;
using TripPlanner.Services.UserService;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _BillService;
        private readonly IUserService _UserService;

        public BillController(IBillService BillService, IUserService userService)
        {
            _BillService = BillService;
            _UserService = userService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<Bill>>>> Get()
        {
            var response = await _BillService.GetBillsAsync();
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Bill>>> Get(int id)
        {
            var response = await _BillService.GetBillAsync(u => u.Id == id);
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
        [HttpPost("Create")]
        public async Task<ActionResult<RepositoryResponse<Bill>>> Post([FromBody] BillDTO Bill)
        {
            var resp = await _BillService.GetBillAsync(u => u.Name == Bill.Name);
            if (resp.Data != null)
            {
                return new RepositoryResponse<Bill> { Success = false, Message = "Rachunek o takiej nazwie został już dodany" };
            }

            Bill newBill = new Bill
            {
                TourId = Bill.TourID,
                UserId = Bill.UserID,
                Name = Bill.Name,
                Ammount = Bill.Ammount
            };

            var response = await _BillService.CreateBill(newBill);
            return Ok(response.Data);
        }

        [HttpPost("AddParticipant")]
        public async Task<ActionResult<RepositoryResponse<Bill>>> AddParticipant([FromBody] ParticipantBillDTO Bill)
        {
            var resp = await _UserService.GetUserAsync(u => u.Id == Bill.UserId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<Bill> { Success = false, Message = $"Brak użytkownika o id = {Bill.UserId}" };
            }

            //string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //if (userId == null)
            //    return Forbid("User must be loged in to add place to trip!");

            var elem = new ParticipantBill
            {
                UserId = Bill.UserId,
                BillId = Bill.BillId,
                Payment = Bill.Payment,
                Debt = Bill.Debt
            };

            var response = await _BillService.AddParticipantToBill(elem);
            return Ok(response.Data);
        }





        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Bill>>> Put([FromBody] Bill Bill)
        {
            var response = await _BillService.UpdateBill(Bill);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
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
                return BadRequest(response.Data);
            }
        }
    }
}
