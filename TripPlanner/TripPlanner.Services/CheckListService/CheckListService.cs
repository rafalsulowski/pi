﻿using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;

namespace TripPlanner.Services.CheckListService
{
    public class CheckListService : ICheckListService
    {
        private readonly ICheckListRepository _CheckListRepository;
        private readonly ICheckListFieldRepository _CheckListFieldRepository;
        public CheckListService(ICheckListRepository CheckListRepository, ICheckListFieldRepository checkListFieldRepository)
        {
            _CheckListRepository = CheckListRepository;
            _CheckListFieldRepository = checkListFieldRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateCheckList(CheckList CheckList)
        {
            _CheckListRepository.Add(CheckList);
            var response = await _CheckListRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteCheckList(CheckList CheckList)
        {
            var resp = await _CheckListRepository.GetFirstOrDefault(u => u.Id == CheckList.Id, "Fields");
            if (resp.Data == null)
                return new RepositoryResponse<bool> { Data = true, Message = "Budzet zostal usuniety", Success = true };

            //removing Fields
            CheckList CheckListDB = resp.Data;
            foreach (var Field in CheckListDB.Fields)
                _CheckListFieldRepository.Remove(Field);

            _CheckListRepository.Remove(CheckListDB);
            var response = await _CheckListRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<CheckList>> GetCheckListAsync(Expression<Func<CheckList, bool>> filter, string? includeProperties = null)
        {
            var response = await _CheckListRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<CheckList>>> GetCheckListsAsync(Expression<Func<CheckList, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _CheckListRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<CheckListField>> GetCheckListFieldAsync(Expression<Func<CheckListField, bool>> filter, string? includeProperties = null)
        {
            var response = await _CheckListFieldRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<CheckListField>>> GetCheckListFieldsAsync(Expression<Func<CheckListField, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _CheckListFieldRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateCheckList(CheckList CheckList)
        {
            var response = await _CheckListRepository.Update(CheckList);
            if (response.Success == false)
            {
                return response;
            }
            response = await _CheckListRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> AddFieldToCheckList(CheckListField Contribute)
        {
            await _CheckListRepository.AddFieldToCheckList(Contribute);
            return await _CheckListRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> UpdateCheckListField(CheckListField Contribute)
        {
            var response = await _CheckListRepository.UpdateCheckListField(Contribute);
            if (response.Success == false)
            {
                return response;
            }
            response = await _CheckListRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteFieldFromCheckList(CheckListField Contribute)
        {
            await _CheckListRepository.DeleteFieldFromCheckList(Contribute);
            return await _CheckListRepository.SaveChangesAsync();
        }
    }
}
