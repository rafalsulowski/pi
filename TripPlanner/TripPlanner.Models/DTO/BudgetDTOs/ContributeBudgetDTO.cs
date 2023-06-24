namespace TripPlanner.Models.DTO.BudgetDTOs
{
    public class ContributeBudgetDTO
    {
        public int UserId { get; set; }
        public int BudgetId { get; set; }
        public decimal Payment { get; set; }
        public decimal Debt { get; set; }


        public static implicit operator ContributeBudget(ContributeBudgetDTO data)
        {
            if (data == null)
                return null;

            return new ContributeBudget
            {
                UserId = data.UserId,
                BudgetId = data.BudgetId,
                Payment = data.Payment,
                Debt = data.Debt
            };
        }
    }
}
