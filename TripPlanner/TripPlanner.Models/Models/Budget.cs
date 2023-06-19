using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
{
    public class Budget
    {
        public int Id { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public ICollection<ContributeBudget> Contributes { get; } = new List<ContributeBudget>();
        public ICollection<BudgetExpenditure> Expenditures { get; } = new List<BudgetExpenditure>();

        public decimal Capital { get; set; }
        public decimal ActualPeyments { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Log { get; set; } = string.Empty;
        public DateTime PaymentsDeadline { get; set; }

        public BudgetDTO MapToDTO()
        {
            return new BudgetDTO
            {
                Id = Id,
                TourId = TourId,
                Contributes = Contributes.Select(x => x.MapToDTO()).ToList(),
                Expenditures = Expenditures.Select(u => u.MapToDTO()).ToList(),
                Capital = Capital,
                ActualPeyments = ActualPeyments,
                AccountNumber = AccountNumber,
                Currency = Currency,
                Log = Log,
                PaymentsDeadline = PaymentsDeadline
            };
        }
    }
}
