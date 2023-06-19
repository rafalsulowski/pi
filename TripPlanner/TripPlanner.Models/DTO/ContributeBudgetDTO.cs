using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class ContributeBudgetDTO
    {
        public int UserId { get; set; }
        public int BudgetId { get; set; }
        public decimal Payment { get; set; }
        public decimal Debt { get; set; }
    }
}
