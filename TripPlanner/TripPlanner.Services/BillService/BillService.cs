using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models.Models.RouteModels;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.BillModels;
using TripPlanner.DataAccess.Repository;

namespace TripPlanner.Services.BillService
{
    public class BillService : IBillService
    {
        private readonly ITransferRepository _TransferRepository;
        private readonly IBillRepository _BillRepository;
        private readonly IBillContributorRepository _BillContributorRepository;
        public BillService(ITransferRepository TransferRepository, IBillRepository BillRepository, IBillContributorRepository billContributorRepository)
        {
            _TransferRepository = TransferRepository;
            _BillRepository = BillRepository;
            _BillContributorRepository = billContributorRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateTransfer(Transfer Transfer)
        {
            _TransferRepository.Add(Transfer);
            var response = await _TransferRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteTransfer(Transfer Transfer)
        {
            _TransferRepository.Remove(Transfer);
            var response = await _TransferRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> CreateBill(Bill Bill)
        {
            _BillRepository.Add(Bill);
            var response = await _BillRepository.SaveChangesAsync();

            //dodanie billcontributors
            foreach(var contributors in Bill.Contributors)
            {
                _BillContributorRepository.Add(new BillContributor
                {
                    BillId = Bill.Id,
                    UserId = contributors.UserId,
                    Due = contributors.Due,
                });
            }
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteBill(Bill Bill)
        {
            var resp = await _BillContributorRepository.GetAll(u => u.BillId == Bill.Id);
            if (resp.Data != null)
            {
                //removing Contributors
                List<BillContributor> BillContributors = resp.Data;
                foreach (var billContributor in BillContributors)
                    _BillContributorRepository.Remove(billContributor );
            }

            _BillRepository.Remove(Bill);
            var response = await _BillRepository.SaveChangesAsync();
            return response;
        }



        public async Task<RepositoryResponse<bool>> DeleteBillContributors(BillContributor Bill)
        {
            _BillContributorRepository.Remove(Bill);
            var response = await _BillContributorRepository.SaveChangesAsync();
            return response;
        }

    }
}
