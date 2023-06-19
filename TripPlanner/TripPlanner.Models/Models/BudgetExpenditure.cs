﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
{
    public class BudgetExpenditure
    {
        public int Id { get; set; }

        public Budget Budget { get; set; } = null!;
        public int BudgetId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Cost { get; set; }

        public BudgetExpenditureDTO MapToDTO()
        {
            return new BudgetExpenditureDTO
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Cost = Cost,
                BudgetId = BudgetId,
            };
        }
    }
}
