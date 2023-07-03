﻿using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface ITourRepository : IRepository<Tour>
    {
        Task<RepositoryResponse<bool>> Update(Tour post);
        Task<RepositoryResponse<bool>> AddParticipantToTour(ParticipantTour Contribute);
        Task<RepositoryResponse<bool>> DeleteParticipantFromTour(ParticipantTour Contribute);
        Task<RepositoryResponse<bool>> AddOrganizerToTour(OrganizerTour Contribute);
        Task<RepositoryResponse<bool>> DeleteOrganizerFromTour(OrganizerTour Contribute);
        Task<RepositoryResponse<bool>> AddCultureAssistanceToTour(CultureAssistance Contribute);
        Task<RepositoryResponse<bool>> DeleteCultureAssistanceFromTour(CultureAssistance Contribute);
    }
}
