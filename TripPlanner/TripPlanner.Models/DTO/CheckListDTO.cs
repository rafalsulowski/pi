using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class CheckListDTO
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public int TourId { get; set; }
        public ICollection<CheckListFieldDTO> Fields { get; set; } = new List<CheckListFieldDTO>();


        public string Name { get; set; } = string.Empty;
        public bool IsPublic { get; set; }
    }
}
