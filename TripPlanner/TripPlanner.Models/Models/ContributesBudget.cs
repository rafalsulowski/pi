using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class ContributesBudget
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }

        public Budget Budget { get; set; } = null!;
        public int BudgetId { get; set; }

        public decimal Payment { get; set; }
        public decimal Debt { get; set; }
    }
}
