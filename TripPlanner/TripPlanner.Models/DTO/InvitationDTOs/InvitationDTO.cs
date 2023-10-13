using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models;

namespace TripPlanner.Models.DTO.InvitationDTOs
{
    public class InvitationDTO
    {
        public int UserId { get; set; }
        public int TourId { get; set; }
        public int ExhibitorId { get; set; }

        public DateTime InvitationDate { get; set; }


        public static implicit operator Invitation(InvitationDTO data)
        {
            if (data == null)
                return null;

            return new Invitation
            {
                UserId = data.UserId,
                TourId = data.TourId,
                ExhibitorId = data.ExhibitorId,
                InvitationDate = data.InvitationDate,
            };
        }
    }
}
