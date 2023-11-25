using TripPlanner.Models.Models.CheckListModels;

namespace TripPlanner.Models.DTO.CheckListDTOs
{
    public class EditCheckListFieldDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Multiplicity { get; set; } = string.Empty;
        public bool IsChecked { get; set; }


        public static implicit operator CheckListField(EditCheckListFieldDTO data)
        {
            if (data == null)
                return null;

            return new CheckListField
            {
                Name = data.Name,
                Multiplicity = data.Multiplicity,
                IsChecked = data.IsChecked
            };
        }

    }
}
