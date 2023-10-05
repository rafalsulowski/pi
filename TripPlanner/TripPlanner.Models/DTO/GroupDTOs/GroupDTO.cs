using TripPlanner.Models.DTO.ChatDTOs;

namespace TripPlanner.Models.DTO.GroupDTOs
{
    public class GroupDTO
    {
        public int Id { get; set; }

        public int TourId { get; set; }
        public ChatDTO? Chat { get; set; }
        public ICollection<ParticipantGroupDTO> Participants { get; set; } = new List<ParticipantGroupDTO>();

        public string Name { get; set; } = string.Empty;
        public int Volume { get; set; } //max participants count


        public static implicit operator Group(GroupDTO data)
        {
            if (data == null)
                return null;

            return new Group
            {
                Id = data.Id,
                TourId = data.TourId,
                Chat = data.Chat,
                Participants = data.Participants.Select(u => (ParticipantGroup)u).ToList(),
                Name = data.Name,
                Volume = data.Volume
            };
        }
    }
}
