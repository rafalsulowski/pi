using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;

namespace TripPlanner.Services.BillPictureService
{
    public class BillPictureService : IBillPictureService
    {
        private readonly IBillPictureRepository _BillPictureRepository;
        public BillPictureService(IBillPictureRepository BillPictureRepository)
        {
            _BillPictureRepository = BillPictureRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateBillPicture(BillPicture BillPicture)
        {
            _BillPictureRepository.Add(BillPicture);
            var response = await _BillPictureRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteBillPicture(BillPicture BillPicture)
        {
            _BillPictureRepository.Remove(BillPicture);
            var response = await _BillPictureRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<BillPicture>> GetBillPictureAsync(Expression<Func<BillPicture, bool>> filter, string? includeProperties = null)
        {
            var response = await _BillPictureRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<BillPicture>>> GetBillPicturesAsync(Expression<Func<BillPicture, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _BillPictureRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateBillPicture(BillPicture BillPicture)
        {
            var response = await _BillPictureRepository.Update(BillPicture);
            if(response.Success==false)
            {
                return response;
            }
            response = await _BillPictureRepository.SaveChangesAsync();
            return response;
        }
    }
}
