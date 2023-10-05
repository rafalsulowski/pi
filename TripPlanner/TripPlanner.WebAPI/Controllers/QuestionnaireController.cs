using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models;
using TripPlanner.Services.QuestionnaireService;
using TripPlanner.Services.UserService;
using TripPlanner.Services.TourService;
using TripPlanner.Models.DTO.QuestionnaireDTOs;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = ProjectConfiguration.HideContorller)]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireService _QuestionnaireService;
        private readonly IUserService _UserService;
        private readonly ITourService _TourService;

        public QuestionnaireController(IQuestionnaireService QuestionnaireService, IUserService userService, ITourService tourService)
        {
            _QuestionnaireService = QuestionnaireService;
            _UserService = userService;
            _TourService = tourService;
        }

        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<QuestionnaireDTO>>>> Get()
        {
            var response = await _QuestionnaireService.GetQuestionnairesAsync();
            List<QuestionnaireDTO> res = response.Data.Select(u => (QuestionnaireDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("GetWithAnswer/{id}")]
        public async Task<ActionResult<RepositoryResponse<QuestionnaireDTO>>> GetWithAnswer(int id)
        {
            var response = await _QuestionnaireService.GetQuestionnaireAsync(u => u.Id == id, "Answers");
            QuestionnaireDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("GetWithAnswerAndVote/{id}")]
        public async Task<ActionResult<RepositoryResponse<QuestionnaireDTO>>> GetWithAnswerAndVote(int id)
        {
            var response = await _QuestionnaireService.GetQuestionnaireAsync(u => u.Id == id, "Answers.Votes");
            QuestionnaireDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<QuestionnaireDTO>>> GetById(int id)
        {
            var response = await _QuestionnaireService.GetQuestionnaireAsync(u => u.Id == id);
            QuestionnaireDTO res = response.Data;
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<RepositoryResponse<QuestionnaireDTO>>> Create([FromBody] CreateQuestionnaireDTO Questionnaire)
        {
            var resp = await _TourService.GetTourAsync(u => u.Id == Questionnaire.TourId, "Questionnaires");
            if (resp.Data == null)
            {
                return new RepositoryResponse<QuestionnaireDTO> { Data = null, Success = false, Message = $"Nie istnieje wycieczka o id = {Questionnaire.TourId}" };
            }
            var resp2 = await _UserService.GetUserAsync(u => u.Id == Questionnaire.UserId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<QuestionnaireDTO> { Data = null, Success = false, Message = $"Nie istnieje użytkownik o id = {Questionnaire.UserId}" };
            }
            var res = resp.Data.Questionnaires.FirstOrDefault(u => u.Question == Questionnaire.Question);
            if (res != null)
            {
                return new RepositoryResponse<QuestionnaireDTO> { Data = null, Success = false, Message = $"Dana wycieczka posiada już ankiete z pytaniem = {Questionnaire.Question}" };
            }

            Questionnaire newQuestionnaire = Questionnaire;
            newQuestionnaire.Date = DateTime.Now;

            var response = await _QuestionnaireService.CreateQuestionnaire(newQuestionnaire);
            if (response == null)
            {
                return new RepositoryResponse<QuestionnaireDTO> { Data = null, Success = false, Message = $"Nie udało się utworzyć ankiety!" };
            }

            //add answers
            foreach (var answer in Questionnaire.Answers)
            {
                answer.QuestionnaireId = newQuestionnaire.Id;
                var res2 = await _QuestionnaireService.AddAnswerToQuestionnaire(answer);

                if (res2.Success == false)
                {
                    return new RepositoryResponse<QuestionnaireDTO> { Data = null, Success = false, Message = $"Nie udało się dodać odpowiedzi {answer.Answer} do ankiety o id = {newQuestionnaire.Id}!" };
                }
            }

            return Ok(newQuestionnaire);
        }

        [HttpGet("{QuestionnaireId}/Answers")]
        public async Task<ActionResult<RepositoryResponse<List<QuestionnaireAnswerDTO>>>> GetAnswers(int QuestionnaireId)
        {
            var response = await _QuestionnaireService.GetAnswersAsync(u => u.QuestionnaireId == QuestionnaireId);
            List<QuestionnaireAnswerDTO> res = response.Data.Select(u => (QuestionnaireAnswerDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{QuestionnaireId}/Answer/{answerId}")]
        public async Task<ActionResult<RepositoryResponse<QuestionnaireAnswerDTO>>> GetAnswerById(int QuestionnaireId, int answerId)
        {
            var response = await _QuestionnaireService.GetAnswerAsync(u => u.QuestionnaireId == QuestionnaireId && u.Id == answerId);
            QuestionnaireAnswerDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{QuestionnaireId}/GetAnswerWithVote/{answerId}")]
        public async Task<ActionResult<RepositoryResponse<QuestionnaireAnswerDTO>>> GetAnswerWithVote(int QuestionnaireId, int answerId)
        {
            var response = await _QuestionnaireService.GetAnswerAsync(u => u.QuestionnaireId == QuestionnaireId && u.Id == answerId, "Votes");
            QuestionnaireAnswerDTO res = response.Data;
            return Ok(res);
        }

        [HttpPost("addAnswer")]
        public async Task<ActionResult<RepositoryResponse<bool>>> AddAnswer([FromBody] CreateQuestionnaireAnswerDTO Questionnaire)
        {
            var resp2 = await _QuestionnaireService.GetQuestionnaireAsync(u => u.Id == Questionnaire.QuestionnaireId, "Answers");
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje Ankieta o id = {Questionnaire.QuestionnaireId}" };
            }
            var res = resp2.Data.Answers.FirstOrDefault(u => u.Answer == Questionnaire.Answer);
            if (res != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Ankieta zawiera już odpowiedz o tresci = {Questionnaire.Answer}" };
            }

            QuestionnaireAnswer elem = Questionnaire;

            var response = await _QuestionnaireService.AddAnswerToQuestionnaire(elem);
            return Ok(response.Data);
        }

        [HttpPut("{QuestionnaireId}/editAnswer/{AnswerId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Edit(int QuestionnaireId, int AnswerId, [FromBody] EditQuestionnaireAnswerDTO Questionnaire)
        {
            var resp3 = await _QuestionnaireService.GetAnswerAsync(u => u.Id == AnswerId);
            if (resp3.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje odpowiedz o id = {AnswerId}" };
            }
            var resp2 = await _QuestionnaireService.GetQuestionnaireAsync(u => u.Id == QuestionnaireId, "Answers");
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje Ankieta o id = {QuestionnaireId}" };
            }
            var res = resp2.Data.Answers.FirstOrDefault(u => u.Answer == Questionnaire.Answer && u.Id != AnswerId);
            if (res != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Ankieta zawiera już odpowiedz o tresci = {Questionnaire.Answer}" };
            }

            QuestionnaireAnswer newQuestionnaireAnswer = Questionnaire;
            newQuestionnaireAnswer.QuestionnaireId = QuestionnaireId;
            newQuestionnaireAnswer.Id = AnswerId;

            var response = await _QuestionnaireService.UpdateAnswer(newQuestionnaireAnswer);
            return Ok(response.Data);
        }

        [HttpDelete("{QuestionnaireId}/deleteAnswer/{answerId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> DeleteAnswer(int QuestionnaireId, int answerId)
        {
            var resp3 = await _QuestionnaireService.GetAnswerAsync(u => u.Id == answerId);
            if (resp3.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje odpowiedz o id = {answerId}" };
            }
            var resp2 = await _QuestionnaireService.GetQuestionnaireAsync(u => u.Id == QuestionnaireId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje Ankieta o id = {QuestionnaireId}" };
            }

            QuestionnaireAnswer elem = resp3.Data;
            elem.Id = answerId;
            elem.QuestionnaireId = QuestionnaireId;
            
            var response = await _QuestionnaireService.DeleteAnswerFromQuestionnaire(elem);
            return Ok(response.Data);
        }

        [HttpPost("addVote")]
        public async Task<ActionResult<RepositoryResponse<bool>>> AddVote([FromBody] QuestionnaireVoteDTO QuestionnaireVote)
        {
            var resp = await _QuestionnaireService.GetAnswerAsync(u => u.Id == QuestionnaireVote.QuestionnaireAnswerId, "Votes");
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje odpowiedz o id = {QuestionnaireVote.QuestionnaireAnswerId}" };
            }
            var resp2 = await _UserService.GetUserAsync(u => u.Id == QuestionnaireVote.UserId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje użytkownik o id = {QuestionnaireVote.UserId}" };
            }
            var res = resp.Data.Votes.FirstOrDefault(u => u.QuestionnaireAnswerId == QuestionnaireVote.QuestionnaireAnswerId && u.UserId == QuestionnaireVote.UserId);    
            if (res != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Uzytkownik oddal juz glos na odpowiedz o id = {QuestionnaireVote.QuestionnaireAnswerId}" };
            }


            QuestionnaireVote vote = QuestionnaireVote;

            var response = await _QuestionnaireService.AddVoteToAnswer(vote);
            return Ok(response.Data);
        }

        [HttpGet("{QuestionnaireAnswerId}/Votes")]
        public async Task<ActionResult<RepositoryResponse<List<QuestionnaireVoteDTO>>>> GetVote(int QuestionnaireAnswerId)
        {
            var response = await _QuestionnaireService.GetVotesAsync(u => u.QuestionnaireAnswerId == QuestionnaireAnswerId);
            List<QuestionnaireVoteDTO> res = response.Data.Select(u => (QuestionnaireVoteDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{QuestionnaireAnswerId}/Vote/{UserId}")]
        public async Task<ActionResult<RepositoryResponse<QuestionnaireVoteDTO>>> GetVoteById(int QuestionnaireAnswerId, int UserId)
        {
            var response = await _QuestionnaireService.GetVoteAsync(u => u.QuestionnaireAnswerId == QuestionnaireAnswerId && u.UserId == UserId);
            QuestionnaireVoteDTO res = response.Data;
            return Ok(res);
        }

        [HttpDelete("{QuestionnaireAnswerId}/deleteVote/{UserId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> DeleteVote(int QuestionnaireAnswerId, int UserId)
        {
            var resp = await _QuestionnaireService.GetVoteAsync(u => u.UserId == UserId && u.QuestionnaireAnswerId == QuestionnaireAnswerId);
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje glos o id = {UserId}" };
            }
            var resp2 = await _QuestionnaireService.GetAnswerAsync(u => u.Id == QuestionnaireAnswerId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje odpowiedz o id = {QuestionnaireAnswerId}" };
            }

            QuestionnaireVote elem = resp.Data;
            elem.UserId = UserId;
            elem.QuestionnaireAnswerId = QuestionnaireAnswerId;

            var response = await _QuestionnaireService.DeleteVoteFromAnswer(elem);
            return Ok(response.Data);
        }

        [HttpPut("{QuestionnaireId}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Edit(int QuestionnaireId, [FromBody] EditQuestionnaireDTO Questionnaire)
        {
            var resp2 = await _QuestionnaireService.GetQuestionnaireAsync(u => u.Id == QuestionnaireId);
            if (resp2.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje ankieta o id = {QuestionnaireId}" };
            }
            var resp = await _TourService.GetTourAsync(u => u.Id == resp2.Data.TourId, "Questionnaires");
            if (resp.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje wycieczka o id = {resp2.Data.TourId}" };
            }
            var res = resp.Data.Questionnaires.FirstOrDefault(u => u.Question == Questionnaire.Question);
            if (res != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Dana wycieczka posiada już ankiete z pytaniem = {Questionnaire.Question}" };
            }

            Questionnaire elem = resp2.Data;
            elem.Id = QuestionnaireId;
            elem.Question = Questionnaire.Question;

            var response = await _QuestionnaireService.UpdateQuestionnaire(elem);
            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _QuestionnaireService.DeleteQuestionnaire(new Questionnaire() { Id = id });
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return NotFound(response.Data);
            }
        }
    }
}
