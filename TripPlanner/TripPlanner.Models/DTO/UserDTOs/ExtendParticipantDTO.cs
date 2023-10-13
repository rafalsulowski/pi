using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.BillDTOs;
using TripPlanner.Models.DTO.BudgetDTOs;
using TripPlanner.Models.DTO.ChatDTOs;
using TripPlanner.Models.DTO.CheckListDTOs;
using TripPlanner.Models.DTO.GroupDTOs;
using TripPlanner.Models.DTO.QuestionnaireDTOs;
using TripPlanner.Models.DTO.RouteDTOs;
using TripPlanner.Models.DTO.TourDTOs;

namespace TripPlanner.Models.DTO.UserDTOs
{
    public class ExtendParticipantDTO
    {
        public int Id { get; set; }

        public int Order { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public bool IsOrganizer { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }

    }
}
