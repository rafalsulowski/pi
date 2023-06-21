
namespace TripPlanner.Models.DTO.BillDTOs
{
    public class BillDTO
    {
        public int Id { get; set; }

        public int TourId { get; set; }
        public int UserId { get; set; }
        public ICollection<ParticipantBillDTO> Participants { get; set; } = new List<ParticipantBillDTO>();
        public ICollection<BillPictureDTO> Pictures { get; set; } = new List<BillPictureDTO>();

        public string Name { get; set; } = string.Empty;
        public decimal Ammount { get; set; }


        public static implicit operator Bill(BillDTO BillDTO)
        {
            if (BillDTO == null)
                return null;

            return new Bill
            {
                Id = BillDTO.Id,
                Name = BillDTO.Name,
                Ammount = BillDTO.Ammount,
                TourId = BillDTO.TourId,
                UserId = BillDTO.UserId,
                Participants = BillDTO.Participants.Select(u => (ParticipantBill)u).ToList(),
                Pictures = BillDTO.Pictures.Select(u => (BillPicture)u).ToList(),
            };
        }
    }
}
