using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models;

namespace TripPlanner.Services.OrganizeTourService
{
    public interface IOrganizeTourService
    {
        Task<RepositoryResponse<List<OrganizeTour>>> GetOrganizeToursAsync(Expression<Func<OrganizeTour, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<OrganizeTour>> GetOrganizeTourAsync(Expression<Func<OrganizeTour, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateOrganizeTour(OrganizeTour Bill);
        Task<RepositoryResponse<bool>> UpdateOrganizeTour(OrganizeTour Bill);
        Task<RepositoryResponse<bool>> DeleteOrganizeTour(OrganizeTour Bill);
    }
}
