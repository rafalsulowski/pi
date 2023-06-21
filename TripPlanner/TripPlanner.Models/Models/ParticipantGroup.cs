using TripPlanner.Models.DTO;

namespace TripPlanner.Models
{
    public class ParticipantGroup
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public Group Group { get; set; } = null!;
        public int GroupId { get; set; }

        public bool IsOrganizer { get; set; }


        public static implicit operator ParticipantGroupDTO(ParticipantGroup data)
        {
            if (data == null)
                return null;

            return new ParticipantGroupDTO
            {
                UserId = data.UserId,
                GroupId = data.GroupId,
                IsOrganizer = data.IsOrganizer,
            };
        }
    }
}
