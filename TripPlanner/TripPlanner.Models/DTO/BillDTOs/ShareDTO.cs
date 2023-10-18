﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.BillModels;

namespace TripPlanner.Models.DTO.BillDTOs
{
    public class ShareDTO
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public int CreatorId { get; set; }

        public DateTime CreatedDate { get; set; }
        public decimal Value { get; set; }
        public string ImageFilePath { get; set; } = string.Empty;

        public static implicit operator Share(ShareDTO data)
        {
            if (data == null)
                return null;

            return new Share
            {
                Id = data.Id,
                CreatedDate = data.CreatedDate,
                CreatorId = data.CreatorId,
                ImageFilePath = data.ImageFilePath,
                Value = data.Value,
            };
        }
    }
}
