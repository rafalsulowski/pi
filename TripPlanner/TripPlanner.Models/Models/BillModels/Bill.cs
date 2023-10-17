using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models.CheckListModels;

namespace TripPlanner.Models.Models.BillModels
{
    public enum BillType
    {
        Equally = 0,
        Unequally = 1,
        ByPercentages = 2,
        ByShares = 3,
        ByAdjustment = 4
    }

    public class Bill : Share
    {
        public int PayerId { get; set; }
        public User Payer { get; set; } = null!;

        public BillType BillType { get; set; }
        public ICollection<BillContributor> Contributors { get; set; } = new List<BillContributor>();
    }
}
