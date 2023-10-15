using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models;
using TripPlanner.Models.DTO.ChatDTOs;
using TripPlanner.Models.Models.Tour;

namespace TripPlanner.Services.TourService
{
    public interface ITourService
    {
        Task<RepositoryResponse<List<Tour>>> GetToursAsync(Expression<Func<Tour, bool>>? filter = null, string? includeProperties = null);
        //Task<RepositoryResponse<List<Tour>>> GetUserToursAsync(int userId);
        Task<RepositoryResponse<Tour>> GetTourAsync(Expression<Func<Tour, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<List<OrganizerTour>>> GetOrganizersAsync(Expression<Func<OrganizerTour, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<OrganizerTour>> GetOrganizerAsync(Expression<Func<OrganizerTour, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<List<ParticipantTour>>> GetParticipantsAsync(Expression<Func<ParticipantTour, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<ParticipantTour>> GetParticipantAsync(Expression<Func<ParticipantTour, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<Group>> GetGroupAsync(Expression<Func<Group, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<List<Group>>> GetGroupsAsync(Expression<Func<Group, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<List<CultureAssistance>>> GetCulturesAssistanceAsync(Expression<Func<CultureAssistance, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<CultureAssistance>> GetCultureAssistanceAsync(Expression<Func<CultureAssistance, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateTour(Tour Bill);
        Task<RepositoryResponse<bool>> UpdateTour(Tour Bill);
        Task<RepositoryResponse<bool>> DeleteTour(Tour Bill);
        Task<RepositoryResponse<bool>> AddParticipantToTour(ParticipantTour Contribute);
        Task<RepositoryResponse<bool>> DeleteParticipantFromTour(ParticipantTour Contribute);
        Task<RepositoryResponse<bool>> AddOrganizerToTour(OrganizerTour Contribute);
        Task<RepositoryResponse<bool>> DeleteOrganizerFromTour(OrganizerTour Contribute);
        Task<RepositoryResponse<bool>> AddCultureAssistanceToTour(CultureAssistance Contribute);
        Task<RepositoryResponse<bool>> DeleteCultureAssistanceFromTour(CultureAssistance Contribute);
        Task<RepositoryResponse<bool>> AddGroupToTour(Group Group);
        Task<RepositoryResponse<bool>> DeleteGroupFromTour(Group Group);
        Task<RepositoryResponse<bool>> AddChatToTour(Chat chat);


    }
}
