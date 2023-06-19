using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
{
    public class CheckList
    {
        public int Id { get; set; }

        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public ICollection<CheckListField> Fields { get; } = new List<CheckListField>();


        public string Name { get; set; } = string.Empty;
        public bool IsPublic { get; set; }

        public CheckListDTO MapToDTO()
        {
            return new CheckListDTO
            {
                Id = Id,
                UserId = UserId,
                TourId = TourId,
                Fields = Fields.Select(u => u.MapToDTO()).ToList(),
                Name = Name,
                IsPublic = IsPublic
            };
        }
    }
}
