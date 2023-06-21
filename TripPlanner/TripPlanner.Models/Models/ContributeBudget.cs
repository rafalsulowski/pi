using TripPlanner.Models.DTO;

namespace TripPlanner.Models
{
    public class ContributeBudget
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public Budget Budget { get; set; } = null!;
        public int BudgetId { get; set; }

        public decimal Payment { get; set; }
        public decimal Debt { get; set; }


        public static implicit operator ContributeBudgetDTO(ContributeBudget data)
        {
            if (data == null)
                return null;

            return new ContributeBudgetDTO
            {
                UserId = data.UserId,
                BudgetId = data.BudgetId,
                Payment = data.Payment,
                Debt = data.Debt
            };
        }
    }
}
