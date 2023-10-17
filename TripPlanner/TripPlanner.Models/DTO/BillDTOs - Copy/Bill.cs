using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models.CheckListModels;

namespace TripPlanner.Models.Models.BillModels
{
    public class BillDTO : ShareDTO
    {
        public int PayerId { get; set; }
        public User Payer { get; set; } = null!;

        public enum BillType
        {
            Equally,
            Unequally,
            ByPercentages,
            ByShares,
            ByAdjustment
        }

        public BillType CollectionType;
        public ICollection<BillContributorDTO> Contributors { get; set; } = new List<BillContributorDTO>();

    }
}
