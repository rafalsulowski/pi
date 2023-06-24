using TripPlanner.Models.DTO;

namespace TripPlanner.Models
{
    public class ParticipantBill
    {
        public Bill Bill { get; set; } = null!;
        public int BillId { get; set; }
        public User User { get; set; } = null!;
        public int UserId { get; set; }

        public decimal Payment { get; set; }
        public decimal Debt { get; set; }


        public static implicit operator ParticipantBillDTO(ParticipantBill data)
        {
            if (data == null)
                return null;

            return new ParticipantBillDTO
            {
                BillId = data.BillId,
                UserId = data.UserId,
                Payment = data.Payment,
                Debt = data.Debt
            };
        }
    }
}
