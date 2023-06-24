namespace TripPlanner.Models.DTO.GroupDTOs
{
    public class EditGroupDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Volume { get; set; }


        public static implicit operator Group(EditGroupDTO data)
        {
            if (data == null)
                return null;

            return new Group
            {
                Name = data.Name,
                Volume = data.Volume
            };
        }
    }
}
