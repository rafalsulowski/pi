using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class CheckListField
    {
        public int Id { get; set; }

        public CheckList CheckList { get; set; } = null!;
        public int CheckListId { get; set; }

        public string Name { get; set; } = string.Empty;
        public int Multiplicity { get; set; }
        public bool IsChecked{ get; set; }

    }
}
