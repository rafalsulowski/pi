using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.BillDTOs;
using TripPlanner.Models.Models.TourModels;

namespace TripPlanner.Models.Models.BillModels
{
    public class Share
    {
        public int Id { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; } = null!;
        public int CreatorId { get; set; }
        public User Creator { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
        public decimal Value { get; set; }
        public string ImageFilePath { get; set; } = string.Empty;


        public static implicit operator ShareDTO(Share data)
        {
            if (data == null)
                return null;

            return new ShareDTO
            {
                Id = data.Id,
                TourId = data.TourId,
                CreatedDate = data.CreatedDate,
                CreatorId = data.CreatorId,
                ImageFilePath = data.ImageFilePath,
                Value = data.Value,
            };
        }
    }
}
