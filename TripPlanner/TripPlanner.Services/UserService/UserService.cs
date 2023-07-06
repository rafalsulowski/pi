using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;
using TripPlanner.Services.BillService;
using TripPlanner.Services.BudgetService;
using TripPlanner.Services.CheckListService;
using TripPlanner.Services.GroupService;
using TripPlanner.Services.QuestionnaireService;
using TripPlanner.Services.RouteService;
using TripPlanner.Services.ParticipantTourService;
using TripPlanner.Services.TourService;
using TripPlanner.Services.OrganizerTourService;
using TripPlanner.Services.CultureAssistanceService;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Services.ParticipantBillService;
using TripPlanner.Services.ParticipantGroupService;
using TripPlanner.Services.ContributeBudgetService;
using TripPlanner.Services.QuestionnaireVoteService;
using TripPlanner.Services.MessageService;

namespace TripPlanner.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly ITourService _TourService;
        private readonly IParticipantTourService _ParticipantTourService;
        private readonly IOrganizerTourService _OrganizerTourService;
        private readonly ICultureAssistanceService _CultureAssistanceService;
        private readonly IContributeBudgetService _ContributeBudgetService;
        private readonly IBillService _BillService;
        private readonly IRouteService _RouteService;
        private readonly IMessageService _MessageService;
        private readonly IParticipantBillService _ParticipantBillService;
        private readonly IParticipantGroupService _ParticipantGroupService;
        private readonly IQuestionnaireService _QuestionnaireService;
        private readonly IQuestionnaireVoteService _QuestionnaireVoteService;
        private readonly ICheckListService _CheckListService;
        public UserService(IUserRepository userRepository, ITourService __TourService, IParticipantTourService __ParticipantTourService,
            IOrganizerTourService __OrganizerTourService, ICultureAssistanceService __CultureAssistanceService,
            IContributeBudgetService __ContributeBudgetService, IBillService __BillService, IRouteService __RouteService, IParticipantGroupService __ParticipantGroupService, 
            IQuestionnaireService __QuestionnaireService, ICheckListService __CheckListService, IParticipantBillService __ParticipantBillService, IQuestionnaireVoteService __QuestionnaireVoteService, IMessageService __MessageService)
        {
            _UserRepository = userRepository;
            _TourService = __TourService;
            _ParticipantTourService = __ParticipantTourService;
            _OrganizerTourService = __OrganizerTourService;
            _CultureAssistanceService = __CultureAssistanceService;
            _ContributeBudgetService = __ContributeBudgetService;
            _BillService = __BillService;
            _RouteService = __RouteService;
            _MessageService = __MessageService;
            _ParticipantGroupService = __ParticipantGroupService;
            _QuestionnaireService = __QuestionnaireService;
            _QuestionnaireVoteService = __QuestionnaireVoteService;
            _CheckListService = __CheckListService;
            _ParticipantBillService = __ParticipantBillService;
        }

        public async Task<RepositoryResponse<bool>> CreateUser(User user)
        {
            _UserRepository.Add(user);
            var response = await _UserRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteUser(User user)
        {
            var resp = await _UserRepository.GetFirstOrDefault(u => u.Id == user.Id, "CheckLists,OrganizerTours,ParticipantTours,ParticipantBudgets,ParticipantGroups,Routes,Bills,Questionnaires,QuestionnaireVotes,Messages,BillSettle");
            if (resp.Data == null)
                return new RepositoryResponse<bool> { Data = true, Message = "Uzytkownik zostal usuniety", Success = true };

            //removing OrganizerTours
            User UserDB = resp.Data;
            foreach (var Organizers in UserDB.OrganizerTours)
                await _OrganizerTourService.DeleteOrganizerTour(Organizers);

            //removing ParticipantTours
            foreach (var Participants in UserDB.ParticipantTours)
                await _ParticipantTourService.DeleteParticipantTour(Participants);

            //removing ParticipantBudgets
            foreach (var CultureAssistances in UserDB.ParticipantBudgets)
                await _ContributeBudgetService.DeleteContributeBudget(CultureAssistances);

            //removing CheckLists
            foreach (var CheckLists in UserDB.CheckLists)
                await _CheckListService.DeleteCheckList(CheckLists);

            //removing Questionnaires
            foreach (var Questionnaires in UserDB.Questionnaires)
                await _QuestionnaireService.DeleteQuestionnaire(Questionnaires);

            //removing QuestionnaireVotes
            foreach (var Questionnaires in UserDB.QuestionnaireVotes)
                await _QuestionnaireVoteService.DeleteQuestionnaireVote(Questionnaires);

            //removing ParticipantGroups
            foreach (var Groups in UserDB.ParticipantGroups)
                await _ParticipantGroupService.DeleteParticipantGroup(Groups);

            //removing Routes
            foreach (var Routes in UserDB.Routes)
                await _RouteService.DeleteRoute(Routes);

            //removing BillSettle
            foreach (var Bills in UserDB.BillSettle)
                await _ParticipantBillService.DeleteParticipantBill(Bills);

            //removing Bills
            foreach (var Bills in UserDB.Bills)
                await _BillService.DeleteBill(Bills);

            //removing Bills
            foreach (var Bills in UserDB.Messages)
                await _MessageService.DeleteMessage(Bills);


            _UserRepository.Remove(UserDB);
            var response = await _UserRepository.SaveChangesAsync();
            return response;
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
