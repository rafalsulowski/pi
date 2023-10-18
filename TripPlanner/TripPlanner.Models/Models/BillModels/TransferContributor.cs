using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.BillDTOs;

namespace TripPlanner.Models.Models.BillModels
{
    public class TransferContributor
    {
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;


        public static implicit operator TransferContributorDTO(TransferContributor data)
        {
            if (data == null)
                return null;

            return new TransferContributorDTO
            {
                TransferId = data.TransferId,
                UserId = data.UserId
            };
        }
    }
}
