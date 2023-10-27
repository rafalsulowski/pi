using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.UserDTOs;
using TripPlanner.Models.Models.TourModels;
using TripPlanner.Models.Models;

namespace TripPlanner.Services
{
    public class UserService : IService
    {
        private readonly HttpClient m_HttpClient;
        private readonly Configuration m_Configuration;

        public UserService(HttpClient _httpClient, Configuration configuration)
        {
            m_HttpClient = _httpClient;
            m_Configuration = configuration;
        }

        public async Task<CreateUserDTO> Register(CreateUserDTO user)
        {
            //try
            //{
            //    string json = JsonConvert.SerializeObject(tour);
            //    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            //    HttpResponseMessage response = m_HttpClient.PostAsync($"{m_Configuration.WebApiUrl}/Tour/Create", httpContent).Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var resp = await response.Content.ReadFromJsonAsync<TourDTO>();
            //        return resp;
            //    }
            //}
            //catch (Exception e)
            //{
            //    //dorobic loggera
            //}

            return null;
        }

        public async Task<List<TourDTO>> GetToursOfUser(int userId)
        {
            try
            {
                HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/User/GetToursOfUser/{userId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var tours = await response.Content.ReadFromJsonAsync<List<TourDTO>>();
                    return tours;
                }
                else
                    return new List<TourDTO>();
            }
            catch (Exception)
            {
                return new List<TourDTO>();
            }
        }


        public async Task<List<ExtendParticipantDTO>> GetFriends(int userId)
        {
            try
            {
                HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/User/{userId}/GetFriends").Result;
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
    }
}
