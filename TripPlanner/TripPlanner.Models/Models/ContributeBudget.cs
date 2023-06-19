using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
{
    public class ContributeBudget
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public Budget Budget { get; set; } = null!;
        public int BudgetId { get; set; }

        public decimal Payment { get; set; }
        public decimal Debt { get; set; }

        public ContributeBudgetDTO MapToDTO()
        {
            return new ContributeBudgetDTO
            {
                UserId = UserId,
                BudgetId = BudgetId,
                Payment = Payment,
                Debt = Debt
            };
        }
    }
}
