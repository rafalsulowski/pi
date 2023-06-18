using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class CheckListFieldDTO
    {
        public int Id { get; set; }
        public int CheckListId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Multiplicity { get; set; }
        public bool IsChecked{ get; set; }

    }
}
