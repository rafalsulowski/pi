
namespace TripPlanner.Models.DTO
{
    public class BillPictureDTO
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public string FilePath { get; set; } = string.Empty;


        public static implicit operator BillPicture(BillPictureDTO data)
        {
            if (data == null)
                return null;

            return new BillPicture
            {
                BillId = data.BillId,
                Id = data.Id,
                FilePath = data.FilePath
            };
        }
    }
}
