using System;
using System.Collections.Generic;
using TripPlanner.Models.Models.BillModels;

namespace TripPlanner.Models.DTO.BillDTOs
{
    public class BillDTO
    {
        public int PayerId { get; set; }

        public BillType CollectionType;
        public ICollection<BillContributor> Contributors { get; set; } = new List<BillContributor>();
    }
}
