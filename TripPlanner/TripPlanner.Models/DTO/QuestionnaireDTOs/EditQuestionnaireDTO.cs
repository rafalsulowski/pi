namespace TripPlanner.Models.DTO.QuestionnaireDTOs
{
    public class EditQuestionnaireDTO
    {
        public string Question { get; set; } = string.Empty;


        public static implicit operator Questionnaire(EditQuestionnaireDTO data)
        {
            if (data == null)
                return null;

            return new Questionnaire
            {
                Question = data.Question,
            };
        }
    }
}
