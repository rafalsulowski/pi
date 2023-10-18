using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.BillModels;

namespace TripPlanner.Models.DTO.BillDTOs
{
    public class TransferContributorDTO
    {
        public int TransferId { get; set; }
        public int UserId { get; set; }


        public static implicit operator TransferContributor(TransferContributorDTO data)
        {
            if (data == null)
                return null;

            return new TransferContributor
            {
                TransferId = data.TransferId,
                UserId = data.UserId
            };
        }
    }
}
