
namespace TripPlanner.Models.DTO
{
    public class CheckListFieldDTO
    {
        public int Id { get; set; }
        public int CheckListId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Multiplicity { get; set; }
        public bool IsChecked{ get; set; }


        public static implicit operator CheckListField(CheckListFieldDTO data)
        {
            if (data == null)
                return null;

            return new CheckListField
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
