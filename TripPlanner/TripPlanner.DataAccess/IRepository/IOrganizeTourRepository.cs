using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IOrganizeTourRepository : IRepository<OrganizeTour>
    {
        Task<RepositoryResponse<bool>> Update(OrganizeTour post);
    }
}
