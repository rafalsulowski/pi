using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models.Message;

namespace TripPlanner.Models.DTO.ChatDTOs
{
    public class TextMessageDTO : MessageDTO
    {
        public int LikesCount; //tymczasowo jako zastepstwo dla reakcji

        public static implicit operator TextMessage(TextMessageDTO data)
        {
            if (data == null)
                return null;

            return new TextMessage
            {
                Id = data.Id,
                UserId = data.UserId,
                ChatId = data.ChatId,
                Content = data.Content,
                Date = data.Date,
                LikesCount = data.LikesCount
            };
        }
    }
}
