using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models;

namespace TripPlanner.Services.QuestionnaireService
{
    public interface IQuestionnaireService
    {
        Task<RepositoryResponse<List<Questionnaire>>> GetQuestionnairesAsync(Expression<Func<Questionnaire, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Questionnaire>> GetQuestionnaireAsync(Expression<Func<Questionnaire, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateQuestionnaire(Questionnaire Bill);
        Task<RepositoryResponse<bool>> UpdateQuestionnaire(Questionnaire Bill);
        Task<RepositoryResponse<bool>> DeleteQuestionnaire(Questionnaire Bill);
    }
}
