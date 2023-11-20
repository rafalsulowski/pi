using TripPlanner.Models.Models;
using TripPlanner.Models.Models.BillModels;
using TripPlanner.Models.DTO.BillDTOs;
using TripPlanner.Services.TourService;
using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models.Models.UserModels;
using TripPlanner.Models.Models.TourModels;

namespace TripPlanner.Services.BillService
{
    public class BillService : IBillService
    {
        private readonly ITransferRepository _TransferRepository;
        private readonly IBillRepository _BillRepository;
        private readonly IUserRepository _UserRepository;
        private readonly ITourService _TourService;
        private readonly IBillContributorRepository _BillContributorRepository;
        public BillService(ITransferRepository TransferRepository, IBillRepository BillRepository, 
            IBillContributorRepository billContributorRepository,
            IUserRepository userRepository, ITourService tourService)
        {
            _TransferRepository = TransferRepository;
            _BillRepository = BillRepository;
            _BillContributorRepository = billContributorRepository;
            _UserRepository = userRepository;
            _TourService = tourService;
        }

        public async Task<RepositoryResponse<Bill>> GetBillAsync(Expression<Func<Bill, bool>> filter, string? includeProperties = null)
        {
            var response = await _BillRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Bill>>> GetBillsAsync(Expression<Func<Bill, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _BillRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<Transfer>> GetTransferAsync(Expression<Func<Transfer, bool>> filter, string? includeProperties = null)
        {
            var response = await _TransferRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Transfer>>> GetTransfersAsync(Expression<Func<Transfer, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _TransferRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<SharePresentationDTO>>> GetSharesPresentationAsync(int userId, int tourId)
        {
            List<SharePresentationDTO> list = new List<SharePresentationDTO> ();

            var resp = await _BillRepository.GetAll(u => u.TourId == tourId, "Contributors");
            if(resp.Success && resp.Data != null)
            {
                foreach(var share in resp.Data)
                {
                    SharePresentationDTO sharePresentationDTO = new SharePresentationDTO();
                    sharePresentationDTO.Type = SharePresentationDTO.ShareType.Bill;
                    sharePresentationDTO.Id = share.Id;
                    sharePresentationDTO.CreatedDate = share.CreatedDate;
                    sharePresentationDTO.Name = share.Name;
                    sharePresentationDTO.Description = share.Description;

                    if (userId == share.PayerId)
                    {
                        //uzytkownik pozyczyl wiec jest "na minusie" bo ma teraz mniej pieniędzy
                        decimal equal = 0;
                        var userDue = share.Contributors.First(u => u.UserId == userId);
                        if (userDue != null) //jesli jest składajacym sie to jest "na plusie" bo ktoś za niego założył
                            equal = userDue.Due;
                        sharePresentationDTO.Value = equal - share.Value; //to ile płatnik się składa pomniejszone o wartość rachunku (wyjdzie na minusie co oznacza ze platnik jest na minusie)
                    }
                    else
                    {   //uzytkownik zalega
                        var userDue = share.Contributors.First(u => u.UserId == userId);
                        if (userDue != null) //jesli jest składajacym sie to jest "na plusie" bo ktoś za niego założył
                            sharePresentationDTO.Value = userDue.Due;
                        else //uzytkownik nie bierze udzialu w rachunku
                            sharePresentationDTO.Value = 0;
                    }
                    list.Add(sharePresentationDTO);
                }

            }
            else
                return new RepositoryResponse<List<SharePresentationDTO>> { Data = null, Message = "Nie udało się pobrać rachunków", Success = false };

            var resp2 = await _TransferRepository.GetAll(u => u.TourId == tourId);
            if (resp2.Success && resp2.Data != null)
            {
                foreach (var share in resp2.Data)
                {
                    SharePresentationDTO sharePresentationDTO = new SharePresentationDTO();
                    sharePresentationDTO.Type = SharePresentationDTO.ShareType.Transfer;
                    sharePresentationDTO.Id = share.Id;
                    sharePresentationDTO.CreatedDate = share.CreatedDate;
                    sharePresentationDTO.Description = "";

                    //tworzenie napisu transferu
                    string senderName = await GetUserFullNameOrNickname(tourId, share.SenderId);
                    string receiverName = await GetUserFullNameOrNickname(tourId, share.RecipientId);
                    sharePresentationDTO.Name = $"{senderName} zapłacił(a) {share.Value}zł do {receiverName}";
                    
                    list.Add(sharePresentationDTO);
                }
            }
            else
                return new RepositoryResponse<List<SharePresentationDTO>> { Data = null, Message = "Nie udało się pobrać transakcji", Success = false };

            return new RepositoryResponse<List<SharePresentationDTO>> { Data = list, Message = "", Success = true};
        }

        public async Task<string> GetUserFullNameOrNickname(int tourId, int userId)
        {
            string name = "";
            var resp = await _TourService.GetTourExtendParticipantById(tourId, userId);
            if (resp.Success && resp.Data != null)
            {
                name = string.IsNullOrEmpty(resp.Data.Nickname) ? resp.Data.FullName
                    : resp.Data.Nickname;
            }
            return name;
        }

        public async Task<RepositoryResponse<BillPresentationDTO>> GetBillPresentation(int userId, int billId, int tourId)
        {
            BillPresentationDTO billPresentationDTO = new BillPresentationDTO();

            var resp = await _BillRepository.GetFirstOrDefault(u => u.Id== billId, "Contributors");
            if (resp.Success && resp.Data != null)
            {
                billPresentationDTO.Id = resp.Data.Id;
                billPresentationDTO.CreatedDate = resp.Data.CreatedDate;
                billPresentationDTO.ImageFilePath = resp.Data.ImageFilePath;
                billPresentationDTO.Description = resp.Data.Description;
                billPresentationDTO.BillType = resp.Data.BillType;
                billPresentationDTO.Value = resp.Data.Value;
                billPresentationDTO.Name = resp.Data.Name;
                billPresentationDTO.PayerName = await GetUserFullNameOrNickname(tourId, resp.Data.PayerId);
                if (resp.Data.PayerId == userId)
                    billPresentationDTO.PayerName = "Ty zapłaciłeś(aś)";
                else
                    billPresentationDTO.PayerName = "Zapłacił(a) " + await GetUserFullNameOrNickname(tourId, resp.Data.CreatorId);

                if (resp.Data.CreatorId == userId)
                    billPresentationDTO.CreatorName = "Dodane przez Ciebie";
                else
                    billPresentationDTO.CreatorName = "Utworzył(a) " + await GetUserFullNameOrNickname(tourId, resp.Data.CreatorId);

                if(resp.Data.Contributors == null)
                    return new RepositoryResponse<BillPresentationDTO> { Data = null, Message = "Nie udało się pobrać uczestników rachunku", Success = false };

                foreach (var contributor in resp.Data.Contributors)
                {
                    ExtendBillContributorDTO extendBillContributor = new ExtendBillContributorDTO();
                    extendBillContributor.Due = contributor.Due;
                    if (contributor.UserId == userId)
                        extendBillContributor.Name = "Ty";
                    else
                        extendBillContributor.Name = await GetUserFullNameOrNickname(tourId, contributor.UserId);
                    

                    billPresentationDTO.Contributors.Add(extendBillContributor);
                }

                return new RepositoryResponse<BillPresentationDTO> { Data = billPresentationDTO, Message = "", Success = true};
            }
            else
                return new RepositoryResponse<BillPresentationDTO> { Data = null, Message = "Nie udało się pobrać rachunku", Success = false };
        }

        public async Task<RepositoryResponse<TransferPresentationDTO>> GetTransferPresentation(int userId, int transferId, int tourId)
        {
            TransferPresentationDTO transferPresentationDTO = new TransferPresentationDTO();

            var resp = await _TransferRepository.GetFirstOrDefault(u => u.Id == transferId);
            if (resp.Success && resp.Data != null)
            {
                transferPresentationDTO.Id = resp.Data.Id;
                transferPresentationDTO.CreatedDate = resp.Data.CreatedDate;
                transferPresentationDTO.ImageFilePath = resp.Data.ImageFilePath;
                transferPresentationDTO.Description = resp.Data.Description;
                transferPresentationDTO.Value = resp.Data.Value;

                if (resp.Data.SenderId == userId)
                    transferPresentationDTO.PayerName = "Zapłaciłeś(aś)";
                else
                    transferPresentationDTO.PayerName = await GetUserFullNameOrNickname(tourId, resp.Data.SenderId) + " zapłacił(a)";

                if (resp.Data.RecipientId == userId)
                    transferPresentationDTO.ReceiverName = "Ciebie";
                else
                    transferPresentationDTO.ReceiverName = await GetUserFullNameOrNickname(tourId, resp.Data.CreatorId);

                if (resp.Data.CreatorId == userId)
                    transferPresentationDTO.CreatorName = "Dodane przez Ciebie";
                else
                    transferPresentationDTO.CreatorName = "Utworzył(a) " + await GetUserFullNameOrNickname(tourId, resp.Data.CreatorId);

                return new RepositoryResponse<TransferPresentationDTO> { Data = transferPresentationDTO, Message = "", Success = true };
            }
            else
                return new RepositoryResponse<TransferPresentationDTO> { Data = null, Message = "Nie udało się pobrać transakcji", Success = false };
        }

        public async Task<RepositoryResponse<Balance>> GetBalance(int tourId)
        {
            Balance Balance = new Balance();

            var response = await _TourService.GetParticipantsAsync(u => u.TourId == tourId);
            if(!response.Success || response.Data == null)
                return new RepositoryResponse<Balance> { Data = Balance, Message = response.Message, Success = false };

            List<ParticipantTour> Participants = response.Data;
            foreach (ParticipantTour participant in Participants)
            {

                //0. Incjalizacja akutalnego uczestnika
                UserBalance userBalance = new UserBalance();
                userBalance.UserId = participant.UserId;
                userBalance.Name = await GetUserFullNameOrNickname(tourId, participant.UserId);
                userBalance.Saldo = 0;
                userBalance.BalanceWithOtherUsers = new List<OtherUser>();
                foreach(var tourParticipant in Participants)
                    if(tourParticipant.UserId != participant.UserId)
                    userBalance.BalanceWithOtherUsers.Add(new OtherUser 
                    {
                        UserId = tourParticipant.UserId,
                        Name = await GetUserFullNameOrNickname(tourId, tourParticipant.UserId),
                        Saldo = 0
                    });


                //1. zaplacone rachunki przez aktualnego uczestnika
                var responseBills = await _BillRepository.GetAll(u => u.PayerId == participant.UserId, "Contributors");
                if (!responseBills.Success || responseBills.Data == null)
                    return new RepositoryResponse<Balance> { Data = Balance, Message = responseBills.Message, Success = false };

                List<Bill> PayedBillsOfUser = responseBills.Data;
                foreach (var payedBill in PayedBillsOfUser)
                {
                    Balance.TotalBalance += payedBill.Value;
                    userBalance.Saldo -= payedBill.Value;

                    foreach(var billContributor in payedBill.Contributors)
                    {
                        var acturalBillContributor = userBalance.BalanceWithOtherUsers.FirstOrDefault(u => u.UserId == billContributor.UserId);
                        if (acturalBillContributor == null && billContributor.UserId != participant.UserId)
                            userBalance.BalanceWithOtherUsers.Add(new OtherUser
                            {
                                UserId = billContributor.UserId,
                                Name = await GetUserFullNameOrNickname(tourId, billContributor.UserId),
                                Saldo = billContributor.Due
                            });
                        else if(acturalBillContributor != null)
                            acturalBillContributor.Saldo += billContributor.Due;
                    }
                }


                //2. rachunki w ktorych aktualny uczestnik jest skladajacym sie
                var responseBillContributors = await _BillContributorRepository.GetAll(u => u.UserId == participant.UserId);
                if (!responseBillContributors.Success || responseBillContributors.Data == null)
                    return new RepositoryResponse<Balance> { Data = Balance, Message = responseBillContributors.Message, Success = false };
                
                List<BillContributor> BillContributors = responseBillContributors.Data;
                foreach (var billContributor in BillContributors)
                {
                    if (billContributor.UserId == participant.UserId)
                    {
                        userBalance.Saldo += billContributor.Due;

                        //dodanie do BalanceWithOtherUsers, dlugu/pozyczki do płacącego za rachunek
                        var bill = await _BillRepository.GetFirstOrDefault(u => u.Id == billContributor.BillId);
                        if(bill.Success && bill.Data != null)
                        {
                            var otherUser = userBalance.BalanceWithOtherUsers.FirstOrDefault(u => u.UserId == bill.Data.PayerId);
                            if(otherUser != null)
                                otherUser.Saldo -= billContributor.Due;
                        }
                    }
                }

                //3. transakcje w ktorych aktualny uczestnik jest nadawcą
                var responseTransferSender = await _TransferRepository.GetAll(u => u.SenderId == participant.UserId);
                if (!responseTransferSender.Success || responseTransferSender.Data == null)
                    return new RepositoryResponse<Balance> { Data = Balance, Message = responseTransferSender.Message, Success = false };

                List<Transfer> TransferSenders = responseTransferSender.Data;
                foreach (var transfer in TransferSenders)
                {
                    userBalance.Saldo -= transfer.Value; 
                    var otherUser = userBalance.BalanceWithOtherUsers.FirstOrDefault(u => u.UserId == transfer.RecipientId);
                    if (otherUser != null)
                        otherUser.Saldo += transfer.Value;
                }

                //4. transakcje w ktorych aktualny uczestnik jest odbiorca
                var responseTransferRecipient = await _TransferRepository.GetAll(u => u.RecipientId == participant.UserId);
                if (!responseTransferRecipient.Success || responseTransferRecipient.Data == null)
                    return new RepositoryResponse<Balance> { Data = Balance, Message = responseTransferRecipient.Message, Success = false };

                List<Transfer> TransferRecipients = responseTransferRecipient.Data;
                foreach (var transfer in TransferRecipients)
                {
                    userBalance.Saldo += transfer.Value;
                    var otherUser = userBalance.BalanceWithOtherUsers.FirstOrDefault(u => u.UserId == transfer.SenderId);
                    if (otherUser != null)
                        otherUser.Saldo -= transfer.Value;
                }

                userBalance.BalanceWithOtherUsers.RemoveAll(u => u.Saldo == 0);
                Balance.UserBalances.Add(userBalance);
            }

            return new RepositoryResponse<Balance> { Data = Balance, Message = "", Success = true };
        }

        public async Task<RepositoryResponse<UserBalance>> GetBalanceOfUser(int userId, int tourId)
        {
            UserBalance userBalance = new UserBalance();

            var response = await _TourService.GetParticipantsAsync(u => u.TourId == tourId);
            if (!response.Success || response.Data == null)
                return new RepositoryResponse<UserBalance> { Data = userBalance, Message = response.Message, Success = false };
            List<ParticipantTour> Participants = response.Data;

            //0. Incjalizacja akutalnego uczestnika
            userBalance.UserId = userId;
            userBalance.Name = await GetUserFullNameOrNickname(tourId, userId);
            userBalance.Saldo = 0;
            userBalance.BalanceWithOtherUsers = new List<OtherUser>();
            foreach (var tourParticipant in Participants)
                if (tourParticipant.UserId != userId)
                    userBalance.BalanceWithOtherUsers.Add(new OtherUser
                    {
                        UserId = tourParticipant.UserId,
                        Name = await GetUserFullNameOrNickname(tourId, tourParticipant.UserId),
                        Saldo = 0
                    });


            //1. zaplacone rachunki przez aktualnego uczestnika
            var responseBills = await _BillRepository.GetAll(u => u.PayerId == userId, "Contributors");
            if (!responseBills.Success || responseBills.Data == null)
                return new RepositoryResponse<UserBalance> { Data = userBalance, Message = responseBills.Message, Success = false };

            List<Bill> PayedBillsOfUser = responseBills.Data;
            foreach (var payedBill in PayedBillsOfUser)
            {
                userBalance.Saldo -= payedBill.Value;

                foreach (var billContributor in payedBill.Contributors)
                {
                    var acturalBillContributor = userBalance.BalanceWithOtherUsers.FirstOrDefault(u => u.UserId == billContributor.UserId);
                    if (acturalBillContributor == null && billContributor.UserId != userId)
                        userBalance.BalanceWithOtherUsers.Add(new OtherUser
                        {
                            UserId = billContributor.UserId,
                            Name = await GetUserFullNameOrNickname(tourId, billContributor.UserId),
                            Saldo = billContributor.Due
                        });
                    else if (acturalBillContributor != null)
                        acturalBillContributor.Saldo += billContributor.Due;
                }
            }


            //2. rachunki w ktorych aktualny uczestnik jest skladajacym sie
            var responseBillContributors = await _BillContributorRepository.GetAll(u => u.UserId == userId);
            if (!responseBillContributors.Success || responseBillContributors.Data == null)
                return new RepositoryResponse<UserBalance> { Data = userBalance, Message = responseBillContributors.Message, Success = false };

            List<BillContributor> BillContributors = responseBillContributors.Data;
            foreach (var billContributor in BillContributors)
            {
                if (billContributor.UserId == userId)
                {
                    userBalance.Saldo += billContributor.Due;

                    //dodanie do BalanceWithOtherUsers, dlugu/pozyczki do płacącego za rachunek
                    var bill = await _BillRepository.GetFirstOrDefault(u => u.Id == billContributor.BillId);
                    if (bill.Success && bill.Data != null)
                    {
                        var otherUser = userBalance.BalanceWithOtherUsers.FirstOrDefault(u => u.UserId == bill.Data.PayerId);
                        if (otherUser != null)
                            otherUser.Saldo -= billContributor.Due;
                    }
                }
            }

            //3. transakcje w ktorych aktualny uczestnik jest nadawcą
            var responseTransferSender = await _TransferRepository.GetAll(u => u.SenderId == userId);
            if (!responseTransferSender.Success || responseTransferSender.Data == null)
                return new RepositoryResponse<UserBalance> { Data = userBalance, Message = responseTransferSender.Message, Success = false };

            List<Transfer> TransferSenders = responseTransferSender.Data;
            foreach (var transfer in TransferSenders)
            {
                userBalance.Saldo -= transfer.Value;
                var otherUser = userBalance.BalanceWithOtherUsers.FirstOrDefault(u => u.UserId == transfer.RecipientId);
                if (otherUser != null)
                    otherUser.Saldo += transfer.Value;
            }

            //4. transakcje w ktorych aktualny uczestnik jest odbiorca
            var responseTransferRecipient = await _TransferRepository.GetAll(u => u.RecipientId == userId);
            if (!responseTransferRecipient.Success || responseTransferRecipient.Data == null)
                return new RepositoryResponse<UserBalance> { Data = userBalance, Message = responseTransferRecipient.Message, Success = false };

            List<Transfer> TransferRecipients = responseTransferRecipient.Data;
            foreach (var transfer in TransferRecipients)
            {
                userBalance.Saldo += transfer.Value;
                var otherUser = userBalance.BalanceWithOtherUsers.FirstOrDefault(u => u.UserId == transfer.SenderId);
                if (otherUser != null)
                    otherUser.Saldo -= transfer.Value;
            }

            userBalance.BalanceWithOtherUsers.RemoveAll(u => u.Saldo == 0);
            return new RepositoryResponse<UserBalance> { Data = userBalance, Message = "", Success = true };
        }

        public async Task<RepositoryResponse<bool>> CreateBill(Bill Bill)
        {
            _BillRepository.Add(Bill);
            var response = await _BillRepository.SaveChangesAsync();
            return response;
        }
        
        public async Task<RepositoryResponse<bool>> CreateTransfer(Transfer Transfer)
        {
            _TransferRepository.Add(Transfer);
            var response = await _TransferRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateBill(Bill Bill)
        {
            var response = await _BillRepository.Update(Bill);
            if (response.Success == false)
            {
                return response;
            }
            response = await _BillRepository.SaveChangesAsync();
            return response;
        }
        
        public async Task<RepositoryResponse<bool>> UpdateTransfer(Transfer Bill)
        {
            var response = await _TransferRepository.Update(Bill);
            if (response.Success == false)
            {
                return response;
            }
            response = await _TransferRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteBill(Bill Bill)
        {
            //var resp = await _BillContributorRepository.GetAll(u => u.BillId == Bill.Id);
            //if (resp.Data != null)
            //{
            //    //removing Contributors
            //    List<BillContributor> BillContributors = resp.Data;
            //    foreach (var billContributor in BillContributors)
            //        _BillContributorRepository.Remove(billContributor );
            //}

            _BillRepository.Remove(Bill);
            var response = await _BillRepository.SaveChangesAsync();
            return response;
        }
        
        public async Task<RepositoryResponse<bool>> DeleteTransfer(Transfer Transfer)
        {
            _TransferRepository.Remove(Transfer);
            var response = await _TransferRepository.SaveChangesAsync();
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
