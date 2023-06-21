using TripPlanner.Models.DTO;

namespace TripPlanner.Models
{
    public class BillPicture
    {
        public int Id { get; set; }

        public Bill Bill { get; set; } = null!;
        public int BillId { get; set; }
        public string FilePath { get; set; } = string.Empty;


        public static implicit operator BillPictureDTO(BillPicture data)
        {
            if (data == null)
                return null;

            return new BillPictureDTO
            {
                BillId = data.BillId,
                Id = data.Id,
                FilePath = data.FilePath
            };
        }
    }
}
