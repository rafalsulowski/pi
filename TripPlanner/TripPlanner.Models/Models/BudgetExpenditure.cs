using TripPlanner.Models.DTO.BudgetDTOs;

namespace TripPlanner.Models
{
    public class BudgetExpenditure
    {
        public int Id { get; set; }

        public Budget Budget { get; set; } = null!;
        public int BudgetId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Cost { get; set; }


        public static implicit operator BudgetExpenditureDTO(BudgetExpenditure data)
        {
            if (data == null)
                return null;

            return new BudgetExpenditureDTO
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description,
                Cost = data.Cost,
                BudgetId = data.BudgetId
            };
        }
    }
}
