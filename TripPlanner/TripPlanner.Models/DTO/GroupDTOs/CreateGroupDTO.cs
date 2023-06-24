namespace TripPlanner.Models.DTO.GroupDTOs
{
    public class CreateGroupDTO
    {
        public int TourId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Volume { get; set; }


        public static implicit operator Group(CreateGroupDTO data)
        {
            if (data == null)
                return null;

            return new Group
            {
                TourId = data.TourId,
                Name = data.Name,
                Volume = data.Volume
            };
        }
    }
}
