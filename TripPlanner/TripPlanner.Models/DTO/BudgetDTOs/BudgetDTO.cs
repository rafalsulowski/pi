namespace TripPlanner.Models.DTO.BudgetDTOs
{
    public class BudgetDTO
    {
        public int Id { get; set; }

        public int TourId { get; set; }
        public ICollection<ContributeBudgetDTO> Contributes { get; set; } = new List<ContributeBudgetDTO>();
        public ICollection<BudgetExpenditureDTO> Expenditures { get; set; } = new List<BudgetExpenditureDTO>();

        public decimal Capital { get; set; }
        public decimal ActualPeyments { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Log { get; set; } = string.Empty;
        public DateTime PaymentsDeadline { get; set; }


        public static implicit operator Budget(BudgetDTO data)
        {
            if (data == null)
                return null;

            return new Budget
            {
                Id = data.Id,
                TourId = data.TourId,
                Contributes = data.Contributes.Select(u => (ContributeBudget)u).ToList(),
                Expenditures = data.Expenditures.Select(u => (BudgetExpenditure)u).ToList(),
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
