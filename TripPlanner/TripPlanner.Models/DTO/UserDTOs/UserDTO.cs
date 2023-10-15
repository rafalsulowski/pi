using TripPlanner.Models.DTO.CheckListDTOs;
using TripPlanner.Models.DTO.MessageDTOs;
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;
using TripPlanner.Models.DTO.RouteDTOs;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.CheckListModels;
using TripPlanner.Models.Models.MessageModels;
using TripPlanner.Models.Models.MessageModels.QuestionnaireModels;
using TripPlanner.Models.Models.RouteModels;
using TripPlanner.Models.Models.TourModels;

namespace TripPlanner.Models.DTO.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public ICollection<CheckListDTO> CheckLists { get; set; } = new List<CheckListDTO>();
        public ICollection<ParticipantTourDTO> ParticipantTours { get; set; } = new List<ParticipantTourDTO>();
        public ICollection<QuestionnaireDTO> Questionnaires { get; set; } = new List<QuestionnaireDTO>();
        public ICollection<QuestionnaireVoteDTO> QuestionnaireVotes { get; set; } = new List<QuestionnaireVoteDTO>();
        public ICollection<MessageDTO> Messages { get; set; } = new List<MessageDTO>();
        public ICollection<RouteDTO> Routes { get; set; } = new List<RouteDTO>();
       
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }


        public static implicit operator User(UserDTO User)
        {
            if (User == null)
                return null;

            return new User
            {
                Id = User.Id,
                CheckLists = User.CheckLists.Select(u => (CheckList)u).ToList(),
                ParticipantTours = User.ParticipantTours.Select(u => (ParticipantTour)u).ToList(),
                Questionnaires = User.Questionnaires.Select(u => (Questionnaire)u).ToList(),
                QuestionnaireVotes = User.QuestionnaireVotes.Select(u => (QuestionnaireVote)u).ToList(),
                Messages = User.Messages.Select(u => (Message)u).ToList(),
                Routes = User.Routes.Select(u => (Route)u).ToList(),
                Email = User.Email,
                FullName = User.FullName,
                FullAddress = User.FullAddress,
                City = User.City,
                DateOfBirth = User.DateOfBirth,
            };
        }
    }
}
