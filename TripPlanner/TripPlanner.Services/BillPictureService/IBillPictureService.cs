using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models;

namespace TripPlanner.Services.BillPictureService
{
    public interface IBillPictureService
    {
        Task<RepositoryResponse<List<BillPicture>>> GetBillPicturesAsync(Expression<Func<BillPicture, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<BillPicture>> GetBillPictureAsync(Expression<Func<BillPicture, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateBillPicture(BillPicture BillPicture);
        Task<RepositoryResponse<bool>> UpdateBillPicture(BillPicture BillPicture);
        Task<RepositoryResponse<bool>> DeleteBillPicture(BillPicture BillPicture);
    }
}
