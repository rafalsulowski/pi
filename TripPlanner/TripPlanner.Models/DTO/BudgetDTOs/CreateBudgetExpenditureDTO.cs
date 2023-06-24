
namespace TripPlanner.Models.DTO.BudgetDTOs
{
    public class CreateBudgetExpenditureDTO
    {
        public int BudgetId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Cost { get; set; }


        public static implicit operator BudgetExpenditure(CreateBudgetExpenditureDTO data)
        {
            if (data == null)
                return null;

            return new BudgetExpenditure
            {
                Name = data.Name,
                Description = data.Description,
                Cost = data.Cost,
                BudgetId = data.BudgetId
            };
        }
    }
}
