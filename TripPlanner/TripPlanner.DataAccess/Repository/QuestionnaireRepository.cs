using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models;
using TripPlanner.Models.Models.Message.Questionnaire;

namespace TripPlanner.DataAccess.Repository
{
    public class QuestionnaireRepository : Repository<Questionnaire>, IQuestionnaireRepository
    {
        private ApplicationDbContext _context;
        public QuestionnaireRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(Questionnaire post)
        {
            var postDB = await GetFirstOrDefault(u => u.Id == post.Id);
            if (postDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Questionnaire with this Id was not found."
                };
            }
            _context.Questionnaires.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> AddAnswerToQuestionnaire(QuestionnaireAnswer Answer)
        {
            var AnswerDB = _context.QuestionnaireAnswers.FirstOrDefault(u => u.QuestionnaireId == Answer.QuestionnaireId && u.Id == Answer.Id);
            if (AnswerDB == null)
            {
                _context.QuestionnaireAnswers.Add(Answer);
            }
            else
            {
                _context.QuestionnaireAnswers.Attach(Answer);
                _context.Entry(Answer).State = EntityState.Modified;
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> UpdateAnswer(QuestionnaireAnswer Answer)
        {
            var AnswerDB = _context.QuestionnaireAnswers.FirstOrDefault(u => u.QuestionnaireId == Answer.QuestionnaireId);
            if (AnswerDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Nie istnieje taki członek budzetu"
                };
            }
            _context.Entry(AnswerDB).State = EntityState.Detached;
            _context.QuestionnaireAnswers.Attach(Answer);
            _context.Entry(Answer).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> DeleteAnswerFromQuestionnaire(QuestionnaireAnswer Answer)
        {
            var res = _context.QuestionnaireAnswers.FirstOrDefault(u => u.QuestionnaireId == Answer.QuestionnaireId);
            if (res != null)
            {
                _context.QuestionnaireAnswers.Remove(res);
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> AddVoteToAnswer(QuestionnaireVote Vote)
        {
            var VoteDB = _context.QuestionnaireVotes.AsNoTracking().FirstOrDefault(u => u.UserId == Vote.UserId && u.QuestionnaireAnswerId == Vote.QuestionnaireAnswerId);
            if (VoteDB == null)
            {
                _context.QuestionnaireVotes.Add(Vote);
            }
            else
            {
                _context.QuestionnaireVotes.Attach(Vote);
                _context.Entry(Vote).State = EntityState.Modified;
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> DeleteVoteFromAnswer(QuestionnaireVote Vote)
        {
            var res = _context.QuestionnaireVotes.FirstOrDefault(u => u.UserId == Vote.UserId && u.QuestionnaireAnswerId == Vote.QuestionnaireAnswerId);
            if (res != null)
            {
                _context.QuestionnaireVotes.Remove(res);
            }
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
