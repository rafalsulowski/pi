using CommunityToolkit.Maui.Core.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using TripPlanner.Models;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.UserDTOs;
using TripPlanner.Models.Models;

namespace TripPlanner.Services
{
    public class TourService : IService
    {
        private readonly HttpClient m_HttpClient;
        private readonly Configuration m_Configuration;

        public TourService(HttpClient _httpClient, Configuration configuration)
        {
            m_HttpClient = _httpClient;
            m_Configuration = configuration;
        }

        public async Task<TourDTO> GetTourById(int tourId)
        {
            try
            {
                HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/Tour/{tourId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    TourDTO tour = await response.Content.ReadFromJsonAsync<TourDTO>();
                    return tour;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<TourDTO> GetTourWithMessages(int tourId)
        {
            try
            {
                HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/Tour/{tourId}/GetWithMessages").Result;
                if (response.IsSuccessStatusCode)
                {
                    TourDTO tour = await response.Content.ReadFromJsonAsync<TourDTO>();
                    return tour;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<RepositoryResponse<int>> CreateTour(CreateTourDTO tour)
        {
            try
            {
                string json = JsonConvert.SerializeObject(tour);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = m_HttpClient.PostAsync($"{m_Configuration.WebApiUrl}/Tour", httpContent).Result;
                if(response.IsSuccessStatusCode)
                {
                    RepositoryResponse<int> resp = await response.Content.ReadFromJsonAsync<RepositoryResponse<int>>();
                    if (resp.Success)
                    {
                        return new RepositoryResponse<int> { Data = resp.Data, Message = "", Success = true };
                    }
                    else
                        return new RepositoryResponse<int> { Data = -1, Message = resp.Message, Success = false };
                }
                else
                    return new RepositoryResponse<int> { Data = -1, Message = "Błąd serwera podczas tworzenia nowej wycieczki", Success = false };

            }
            catch (Exception e)
            {
                return new RepositoryResponse<int> { Data = -1, Message = $"Wyjątek podczas tworzenia wycieczki. Wiadomość od serwera = {e.Message}", Success = false };
            }
        }

        public async Task<RepositoryResponse<bool>> AddParticipant(int tourId, int userId)
        {
            return new RepositoryResponse<bool>
            {
                Success = true,
                Message = "",
                Data = true
            };
        }

        public async Task<List<ExtendParticipantDTO>> GetTourExtendParticipant(int tourId)
        {
            try
            {
                HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/Tour/{tourId}/GetExtendParticipants").Result;
                if (response.IsSuccessStatusCode)
                {
                    var tour = await response.Content.ReadFromJsonAsync<RepositoryResponse<List<ExtendParticipantDTO>>>();

                    if (tour.Success)
                    {
                        return tour.Data?.ToList();
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<string>> GetTourParticipantsNames(int tourId)
        {
            try
            {
                HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/Tour/{tourId}/GetParticipantsNames").Result;
                if (response.IsSuccessStatusCode)
                {
                    List<string> tour = await response.Content.ReadFromJsonAsync<List<string>>();
                    return tour;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
