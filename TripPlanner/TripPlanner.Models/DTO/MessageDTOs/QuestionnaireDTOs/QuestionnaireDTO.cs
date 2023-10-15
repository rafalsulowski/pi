﻿using TripPlanner.Models.Models.MessageModels.QuestionnaireModels;

namespace TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs
{
    public class QuestionnaireDTO : MessageDTO
    {
        public int TourId { get; set; }
        public ICollection<QuestionnaireAnswerDTO> Answers { get; set; } = new List<QuestionnaireAnswerDTO>();


        public static implicit operator Questionnaire(QuestionnaireDTO data)
        {
            if (data == null)
                return null;

            return new Questionnaire
            {
                Id = data.Id,
                UserId = data.UserId,
                TourId = data.TourId,
                ChatId = data.ChatId,
                Answers = data.Answers.Select(u => (QuestionnaireAnswer)u).ToList(),
                Content = data.Content,
                Date = data.Date
            };
        }
    }
}