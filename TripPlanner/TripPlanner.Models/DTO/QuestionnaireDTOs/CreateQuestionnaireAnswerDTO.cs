﻿namespace TripPlanner.Models.DTO.QuestionnaireDTOs
{
    public class CreateQuestionnaireAnswerDTO
    {
        public int QuestionnaireId { get; set; }
        public string Answer { get; set; } = string.Empty;


        public static implicit operator QuestionnaireAnswer(CreateQuestionnaireAnswerDTO data)
        {
            if (data == null)
                return null;

            return new QuestionnaireAnswer
            {
                QuestionnaireId = data.QuestionnaireId,
                Answer = data.Answer
            };
        }
    }
}
