﻿using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;

namespace TripPlanner.DataAccess.Repository
{
    public class TourRepository : Repository<Tour>, ITourRepository
    {
        private ApplicationDbContext _context;
        public TourRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<RepositoryResponse<bool>> Update(Tour post)
        {
            var postDB = await GetFirstOrDefault(u => u.Id == post.Id);
            if (postDB.Data == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"Nie istnije wycieczka o id = {post.Id}."
                };
            }
            _context.Tours.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> AddParticipantToTour(ParticipantTour Participant)
        {
            var ParticipantDB = _context.ParticipantTours.FirstOrDefault(u => u.TourId == Participant.TourId && u.UserId == Participant.UserId);
            if (ParticipantDB == null)
            {
                _context.ParticipantTours.Add(Participant);
            }
            else
            {
                _context.ParticipantTours.Attach(Participant);
                _context.Entry(Participant).State = EntityState.Modified;
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> DeleteParticipantFromTour(ParticipantTour Participant)
        {
            var res = _context.ParticipantTours.FirstOrDefault(u => u.UserId == Participant.UserId && u.TourId == Participant.TourId);
            if (res != null)
            {
                _context.ParticipantTours.Remove(res);
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> AddOrganizerToTour(OrganizerTour Organizer)
        {
            var OrganizerDB = _context.OrganizerTours.FirstOrDefault(u => u.TourId == Organizer.TourId && u.UserId == Organizer.UserId);
            if (OrganizerDB == null)
            {
                _context.OrganizerTours.Add(Organizer);
            }
            else
            {
                _context.OrganizerTours.Attach(Organizer);
                _context.Entry(Organizer).State = EntityState.Modified;
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> DeleteOrganizerFromTour(OrganizerTour Organizer)
        {
            var res = _context.OrganizerTours.FirstOrDefault(u => u.UserId == Organizer.UserId && u.TourId == Organizer.TourId);
            if (res != null)
            {
                _context.OrganizerTours.Remove(res);
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> AddCultureAssistanceToTour(CultureAssistance CultureAssistance)
        {
            var CultureAssistanceDB = _context.CultureAssistances.FirstOrDefault(u => u.TourId == CultureAssistance.TourId && u.CultureId == CultureAssistance.CultureId);
            if (CultureAssistanceDB == null)
            {
                _context.CultureAssistances.Add(CultureAssistance);
            }
            else
            {
                _context.CultureAssistances.Attach(CultureAssistance);
                _context.Entry(CultureAssistance).State = EntityState.Modified;
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> DeleteCultureAssistanceFromTour(CultureAssistance CultureAssistance)
        {
            var res = _context.CultureAssistances.FirstOrDefault(u => u.CultureId == CultureAssistance.CultureId && u.TourId == CultureAssistance.TourId);
            if (res != null)
            {
                _context.CultureAssistances.Remove(res);
            }
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
