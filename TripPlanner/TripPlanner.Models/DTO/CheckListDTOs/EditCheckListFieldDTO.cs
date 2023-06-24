namespace TripPlanner.Models.DTO.CheckListDTOs
{
    public class EditCheckListFieldDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Multiplicity { get; set; }
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
