using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface ICultureAssistanceRepository : IRepository<CultureAssistance>
    {
        Task<RepositoryResponse<bool>> Update(CultureAssistance post);
    }
}
