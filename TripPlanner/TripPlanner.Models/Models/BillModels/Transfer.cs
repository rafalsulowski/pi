using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.BillDTOs;

namespace TripPlanner.Models.Models.BillModels
{
    public class Transfer : Share
    {
        public int SenderId { get; set; }
        public TransferContributor Sender { get; set; } = null!;

        public int RecipientId { get; set; }
        public TransferContributor Recipient { get; set; } = null!;


        public static implicit operator TransferDTO(Transfer data)
        {
            if (data == null)
                return null;

            return new TransferDTO
            {
                Id = data.Id,
                CreatedDate = data.CreatedDate,
                CreatorId = data.CreatorId,
                ImageFilePath = data.ImageFilePath,
                Value = data.Value,
                SenderId = data.SenderId,
                RecipientId = data.RecipientId
            };
        }
    }
}
