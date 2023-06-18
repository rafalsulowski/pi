using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class BudgetDTO
    {
        public int Id { get; set; }

        public int TourId { get; set; }
        public ICollection<ContributesBudgetDTO> Contributes { get; } = new List<ContributesBudgetDTO>();
        public ICollection<BudgetExpenditureDTO> Expenditures { get; } = new List<BudgetExpenditureDTO>();

        public decimal Capital { get; set; }
        public decimal ActualPeyments { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Log { get; set; } = string.Empty;
        public DateTime PaymentsDeadline { get; set; }
    }
}
