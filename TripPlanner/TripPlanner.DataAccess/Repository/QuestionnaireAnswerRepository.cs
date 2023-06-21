using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models;

namespace TripPlanner.DataAccess.Repository
{
    public class QuestionnaireAnswerRepository : Repository<QuestionnaireAnswer>, IQuestionnaireAnswerRepository
    {
        private ApplicationDbContext _context;
        public QuestionnaireAnswerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(QuestionnaireAnswer post)
        {
            var postDB = await GetFirstOrDefault(u => u.Id == post.Id);
            if (postDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "QuestionnaireAnswer with this Id was not found."
                };
            }
            _context.QuestionnaireAnswers.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
