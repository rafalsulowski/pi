using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models.Models;

namespace TripPlanner.Services.QuestionnaireService
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IQuestionnaireRepository _QuestionnaireRepository;
        public QuestionnaireService(IQuestionnaireRepository QuestionnaireRepository)
        {
            _QuestionnaireRepository = QuestionnaireRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateQuestionnaire(Questionnaire Questionnaire)
        {
            _QuestionnaireRepository.Add(Questionnaire);
            var response = await _QuestionnaireRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteQuestionnaire(Questionnaire Questionnaire)
        {
            _QuestionnaireRepository.Remove(Questionnaire);
            var response = await _QuestionnaireRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Questionnaire>> GetQuestionnaireAsync(Expression<Func<Questionnaire, bool>> filter, string? includeProperties = null)
        {
            var response = await _QuestionnaireRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Questionnaire>>> GetQuestionnairesAsync(Expression<Func<Questionnaire, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _QuestionnaireRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateQuestionnaire(Questionnaire Questionnaire)
        {
            var response = await _QuestionnaireRepository.Update(Questionnaire);
            if(response.Success==false)
            {
                return response;
            }
            response = await _QuestionnaireRepository.SaveChangesAsync();
            return response;
        }
    }
}
