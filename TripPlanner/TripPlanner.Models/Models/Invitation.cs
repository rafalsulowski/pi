using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.InvitationDTOs;
using TripPlanner.Models.DTO.TourDTOs;

namespace TripPlanner.Models.Models
{
    /// <summary>
    /// Klasa Invitation reprezentuje zaproszenie do wyjazdu
    /// </summary>
    public class Invitation
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }

        public User Exhibitor { get; set; } = null!;
        public int ExhibitorId { get; set; }

        public DateTime InvitationDate { get; set; }


        public static implicit operator InvitationDTO(Invitation data)
        {
            if (data == null)
                return null;

            return new InvitationDTO
            {
                UserId = data.UserId,
                TourId = data.TourId,
                ExhibitorId = data.ExhibitorId,
                InvitationDate = data.InvitationDate,
            };
        }
    }
}
