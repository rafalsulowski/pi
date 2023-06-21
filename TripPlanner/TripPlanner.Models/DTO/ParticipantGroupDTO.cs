
namespace TripPlanner.Models.DTO
{
    public class ParticipantGroupDTO
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public bool IsOrganizer { get; set; }


        public static implicit operator ParticipantGroup(ParticipantGroupDTO data)
        {
            if (data == null)
                return null;

            return new ParticipantGroup
            {
                UserId = data.UserId,
                GroupId = data.GroupId,
                IsOrganizer = data.IsOrganizer,
            };
        }
    }
}
