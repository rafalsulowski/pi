using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models.Models;
using TripPlanner.Services.ScheduleService;
using TripPlanner.Models.Models.ScheduleModels;

namespace TripPlanner.Services.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleDayRepository _ScheduleDayRepository;
        private readonly IScheduleEventRepository _ScheduleEventRepository;
        private readonly ITourRepository _TourRepository;
        public ScheduleService(IScheduleDayRepository ScheduleRepository, IScheduleEventRepository ScheduleEventRepository, ITourRepository tourRepository)
        {
            _ScheduleDayRepository = ScheduleRepository;
            _ScheduleEventRepository = ScheduleEventRepository;
            _TourRepository = tourRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateScheduleDay(ScheduleDay ScheduleDay)
        {
            _ScheduleDayRepository.Add(ScheduleDay);
            var response = await _ScheduleDayRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteScheduleDay(ScheduleDay ScheduleDay)
        {
            var resp = await GetAllEvents(ScheduleDay.Id);
            if (resp.Data != null)
            {
                //removing Events
                List<ScheduleEvent> Events = resp.Data;
                foreach (var e in Events)
                    _ScheduleEventRepository.Remove(e);
            }

            _ScheduleDayRepository.Remove(ScheduleDay);
            var response = await _ScheduleDayRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<List<ScheduleDay>>> GetWholeSchedule(int tourId)
        {
            var response = await _ScheduleDayRepository.GetAll(p => p.TourId == tourId, "Events");
            return response;
        }

        public async Task<RepositoryResponse<List<ScheduleEvent>>> GetAllEvents(int scheduleDayId)
        {
            var response = await _ScheduleEventRepository.GetAll(u => u.ScheduleDayId == scheduleDayId);
            return response;
        }

        public async Task<RepositoryResponse<bool>> CreateScheduleEvent(ScheduleEvent Event)
        {
            await _ScheduleDayRepository.AddScheduleEvent(Event);
            return await _ScheduleDayRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> UpdateScheduleEvent(ScheduleEvent Event)
        {
            var response = await _ScheduleDayRepository.UpdateScheduleEvent(Event);
            if (response.Success == false)
            {
                return response;
            }
            response = await _ScheduleDayRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteScheduleEvent(ScheduleEvent Event)
        {
            await _ScheduleDayRepository.DeleteScheduleEvent(Event);
            return await _ScheduleDayRepository.SaveChangesAsync();
        }
    }
}
