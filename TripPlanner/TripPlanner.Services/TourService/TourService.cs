using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;
using TripPlanner.Services.BudgetService;
using TripPlanner.Services.GroupService;
using TripPlanner.Services.BillService;
using TripPlanner.Services.RouteService;
using TripPlanner.Services.QuestionnaireService;
using TripPlanner.Services.CheckListService;
using TripPlanner.Models.Models.Tour;

namespace TripPlanner.Services.TourService
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _TourRepository;
        private readonly IParticipantTourRepository _ParticipantTourRepository;
        private readonly IOrganizerTourRepository _OrganizerTourRepository;
        private readonly ICultureAssistanceRepository _CultureAssistanceRepository;
        private readonly IGroupRepository _GroupRepository;
        private readonly IBudgetService _BudgetService;
        private readonly IBillService _BillService;
        private readonly IRouteService _RouteService;
        private readonly IGroupService _GroupService;
        private readonly IQuestionnaireService _QuestionnaireService;
        private readonly ICheckListService _CheckListService;

        public TourService(ITourRepository TourRepository, IParticipantTourRepository participantTourRepository, IOrganizerTourRepository organizerTourRepository,
            ICultureAssistanceRepository __CultureAssistanceRepository, IGroupRepository __GroupRepository, IBudgetService __BudgetService, IBillService __BillService, IRouteService __RouteService,
            IGroupService __GroupService, IQuestionnaireService __QuestionnaireService, ICheckListService __CheckListService)
        {
            _TourRepository = TourRepository;
            _ParticipantTourRepository = participantTourRepository;
            _OrganizerTourRepository = organizerTourRepository;
            _CultureAssistanceRepository = __CultureAssistanceRepository;
            _GroupRepository = __GroupRepository;
            _BudgetService = __BudgetService;
            _BillService = __BillService;
            _RouteService = __RouteService;
            _GroupService = __GroupService;
            _QuestionnaireService = __QuestionnaireService;
            _CheckListService = __CheckListService;
        }

        public async Task<RepositoryResponse<bool>> CreateTour(Tour Tour)
        {
            _TourRepository.Add(Tour);
            var response = await _TourRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteTour(Tour Tour)
        {
            var resp = await _TourRepository.GetFirstOrDefault(u => u.Id == Tour.Id, "Organizers,Participants,CheckLists,Questionnaires,Groups,Routes,Bills,CultureAssistances,Budget");
            if (resp.Data == null)
                return new RepositoryResponse<bool> { Data = true, Message = "Wycieczka zostala usunieta", Success = true };

            //removing Organizers
            Tour TourDB = resp.Data;
            foreach (var Organizers in TourDB.Organizers)
                _OrganizerTourRepository.Remove(Organizers);

            //removing Participants
            foreach (var Participants in TourDB.Participants)
                _ParticipantTourRepository.Remove(Participants);

            //removing CultureAssistances
            foreach (var CultureAssistances in TourDB.CultureAssistances)
                _CultureAssistanceRepository.Remove(CultureAssistances);

            //removing CheckLists
            foreach (var CheckLists in TourDB.CheckLists)
                await _CheckListService.DeleteCheckList(CheckLists);

            //removing Questionnaires
            foreach (var Questionnaires in TourDB.Questionnaires)
                await _QuestionnaireService.DeleteQuestionnaire(Questionnaires);

            //removing Groups
            foreach (var Groups in TourDB.Groups)
                await _GroupService.DeleteGroup(Groups);

            //removing Routes
            foreach (var Routes in TourDB.Routes)
                await _RouteService.DeleteRoute(Routes);

            //removing Bills
            foreach (var Bills in TourDB.Bills)
                await _BillService.DeleteBill(Bills);

            await _BudgetService.DeleteBudget(TourDB.Budget);

            _TourRepository.Remove(TourDB);
            var response = await _TourRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Tour>> GetTourAsync(Expression<Func<Tour, bool>> filter, string? includeProperties = null)
        {
            var response = await _TourRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        //public async Task<RepositoryResponse<List<Tour>>> GetUserToursAsync(int userId)
        //{
        //    var response = await _TourRepository.GetUserToursAsync(userId);
        //    return response;
        //}

        public async Task<RepositoryResponse<List<Tour>>> GetToursAsync(Expression<Func<Tour, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _TourRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<ParticipantTour>> GetParticipantAsync(Expression<Func<ParticipantTour, bool>> filter, string? includeProperties = null)
        {
            var response = await _ParticipantTourRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<ParticipantTour>>> GetParticipantsAsync(Expression<Func<ParticipantTour, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _ParticipantTourRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<Group>> GetGroupAsync(Expression<Func<Group, bool>> filter, string? includeProperties = null)
        {
            var response = await _GroupRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Group>>> GetGroupsAsync(Expression<Func<Group, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _GroupRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<OrganizerTour>> GetOrganizerAsync(Expression<Func<OrganizerTour, bool>> filter, string? includeProperties = null)
        {
            var response = await _OrganizerTourRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<OrganizerTour>>> GetOrganizersAsync(Expression<Func<OrganizerTour, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _OrganizerTourRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<CultureAssistance>> GetCultureAssistanceAsync(Expression<Func<CultureAssistance, bool>> filter, string? includeProperties = null)
        {
            var response = await _CultureAssistanceRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<CultureAssistance>>> GetCulturesAssistanceAsync(Expression<Func<CultureAssistance, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _CultureAssistanceRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateTour(Tour Tour)
        {
            var response = await _TourRepository.Update(Tour);
            if (response.Success == false)
            {
                return response;
            }
            response = await _TourRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> AddCultureAssistanceToTour(CultureAssistance Contribute)
        {
            await _TourRepository.AddCultureAssistanceToTour(Contribute);
            return await _TourRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> DeleteCultureAssistanceFromTour(CultureAssistance Contribute)
        {
            await _TourRepository.DeleteCultureAssistanceFromTour(Contribute);
            return await _TourRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> AddOrganizerToTour(OrganizerTour Contribute)
        {
            await _TourRepository.AddOrganizerToTour(Contribute);
            return await _TourRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> DeleteOrganizerFromTour(OrganizerTour Contribute)
        {
            await _TourRepository.DeleteOrganizerFromTour(Contribute);
            return await _TourRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> AddParticipantToTour(ParticipantTour Contribute)
        {
            await _TourRepository.AddParticipantToTour(Contribute);
            return await _TourRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> DeleteParticipantFromTour(ParticipantTour Contribute)
        {
            await _TourRepository.DeleteParticipantFromTour(Contribute);
            return await _TourRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> AddGroupToTour(Group Group)
        {
            await _TourRepository.AddGroupToTour(Group);
            return await _TourRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> DeleteGroupFromTour(Group Group)
        {
            await _TourRepository.DeleteGroupFromTour(Group);
            return await _TourRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> AddChatToTour(Chat Chat)
        {
            await _TourRepository.AddChatToTour(Chat);
            return await _TourRepository.SaveChangesAsync();
        }
    }
}