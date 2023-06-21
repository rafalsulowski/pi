using TripPlanner.Models.DTO;
using TripPlanner.Models.DTO.BudgetDTOs;

namespace TripPlanner.Models
{
    public class Budget
    {
        public int Id { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public ICollection<ContributeBudget> Contributes { get; set; } = new List<ContributeBudget>();
        public ICollection<BudgetExpenditure> Expenditures { get; set; } = new List<BudgetExpenditure>();

        public decimal Capital { get; set; }
        public decimal ActualPeyments { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Log { get; set; } = string.Empty;
        public DateTime PaymentsDeadline { get; set; }


        public static implicit operator BudgetDTO(Budget data)
        {
            if (data == null)
                return null;

            return new BudgetDTO
            {
                Id = data.Id,
                TourId = data.TourId,
                Contributes = data.Contributes.Select(x => (ContributeBudgetDTO)x).ToList(),
                Expenditures = data.Expenditures.Select(u => (BudgetExpenditureDTO)u).ToList(),
                Capital = data.Capital,
                ActualPeyments = data.ActualPeyments,
                AccountNumber = data.AccountNumber,
                Currency = data.Currency,
                Log = data.Log,
                PaymentsDeadline = data.PaymentsDeadline
            };
        }
    }
}
