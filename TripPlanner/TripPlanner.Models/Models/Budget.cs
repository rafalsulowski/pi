using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class Budget
    {
        public int Id { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public ICollection<ContributesBudget> Contributes { get; } = new List<ContributesBudget>();
        public ICollection<BugetExpenditure> Expenditures { get; } = new List<BugetExpenditure>();

        public decimal Capital { get; set; }
        public decimal ActualPeyments { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Log { get; set; } = string.Empty;
        public DateTime PaymentsDeadline { get; set; }
    }
}
