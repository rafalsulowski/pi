namespace TripPlanner.Models.DTO.ChatDTOs
{
    public class CreateChatDTO
    {
        public int GroupId { get; set; }

        public static implicit operator Chat(CreateChatDTO data)
        {
            if (data == null)
                return null;

            return new Chat
            {
                GroupId = data.GroupId,
            };
        }
    }
}
