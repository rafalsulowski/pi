using TripPlanner.Models.DTO.GroupDTOs;

namespace TripPlanner.Models
{
    public class Group
    {
        public int Id { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public Chat? Chat { get; set; }
        public ICollection<ParticipantGroup> Participants { get; set; } = new List<ParticipantGroup>();

        public string Name { get; set; } = string.Empty;
        public int Volume { get; set; }


        public static implicit operator GroupDTO(Group data)
        {
            if (data == null)
                return null;

            return new GroupDTO
            {
                Id = data.Id,
                TourId = data.TourId,
                Chat = data.Chat,
                Participants = data.Participants.Select(u => (ParticipantGroupDTO)u).ToList(),
                Name = data.Name,
                Volume = data.Volume
            };
        }
    }
}
