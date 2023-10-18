﻿using TripPlanner.Models.DTO.BillDTOs;
using TripPlanner.Models.DTO.CheckListDTOs;
using TripPlanner.Models.DTO.MessageDTOs;
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;
using TripPlanner.Models.DTO.RouteDTOs;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.UserDTOs;
using TripPlanner.Models.Models.BillModels;
using TripPlanner.Models.Models.CheckListModels;
using TripPlanner.Models.Models.MessageModels;
using TripPlanner.Models.Models.MessageModels.QuestionnaireModels;
using TripPlanner.Models.Models.RouteModels;
using TripPlanner.Models.Models.TourModels;

namespace TripPlanner.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public ICollection<CheckList> CheckLists { get; set; } = new List<CheckList>();
        public ICollection<ParticipantTour> ParticipantTours { get; set; } = new List<ParticipantTour>();
        //public ICollection<Questionnaire> Questionnaires { get; set; } = new List<Questionnaire>();
        public ICollection<QuestionnaireVote> QuestionnaireVotes { get; set; } = new List<QuestionnaireVote>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public ICollection<Route> Routes { get; set; } = new List<Route>();
        
        //rachunki w jakich uzytkownik sie sklada
        public ICollection<BillContributor> BillContributors { get; set; } = new List<BillContributor>();
        
        //rachunki w jakich uzytkownik jest platnikiem(ze wgledu na to ze kazdy moze
        //dodawac rachunki z kazdym w roli platnika, nie mozna wykorzystac kolekcji Shares jako
        //list rachunkow ktore oplacil uzytkownik)
        public ICollection<BillContributor> BillsPayed { get; set; } = new List<BillContributor>();
        public ICollection<TransferContributor> TransfersSender { get; set; } = new List<TransferContributor>();
        public ICollection<TransferContributor> TransfersRecipient { get; set; } = new List<TransferContributor>();
        public ICollection<Share> Shares { get; set; } = new List<Share>(); //utworzone
       
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }


        public static implicit operator UserDTO(User User)
        {
            if (User == null)
                return null;

            return new UserDTO
            {
                Id = User.Id,
                CheckLists = User.CheckLists.Select(u => (CheckListDTO)u).ToList(),
                ParticipantTours = User.ParticipantTours.Select(u => (ParticipantTourDTO)u).ToList(),
                //Questionnaires = User.Questionnaires.Select(u => (QuestionnaireDTO)u).ToList(),
                QuestionnaireVotes = User.QuestionnaireVotes.Select(u => (QuestionnaireVoteDTO)u).ToList(),
                Messages = User.Messages.Select(u => (MessageDTO)u).ToList(),
                Routes = User.Routes.Select(u => (RouteDTO)u).ToList(),
                BillContributors = User.BillContributors.Select(u => (BillContributorDTO)u).ToList(),
                TransfersSender = User.TransfersSender.Select(u => (TransferContributorDTO)u).ToList(),
                TransfersRecipient = User.TransfersRecipient.Select(u => (TransferContributorDTO)u).ToList(),
                Shares = User.Shares.Select(u => (ShareDTO)u).ToList(),
                Email = User.Email,
                FullName = User.FullName,
                FullAddress = User.FullAddress,
                City = User.City,
                DateOfBirth = User.DateOfBirth
            };
        }
    }
}
