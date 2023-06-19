using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
{
    public class Bill
    {
        public int Id { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public ICollection<ParticipantBill> Participants { get; } = new List<ParticipantBill>();
        public ICollection<BillPicture> Pictures { get; } = new List<BillPicture>();
        
        public string Name { get; set; } = string.Empty;
        public decimal Ammount { get; set; }

        public BillDTO MapToDTO()
        {
            return new BillDTO 
            {
                Id = Id,
                Name= Name,
                Ammount= Ammount,
                TourID= TourId,
                UserID= UserId,
                Participants = Participants.Select(u => u.MapToDTO()).ToList(),
                Pictures = Pictures.Select(u => u.MapToDTO()).ToList(),
            };
        }
    }
}
