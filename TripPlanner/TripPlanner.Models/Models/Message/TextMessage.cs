using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.ChatDTOs;

namespace TripPlanner.Models.Models.Message
{
    public class TextMessage : Message
    {
        public int LikesCount; //tymczasowo jako zastepstwo dla reakcji

        public static implicit operator TextMessageDTO(TextMessage data)
        {
            if (data == null)
                return null;

            return new TextMessageDTO
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
