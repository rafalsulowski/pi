namespace TripPlanner.Models.DTO.BudgetDTOs
{
    public class EditBudgetDTO
    {
        public decimal Capital { get; set; }
        public decimal ActualPeyments { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Log { get; set; } = string.Empty;
        public DateTime PaymentsDeadline { get; set; }


        public static implicit operator Budget(EditBudgetDTO data)
        {
            if (data == null)
                return null;

            return new Budget
            {
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
