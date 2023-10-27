using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;
using TripPlanner.Services.CheckListService;
using TripPlanner.Services.QuestionnaireService;
using TripPlanner.Services.RouteService;
using TripPlanner.Services.ParticipantTourService;
using TripPlanner.Services.TourService;
using TripPlanner.Services.CultureAssistanceService;
using TripPlanner.Services.QuestionnaireVoteService;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.UserModels;
using TripPlanner.Models.Models.BillModels;
using TripPlanner.Services.BillService;
using TripPlanner.Services.FriendService;
using TripPlanner.Services.ChatService;
using TripPlanner.Models.Models.MessageModels;
using TripPlanner.Models.Models.MessageModels.QuestionnaireModels;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models.Models.TourModels;

namespace TripPlanner.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IFriendRepository _FriendRepository;
        private readonly ITourService _TourService;
        private readonly IParticipantTourService _ParticipantTourService;
        private readonly ICultureAssistanceService _CultureAssistanceService;
        private readonly IRouteService _RouteService;
        private readonly IQuestionnaireService _QuestionnaireService;
        private readonly IQuestionnaireVoteService _QuestionnaireVoteService;
        private readonly ICheckListService _CheckListService;
        private readonly IBillService _IBillService;
        private readonly IFriendService _FriendService;
        private readonly IChatService _ChatService;
        public UserService(IBillService __IBillService, IFriendService __FriendService, IUserRepository userRepository, ITourService __TourService, IParticipantTourService __ParticipantTourService,
            ICultureAssistanceService __CultureAssistanceService,
            IRouteService __RouteService, IChatService chatService,
            IQuestionnaireService __QuestionnaireService, ICheckListService __CheckListService, IQuestionnaireVoteService __QuestionnaireVoteService, IFriendRepository friendRepository)
        {
            _UserRepository = userRepository;
            _TourService = __TourService;
            _ParticipantTourService = __ParticipantTourService;
            _CultureAssistanceService = __CultureAssistanceService;
            _RouteService = __RouteService;
            _QuestionnaireService = __QuestionnaireService;
            _QuestionnaireVoteService = __QuestionnaireVoteService;
            _CheckListService = __CheckListService;
            _IBillService = __IBillService;
            _FriendService = __FriendService;
            _ChatService = chatService;
            _FriendRepository = friendRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateUser(User user)
        {
            _UserRepository.Add(user);
            var response = await _UserRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteUser(User user)
        {
            var resp = await _UserRepository.GetFirstOrDefault(u => u.Id == user.Id, "Shares,BillContributors,CheckLists,ParticipantTours,Routes,QuestionnaireVotes,Messages");
            if (resp.Data == null)
                return new RepositoryResponse<bool> { Data = true, Message = "Uzytkownik zostal usuniety", Success = true };

            User UserDB = resp.Data;
            //removing ParticipantTours
            foreach (var Participants in UserDB.ParticipantTours)
                await _ParticipantTourService.DeleteParticipantTour(Participants);

            //removing Shares
            foreach (var Shares in UserDB.Shares)
            {
                if(Shares is not null && Shares is Bill)
                    await _IBillService.DeleteBill((Bill)Shares);
                else if (Shares is not null && Shares is Transfer)
                    await _IBillService.DeleteTransfer((Transfer)Shares);
            }

            //removing BillContributors
            foreach (var BillContributors in UserDB.BillContributors)
                await _IBillService.DeleteBillContributors(BillContributors);

            //removing CheckLists
            foreach (var CheckLists in UserDB.CheckLists)
                await _CheckListService.DeleteCheckList(CheckLists);

            //removing QuestionnaireVotes
            foreach (var Questionnaires in UserDB.QuestionnaireVotes)
                await _QuestionnaireVoteService.DeleteQuestionnaireVote(Questionnaires);

            //removing Routes
            foreach (var Routes in UserDB.Routes)
                await _RouteService.DeleteRoute(Routes);

            //removing Messages
            foreach (var Messages in UserDB.Messages)
            {
                if(Messages is not null && Messages is TextMessage)
                    await _ChatService.DeleteTextMessage((TextMessage)Messages);
                else if (Messages is not null && Messages is NoticeMessage)
                    await _ChatService.DeleteNoticeMessage((NoticeMessage)Messages);
                else if (Messages is not null && Messages is Questionnaire)
                    await _QuestionnaireService.DeleteQuestionnaire((Questionnaire)Messages);
            }

            _UserRepository.Remove(UserDB);
            var response = await _UserRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<List<ExtendParticipantDTO>>> GetFriends(int userId)
        {
            var resp = await _FriendRepository.GetAll(u => u.Friend1Id == userId || u.Friend2Id == userId);
            List<ExtendParticipantDTO> listReturn = new List<ExtendParticipantDTO>();
            if (resp.Success)
            {
                if (resp.Data is null)
                {
                    return new RepositoryResponse<List<ExtendParticipantDTO>> { Data = listReturn, Message = "", Success = true };
                }

                List<Friend> list = resp.Data;
                for (int i = 0; i < list.Count; i++)
                {
                    int userIdToSearch = list[i].Friend1Id == userId ? list[i].Friend2Id : list[i].Friend1Id;  
                    User? user = _UserRepository.GetFirstOrDefault(u => u.Id == userIdToSearch).Result?.Data;

                    if (user is null)
                        return new RepositoryResponse<List<ExtendParticipantDTO>> { Data = listReturn, Message = "", Success = true };

                    ExtendParticipantDTO participantDTO = new ExtendParticipantDTO();
                    participantDTO.Order = i + 1;
                    participantDTO.Email = user.Email;
                    participantDTO.City = user.City;
                    participantDTO.Nickname = "";
                    participantDTO.Age = _TourService.CalculateAge(user.DateOfBirth, DateTime.Now);
                    participantDTO.DateOfBirth = user.DateOfBirth;
                    participantDTO.FullName = user.FullName;
                    participantDTO.IsOrganizer = false;

                    listReturn.Add(participantDTO);
                }

            }

            return new RepositoryResponse<List<ExtendParticipantDTO>> { Data = listReturn, Message = "", Success = true };
        }

        public async Task<RepositoryResponse<User>> GetUserAsync(Expression<Func<User, bool>> filter, string? includeProperties = null)
        {
            var response = await _UserRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<User>>> GetUsersAsync(Expression<Func<User, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _UserRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateUser(User user)
        {
            var response = await _UserRepository.Update(user);
            if(response.Success==false)
            {
                return response;
            }
            response = await _UserRepository.SaveChangesAsync();
            return response;
        }
    }
}
