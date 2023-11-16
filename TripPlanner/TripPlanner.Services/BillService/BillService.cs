using TripPlanner.Models.Models;
using TripPlanner.Models.Models.BillModels;
using TripPlanner.Models.DTO.BillDTOs;
using TripPlanner.Services.TourService;
using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;

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
                    sharePresentationDTO.Name = $"{senderName} zapłacił(a) PLN {share.Value} do {receiverName}";
                    
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
                    transferPresentationDTO.PayerName = "Zapłacił(a) " + await GetUserFullNameOrNickname(tourId, resp.Data.CreatorId);

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
            //1. wyplenic liste balance wszystkimi uczestnikami
            //2. pobrac liste rachunkow
            //3. iterowac po rachunkach i dodawac zadluzenie do uczestnikow (uwzgledniac gdy ten co porzyczyl mial tez dodane skladanie sie do calej sumy)
            //4. pobrac liste transakcji
            //5. iterowac po transakcjach i dodawac wyrownanie wartosci dla uczestnikow (uwzgledniac gdy ze zrobienie transakcji ma 2 konce,
            //6. wysylajacemu anuluje dlug a odbierajacemu pomniejsza wielkosc porzyczonej kwoty)


            Balance mainBalance = new Balance();

            //1. Inicjalizacja obiektu mainBalance
            mainBalance.TotalBalance = 0;
            var tourDB = await _TourService.GetTourAsync(u => u.Id == tourId, "Participants"); //TODO sprawdzic czy dziala, chyba bedzie ok
            if (tourDB.Success && tourDB.Data != null)
            {
                foreach(var participant in tourDB.Data.Participants)
                {
                    var userDB = await _UserRepository.GetFirstOrDefault(u => u.Id == participant.UserId);
                    if(userDB.Success && userDB.Data != null)
                    {
                        mainBalance.UserBalances.Add(new UserBalance
                        {
                            UserId = userDB.Data.Id,
                            Name = string.IsNullOrEmpty(participant.Nickname) ? userDB.Data.FullName : participant.Nickname,
                            Saldo = 0,
                            BalanceWithOtherUsers = new List<OtherUser>(),
                            IsExpand = false,
                        });
                    }
                    else
                        return new RepositoryResponse<Balance> { Data = null, Message = $"Nie udało się pobrać danych użytkownika id = {participant.UserId}", Success = false };
                }
            }
            else
                return new RepositoryResponse<Balance> { Data = null, Message = "Nie udało się pobrać rachunków", Success = false };


            //2. Iterowac po rachunkach i dodawac zadluzenie do uczestnikow(uwzgledniac gdy ten co porzyczyl mial tez dodane skladanie sie do calej sumy)
            var BillsDB = await _BillRepository.GetAll(u => u.TourId == tourId, "Contributors");
            if (BillsDB.Success && BillsDB.Data != null)
            {
                foreach (var bill in BillsDB.Data)
                {
                    mainBalance.TotalBalance += bill.Value;

                    // pobranie bilansu dla platnika
                    UserBalance userBalance = mainBalance.UserBalances.FirstOrDefault(u => u.UserId == bill.PayerId);

                    //w razie gdy uczestnik wyjazdu został z niego usunięty ale gdy bierze udział w jakiś rachunkach
                    //lub transakcjach to jest dodawany z UserRepository

                    if(userBalance is null)
                    {
                        var userDB = await _UserRepository.GetFirstOrDefault(u => u.Id == bill.PayerId);

                        mainBalance.UserBalances.Add(new UserBalance
                        {
                            UserId = bill.PayerId,
                            Name = await GetUserFullNameOrNickname(tourId, bill.PayerId),
                            Saldo = 0,
                            BalanceWithOtherUsers = new List<OtherUser>(),
                            IsExpand = false,
                        });

                        userBalance = mainBalance.UserBalances.FirstOrDefault(u => u.UserId == bill.PayerId);
                        
                        if( userBalance is null )
                            return new RepositoryResponse<Balance> { Data = null, Message = $"Problemy z uzupełnieniem usuniętego uczestnika o id = {bill.PayerId}", Success = false };
                    }

                    //modyfikacja Salda, płatnikowi odejmujemy od slada wartość rachunku
                    //ewentualne pomiejszenie wartości składki płatnika nastąpi w następnej petli
                    userBalance.Saldo -= bill.Value;


                    //aktualizacja wartosci dla wszystkich składających się
                    foreach(var contributor in bill.Contributors)
                    {
                        if (contributor.UserId == bill.PayerId) //pomniejszenie stawki platnika jako, że również się składa
                            userBalance.Saldo += contributor.Due;
                        else
                        {
                            OtherUser otherUser = userBalance.BalanceWithOtherUsers.FirstOrDefault(u => u.UserId == contributor.UserId);

                            if (otherUser is null)
                            {
                                userBalance.BalanceWithOtherUsers.Add(new OtherUser
                                {
                                    UserId = contributor.UserId,
                                    Name = await GetUserFullNameOrNickname(tourId, contributor.UserId),
                                    Saldo = contributor.Due,
                                });
                            }
                            else
                                otherUser.Saldo += contributor.Due;
                        }
                    }
                }

            }
            else
                return new RepositoryResponse<Balance> { Data = null, Message = "Nie udało się pobrać rachunków", Success = false };

            var transferDB = await _TransferRepository.GetAll(u => u.TourId == tourId);
            if (transferDB.Success && transferDB.Data != null)
            {
                foreach (var transfer in transferDB.Data)
                {
                    //1. pobranie userBalancow dla sender i recipient
                    //2. modyfikacja salda ogolnego

                    // pobranie bilansu dla wysyłającego
                    UserBalance senderBalance = mainBalance.UserBalances.FirstOrDefault(u => u.UserId == transfer.SenderId);
                    UserBalance reciepientBalance = mainBalance.UserBalances.FirstOrDefault(u => u.UserId == transfer.RecipientId);
                    
                    if(senderBalance is null || reciepientBalance is null)
                        return new RepositoryResponse<Balance> { Data = null, Message = "Odbiorca lub nadawca transferu nie został odnaleziony", Success = false };

                    //modyfikacja salda wysylajacego oraz odbierajacego w liscie balansow pomiedzy uzytkownikami
                    senderBalance.Saldo -= transfer.Value;
                    OtherUser receipientInOtherUsers = senderBalance.BalanceWithOtherUsers.FirstOrDefault(u => u.UserId == transfer.RecipientId);
                    if(receipientInOtherUsers is not null)
                    {
                        receipientInOtherUsers.Saldo += transfer.Value; //dodajemy do salda odbiorcy bo u nas wartosci ujemne znacza zaporzyczenie
                    }

                    reciepientBalance.Saldo += transfer.Value; //jest ok
                    OtherUser senderInOtherUsers = reciepientBalance.BalanceWithOtherUsers.FirstOrDefault(u => u.UserId == transfer.SenderId);
                    if (senderInOtherUsers is not null)
                    {
                        senderInOtherUsers.Saldo -= transfer.Value; //dodajemy do salda odbiorcy bo u nas wartosci ujemne znacza zaporzyczenie
                    }
                }
            }
            else
                return new RepositoryResponse<Balance> { Data = null, Message = "Nie udało się pobrać transkacji", Success = false };

            return new RepositoryResponse<Balance> { Data = mainBalance, Message = "", Success = true };
        }

        public async Task<RepositoryResponse<UserBalance>> GetBalanceOfUser(int userId, int tourId)
        {
            UserBalance userBalance = new UserBalance();
            
            var userDB = await _UserRepository.GetFirstOrDefault(u => u.Id == userId);
            if (userDB.Success && userDB.Data != null)
            {
                userBalance.UserId = userId;
                userBalance.Name = await GetUserFullNameOrNickname(tourId, userId);
                userBalance.Saldo = 0;
                userBalance.BalanceWithOtherUsers = new List<OtherUser>();
            }
            else
                return new RepositoryResponse<UserBalance> { Data = null, Message = $"Nie udało się pobrać danych użytkownika id = {userId}", Success = false };


            //2. Iterowac po rachunkach i dodawac zadluzenie do uczestnikow(uwzgledniac gdy ten co porzyczyl mial tez dodane skladanie sie do calej sumy)
            var BillsDB = await _BillRepository.GetAll(u => u.TourId == tourId, "Contributors");
            if (BillsDB.Success && BillsDB.Data != null)
            {
                foreach (var bill in BillsDB.Data)
                {
                    // pobranie bilansu dla platnika
                    if(userBalance.UserId == bill.PayerId)
                    {   //jezeli użytkownik jest płatnikiem to modyfikujemy jego saldo i zadłużenie innych uczestników dla naszego użytkownika z tego rachunku
                        userBalance.Saldo -= bill.Value;

                        foreach (var contributor in bill.Contributors)
                        {
                            if (contributor.UserId == bill.PayerId) //pomniejszenie stawki platnika jako, że płatnik również się składa
                                userBalance.Saldo += contributor.Due;
                            else
                            {
                                OtherUser otherUser = userBalance.BalanceWithOtherUsers.FirstOrDefault(u => u.UserId == contributor.UserId);

                                if (otherUser is null)
                                {
                                    userBalance.BalanceWithOtherUsers.Add(new OtherUser
                                    {
                                        UserId = contributor.UserId,
                                        Name = await GetUserFullNameOrNickname(tourId, contributor.UserId),
                                        Saldo = contributor.Due,
                                    });
                                }
                                else
                                    otherUser.Saldo += contributor.Due;
                            }
                        } //foreach contributors
                    }
                } //foreach bills
            }
            else
                return new RepositoryResponse<UserBalance> { Data = null, Message = "Nie udało się pobrać rachunków", Success = false };

            var transferDB = await _TransferRepository.GetAll(u => u.TourId == tourId);
            if (transferDB.Success && transferDB.Data != null)
            {
                foreach (var transfer in transferDB.Data)
                {
                    //1. pobranie userBalancow dla sender i recipient
                    //2. modyfikacja salda ogolnego

                    if(userBalance.UserId == transfer.SenderId)
                    {
                        //zwiekszamy wielkosc porzyczonych pieniedzy (np. zmiejsza sie dług gdy jest on dodatni lub zwiększa się gdy zakładamy za kogoś coraz więcej gotowkki)
                        userBalance.Saldo -= transfer.Value;
                        OtherUser receipientInOtherUsers = userBalance.BalanceWithOtherUsers.FirstOrDefault(u => u.UserId == transfer.RecipientId);
                        if (receipientInOtherUsers is not null)
                        {
                            receipientInOtherUsers.Saldo += transfer.Value; //dodajemy do salda odbiorcy bo u nas wartosci ujemne znacza zaporzyczenie
                        }
                    }
                    else if(userBalance.UserId == transfer.RecipientId)
                    {
                        //zmiejszamy wielkosc długu pieniedzy (np. zwiększa sie dług gdy jest on dodatni lub zmniejsza się gdy zakładamy za kogoś jakieś pieniądze)
                        userBalance.Saldo += transfer.Value;
                        OtherUser senderInOtherUsers = userBalance.BalanceWithOtherUsers.FirstOrDefault(u => u.UserId == transfer.SenderId);
                        if (senderInOtherUsers is not null)
                        {
                            senderInOtherUsers.Saldo += transfer.Value; //dodajemy do salda odbiorcy bo u nas wartosci ujemne znacza zaporzyczenie
                        }
                    }
                } //foreach transfers
            }
            else
                return new RepositoryResponse<UserBalance> { Data = null, Message = "Nie udało się pobrać transkacji", Success = false };

            return new RepositoryResponse<UserBalance> { Data = userBalance, Message = "", Success = true };
        }

        public async Task<RepositoryResponse<bool>> CreateBill(Bill Bill)
        {
            _BillRepository.Add(Bill);
            var response = await _BillRepository.SaveChangesAsync();

            ////dodanie billcontributors
            //foreach(var contributors in Bill.Contributors)
            //{
            //    _BillContributorRepository.Add(new BillContributor
            //    {
            //        BillId = Bill.Id,
            //        UserId = contributors.UserId,
            //        Due = contributors.Due,
            //    });
            //}
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
