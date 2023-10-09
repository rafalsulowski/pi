using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Json;
using TripPlanner.Models;
using TripPlanner.Models.DTO.QuestionnaireDTOs;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.UserDTOs;

namespace TripPlanner.Services
{
    public class TourService : IService
    {
        private readonly HttpClient m_HttpClient;
        private readonly Configuration m_Configuration; 
        //private readonly ILogger<Worker> _logger;

        public TourService(HttpClient _httpClient, Configuration configuration)
        {
            m_HttpClient = _httpClient;
            m_Configuration = configuration;
        }

        public async Task<TourDTO> CreateTour(TourDTO tour)
        {
            try
            {
                string json = JsonConvert.SerializeObject(tour);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = m_HttpClient.PostAsync($"{m_Configuration.WebApiUrl}/Tour/Create", httpContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var resp = await response.Content.ReadFromJsonAsync<TourDTO>();
                    return resp;
                }
            }
            catch (Exception e) 
            {
                //dorobic loggera
            }

            return null;
        }


        public async Task<List<string>> GetTourParticipantsNames(int tourId)
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

            return new List<string>{ "Adam", "Michał", "Alicja", "Kuba", "Rafał", "Maris" };
        }



        public async Task<List<TourDTO>> GetUsersTours(int userId)
        {
            try
            {
                HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/Tour/GetUserTours/{userId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var tours = await response.Content.ReadFromJsonAsync<List<TourDTO>>();
                    return tours;
                }
            }
            catch (Exception e) { }

            return null;
        }



        //public async Task<TourDTO> GetNearestTour(int userId)
        //{
        //    try
        //    {
        //        HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/Tour/GetNearestTour/{userId}").Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var Tour = await response.Content.ReadFromJsonAsync<TourDTO>();
        //            return Tour;
        //        }
        //    }
        //    catch (Exception e) { }

        //    return null;
        //}
    }
}
