using TripPlanner.Models.DTO;
using TripPlanner.Models.DTO.BillDTOs;

namespace TripPlanner.Models
{
    public class Bill
    {
        public int Id { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public ICollection<ParticipantBill> Participants { get; set; } = new List<ParticipantBill>();
        public ICollection<BillPicture> Pictures { get; set; } = new List<BillPicture>();
        
        public string Name { get; set; } = string.Empty;
        public decimal Ammount { get; set; }


        public static implicit operator BillDTO(Bill Bill)
        {
            if(Bill == null)
                return null;

            return new BillDTO 
            {
                Id = Bill.Id,
                Name= Bill.Name,
                Ammount= Bill.Ammount,
                TourId= Bill.TourId,
                UserId= Bill.UserId,
                Participants = Bill.Participants.Select(u => (ParticipantBillDTO)u).ToList(),
                Pictures = Bill.Pictures.Select(u => (BillPictureDTO)u).ToList(),
            };
        }
    }
}
