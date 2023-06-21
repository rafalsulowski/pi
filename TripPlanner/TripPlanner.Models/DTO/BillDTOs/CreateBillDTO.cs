
namespace TripPlanner.Models.DTO.BillDTOs
{
    public class CreateBillDTO
    {
        public int TourId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Ammount { get; set; }


        public static implicit operator Bill(CreateBillDTO BillDTO)
        {
            if (BillDTO == null)
                return null;

            return new Bill
            {
                Name = BillDTO.Name,
                Ammount = BillDTO.Ammount,
                TourId = BillDTO.TourId,
                UserId = BillDTO.UserId,
            };
        }
    }
}
