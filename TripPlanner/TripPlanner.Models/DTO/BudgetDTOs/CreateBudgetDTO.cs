
namespace TripPlanner.Models.DTO.BudgetDTOs
{
    public class CreateBudgetDTO
    {
        public int TourId { get; set; }
        public decimal Capital { get; set; }
        public decimal ActualPeyments { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Log { get; set; } = string.Empty;
        public DateTime PaymentsDeadline { get; set; }

        public static implicit operator Budget(CreateBudgetDTO Budget)
        {
            if(Budget == null)
                return null;
            
            return new Budget
            {
                TourId = Budget.TourId,
                Capital = Budget.Capital,
                ActualPeyments = Budget.ActualPeyments,
                AccountNumber = Budget.AccountNumber,
                Currency = Budget.Currency,
                Log = Budget.Log,
                PaymentsDeadline = Budget.PaymentsDeadline
            };
        }
    }
}
