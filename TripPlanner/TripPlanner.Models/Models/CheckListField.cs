﻿using TripPlanner.Models.DTO.CheckListDTOs;

namespace TripPlanner.Models
{
    public class CheckListField
    {
        public int Id { get; set; }

        public CheckList CheckList { get; set; } = null!;
        public int CheckListId { get; set; }

        public string Name { get; set; } = string.Empty;
        public int Multiplicity { get; set; }
        public bool IsChecked{ get; set; }
        

        public static implicit operator CheckListFieldDTO(CheckListField data)
        {
            if (data == null)
                return null;

            return new CheckListFieldDTO
            {
                Id = data.Id,
                CheckListId = data.CheckListId,
                Name = data.Name,
                Multiplicity = data.Multiplicity,
                IsChecked = data.IsChecked
            };
        }
    }
}
