using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Net.Http.Json;
using TripPlanner.Models;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.UserDTOs;

namespace TripPlanner.Services
{
    public class TourService
    {
        private readonly HttpClient m_HttpClient;
        private readonly Configuration m_Configuration; 
        //private readonly ILogger<Worker> _logger;

        public TourService(HttpClient _httpClient, Configuration configuration)
        {
            m_HttpClient = _httpClient;
            m_Configuration = configuration;
        }

        public async Task<TourDTO> GetNearestTour(int userId)
        {
            try
            {
                HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/Tour/GetNearestTour/{userId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var Tour = await response.Content.ReadFromJsonAsync<TourDTO>();
                    return Tour;
                }
            }
            catch (Exception e) { }

            return null;
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
    }
}
