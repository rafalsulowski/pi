using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models;
using TripPlanner.Services.BudgetService;
using TripPlanner.Services.UserService;
using TripPlanner.Services.TourService;
using TripPlanner.Models.DTO.BudgetDTOs;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = ProjectConfiguration.HideContorller)]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _BudgetService;
        private readonly IUserService _UserService;
        private readonly ITourService _TourService;

        public BudgetController(IBudgetService BudgetService, IUserService userService, ITourService tourService)
        {
            _BudgetService = BudgetService;
            _UserService = userService;
            _TourService = tourService;
        }

        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<BudgetDTO>>>> Get()
        {
            var response = await _BudgetService.GetBudgetsAsync();
            List<BudgetDTO> res = response.Data.Select(u => (BudgetDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("GetWithContributes/{id}")]
        public async Task<ActionResult<RepositoryResponse<BudgetDTO>>> GetWithContributes(int id)
        {
            var response = await _BudgetService.GetBudgetAsync(u => u.Id == id, "Contributes");
            BudgetDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("GetWithExpenditures/{id}")]
        public async Task<ActionResult<RepositoryResponse<BudgetDTO>>> GetWithExpenditures(int id)
        {
            var response = await _BudgetService.GetBudgetAsync(u => u.Id == id, "Expenditures");
            BudgetDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("GetWithContributesAndExpenditures/{id}")]
        public async Task<ActionResult<RepositoryResponse<BudgetDTO>>> GetWithContributesAndExpenditures(int id)
        {
            var response = await _BudgetService.GetBudgetAsync(u => u.Id == id, "Contributes,Expenditures");
            BudgetDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<BudgetDTO>>> GetById(int id)
        {
            var response = await _BudgetService.GetBudgetAsync(u => u.Id == id);
            BudgetDTO res = response.Data;
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<RepositoryResponse<bool>>> Create([FromBody] CreateBudgetDTO Budget)
        {
            var resp = await _TourService.GetTourAsync(u => u.Id == Budget.TourId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wycieczka o id = {Budget.TourId}" };
            }

            if(resp.Data.Budget != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Dana wycieczka posiada już budżet, jego id = {resp.Data.Budget.Id}" };
            }

            Budget newBudget = Budget;

            var response = await _BudgetService.CreateBudget(newBudget);
            return Ok(response.Data);
        }

        [HttpGet("{BudgetId}/Contributes")]
        public async Task<ActionResult<RepositoryResponse<List<ContributeBudgetDTO>>>> GetContribute(int BudgetId)
        {
            var response = await _BudgetService.GetContributesBudgetAsync(u => u.BudgetId == BudgetId);
            List<ContributeBudgetDTO> res = response.Data.Select(u => (ContributeBudgetDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{BudgetId}/Contribute/{userId}")]
        public async Task<ActionResult<RepositoryResponse<ContributeBudgetDTO>>> GetContributeById(int BudgetId, int userId)
        {
            var response = await _BudgetService.GetContributeBudgetAsync(u => u.BudgetId == BudgetId && u.UserId == userId);
            ContributeBudgetDTO res = response.Data;
            return Ok(res);
        }

        [HttpPost("addContribute")]
        public async Task<ActionResult<RepositoryResponse<bool>>> AddContribute([FromBody] ContributeBudgetDTO Budget)
        {
            var resp = await _UserService.GetUserAsync(u => u.Id == Budget.UserId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {Budget.UserId}" };
            }
            var resp2 = await _BudgetService.GetBudgetAsync(u => u.Id == Budget.BudgetId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje budzet o id = {Budget.BudgetId}" };
            }
            var resp3 = await _BudgetService.GetContributesBudgetAsync(u => u.BudgetId == Budget.BudgetId);
            if (resp3.Data != null)
            {
                var user = resp3.Data.Find(u => u.UserId == Budget.UserId);
                if (user != null)
                    return new RepositoryResponse<bool> { Success = false, Message = $"Budzet zawiera już użytkownika o id = {user.UserId}" };
            }

            ContributeBudget elem = Budget;

            var response = await _BudgetService.AddContributeToBudget(elem);
            return Ok(response.Data);
        }

        [HttpPut("{BudgetId}/editContribute/{userId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Edit(int BudgetId, int userId, [FromBody] ContributeBudgetDTO Budget)
        {
            var resp = await _UserService.GetUserAsync(u => u.Id == userId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {userId}" };
            }
            var resp2 = await _BudgetService.GetBudgetAsync(u => u.Id == BudgetId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje budzet o id = {BudgetId}" };
            }

            ContributeBudget newContributeBudget = Budget;
            newContributeBudget.BudgetId = BudgetId;
            newContributeBudget.UserId = userId;

            var response = await _BudgetService.UpdateContributeBudget(newContributeBudget);
            return Ok(response.Data);
        }

        [HttpDelete("{BudgetId}/deleteContribute/{userId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> DeleteContribute(int BudgetId, int userId)
        {
            var resp = await _UserService.GetUserAsync(u => u.Id == userId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {userId}" };
            }
            var resp2 = await _BudgetService.GetBudgetAsync(u => u.Id == BudgetId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje budzet o id = {BudgetId}" };
            }

            ContributeBudget elem = new ContributeBudget
            {
                UserId = userId,
                BudgetId = BudgetId
            };

            var response = await _BudgetService.DeleteContributeFromBudget(elem);
            return Ok(response.Data);
        }

        [HttpPost("addExpenditure")]
        public async Task<ActionResult<RepositoryResponse<bool>>> AddExpenditure([FromBody] CreateBudgetExpenditureDTO BudgetExpenditure)
        {
            var resp = await _BudgetService.GetBudgetAsync(u => u.Id == BudgetExpenditure.BudgetId, "Expenditures");
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje budzet o id = {BudgetExpenditure.BudgetId}" };
            }

            var expe = resp.Data.Expenditures.FirstOrDefault(u => u.Name == BudgetExpenditure.Name);
            if(expe != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Budzet zawiera wydatek o takiej nazwie = {BudgetExpenditure.Name}" };
            }

            BudgetExpenditure res = BudgetExpenditure;

            var response = await _BudgetService.AddExpenditureToBudget(res);
            return Ok(response.Data);
        }

        [HttpGet("{BudgetId}/Expenditures")]
        public async Task<ActionResult<RepositoryResponse<List<BudgetExpenditureDTO>>>> GetExpenditure(int BudgetId)
        {
            var response = await _BudgetService.GetBudgetExpendituresAsync(u => u.BudgetId == BudgetId);
            List<BudgetExpenditureDTO> res = response.Data.Select(u => (BudgetExpenditureDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{BudgetId}/Expenditure/{ExpenditureId}")]
        public async Task<ActionResult<RepositoryResponse<BudgetExpenditureDTO>>> GetExpenditureById(int BudgetId, int ExpenditureId)
        {
            var response = await _BudgetService.GetBudgetExpenditureAsync(u => u.BudgetId == BudgetId && u.Id == ExpenditureId);
            BudgetExpenditureDTO res = response.Data;
            return Ok(res);
        }

        [HttpPut("{budgetId}/editExpenditure/{expenditureId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Edit(int budgetId, int expenditureId, [FromBody] BudgetExpenditureDTO Budget)
        {
            var resp = await _BudgetService.GetBudgetExpenditureAsync(u => u.Id == expenditureId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wydatek o id = {expenditureId}" };
            }
            var resp2 = await _BudgetService.GetBudgetAsync(u => u.Id == budgetId, "Expenditures");
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje budzet o id = {budgetId}" };
            }
            var expe = resp2.Data.Expenditures.FirstOrDefault(u => u.Name == Budget.Name);
            if (expe != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Budzet zawiera wydatek o takiej nazwie = {Budget.Name}" };
            }


            BudgetExpenditure newExpenditureBudget = Budget;
            newExpenditureBudget.BudgetId = budgetId;
            newExpenditureBudget.Id = expenditureId;

            var response = await _BudgetService.UpdateExpenditureBudget(newExpenditureBudget);
            return Ok(response.Data);
        }

        [HttpDelete("{BudgetId}/deleteExpenditure/{ExpenditureId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> DeleteExpenditure(int BudgetId, int ExpenditureId)
        {
            var resp = await _BudgetService.GetBudgetExpenditureAsync(u => u.Id == ExpenditureId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wydatek o id = {ExpenditureId}" };
            }
            var resp2 = await _BudgetService.GetBudgetAsync(u => u.Id == BudgetId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje budzet o id = {BudgetId}" };
            }

            BudgetExpenditure elem = new BudgetExpenditure
            {
                Id = ExpenditureId,
                BudgetId = BudgetId
            };

            var response = await _BudgetService.DeleteExpenditureFromBudget(elem);
            return Ok(response.Data);
        }

        [HttpPut("{BudgetId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Edit(int BudgetId, [FromBody] EditBudgetDTO Budget)
        {
            var resp2 = await _BudgetService.GetBudgetAsync(u => u.Id == BudgetId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje budzet o id = {BudgetId}" };
            }

            Budget elem = resp2.Data;
            elem.Id = BudgetId;
            elem.Capital = Budget.Capital;
            elem.AccountNumber = Budget.AccountNumber;
            elem.Currency = Budget.Currency;
            elem.PaymentsDeadline = Budget.PaymentsDeadline;
            elem.Log = Budget.Log;
            elem.ActualPeyments = Budget.ActualPeyments;

            var response = await _BudgetService.UpdateBudget(elem);
            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _BudgetService.DeleteBudget(new Budget() { Id = id });
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
