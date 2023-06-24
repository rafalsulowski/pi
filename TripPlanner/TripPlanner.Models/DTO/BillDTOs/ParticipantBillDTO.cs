
namespace TripPlanner.Models.DTO
{
    public class ParticipantBillDTO
    {
        public int BillId { get; set; }
        public int UserId { get; set; }

        public decimal Payment { get; set; }
        public decimal Debt { get; set; }


        public static implicit operator ParticipantBill(ParticipantBillDTO data)
        {
            if (data == null)
                return null;

            return new ParticipantBill
            {
                BillId = data.BillId,
                UserId = data.UserId,
                Payment = data.Payment,
                Debt = data.Debt
            };
        }
    }
}
