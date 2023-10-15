using TripPlanner.Models.Models.CheckListModels;

namespace TripPlanner.Models.DTO.CheckListDTOs
{
    public class CheckListDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int TourId { get; set; }
        public ICollection<CheckListFieldDTO> Fields { get; set; } = new List<CheckListFieldDTO>();

        public string Name { get; set; } = string.Empty;
        public bool IsPublic { get; set; }


        public static implicit operator CheckList(CheckListDTO data)
        {
            if (data == null)
                return null;

            return new CheckList
            {
                Id = data.Id,
                UserId = data.UserId,
                TourId = data.TourId,
                Fields = data.Fields.Select(u => (CheckListField)u).ToList(),
                Name = data.Name,
                IsPublic = data.IsPublic
            };
        }
    }
}
