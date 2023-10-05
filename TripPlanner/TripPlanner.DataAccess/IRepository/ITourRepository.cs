using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface ITourRepository : IRepository<Tour>
    {
        //Task<RepositoryResponse<List<Tour>>> GetUserToursAsync(int userId);
        Task<RepositoryResponse<bool>> Update(Tour post);
        Task<RepositoryResponse<bool>> AddParticipantToTour(ParticipantTour Contribute);
        Task<RepositoryResponse<bool>> DeleteParticipantFromTour(ParticipantTour Contribute);
        Task<RepositoryResponse<bool>> AddOrganizerToTour(OrganizerTour Contribute);
        Task<RepositoryResponse<bool>> DeleteOrganizerFromTour(OrganizerTour Contribute);
        Task<RepositoryResponse<bool>> AddCultureAssistanceToTour(CultureAssistance Contribute);
        Task<RepositoryResponse<bool>> DeleteCultureAssistanceFromTour(CultureAssistance Contribute);
        Task<RepositoryResponse<bool>> AddGroupToTour(Group Group);
        Task<RepositoryResponse<bool>> DeleteGroupFromTour(Group Group);
        Task<RepositoryResponse<bool>> AddChatToTour(Chat Chat);
    }
}
