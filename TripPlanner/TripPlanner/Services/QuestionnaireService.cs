using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using TripPlanner.Models;
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.UserDTOs;

namespace TripPlanner.Services
{
    public class QuestionnaireService : IService
    {
        private readonly HttpClient m_HttpClient;
        private readonly Configuration m_Configuration;

        public QuestionnaireService(IHttpClientFactory httpClient, Configuration configuration)
        {
            m_HttpClient = httpClient.CreateClient("httpClient");
            m_Configuration = configuration;
        }

        public async Task<CreateQuestionnaireDTO> CreateQuestionnaire(CreateQuestionnaireDTO questionnaire)
        {
            try
            {
                string json = JsonConvert.SerializeObject(questionnaire);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = m_HttpClient.PostAsync($"{m_Configuration.WebApiUrl}/Questionnaire/Create", httpContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var resp = await response.Content.ReadFromJsonAsync<CreateQuestionnaireDTO>();
                    return resp;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e) { }

            return null;
        }

        public async Task<List<ExtendParticipantDTO>> GetAnswerVoters(int tourId)
        {
            //try
            //{
            //    HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/Tour/GetUserTours/{userId}").Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var tours = await response.Content.ReadFromJsonAsync<List<TourDTO>>();
            //        return tours;
            //    }
            //}
            //catch (Exception e) { }

            //return null;

            return new List<ExtendParticipantDTO> ();
        }


        public async Task<bool> VoteForAnswer(int userId, int answerId)
        {
            //try
            //{
            //    HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/Tour/GetUserTours/{userId}").Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var tours = await response.Content.ReadFromJsonAsync<List<TourDTO>>();
            //        return tours;
            //    }
            //}
            //catch (Exception e) { }

            //return null;

            return true;
        }

        

    }
}
