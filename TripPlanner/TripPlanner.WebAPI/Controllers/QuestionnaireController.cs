using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models.Models;
using TripPlanner.Models.DTO;
using TripPlanner.Services.QuestionnaireService;
namespace TripPlanner.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireService _QuestionnaireService;

        public QuestionnaireController(IQuestionnaireService QuestionnaireService)
        {
            _QuestionnaireService = QuestionnaireService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<Questionnaire>>>> Get()
        {
            var response = await _QuestionnaireService.GetQuestionnairesAsync();
            return Ok(response.Data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<Questionnaire>>> Get(int id)
        {
            var response = await _QuestionnaireService.GetQuestionnaireAsync(u => u.Id == id);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Data);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<RepositoryResponse<Questionnaire>>> Post([FromBody] QuestionnaireDTO Questionnaire)
        {
            
            Questionnaire newQuestionnaire = new Questionnaire
            {
                
            };

            var response = await _QuestionnaireService.CreateQuestionnaire(newQuestionnaire);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<Questionnaire>>> Put([FromBody] Questionnaire Questionnaire)
        {
            var response = await _QuestionnaireService.UpdateQuestionnaire(Questionnaire);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
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
                return BadRequest(response.Data);
            }
        }
    }
}
