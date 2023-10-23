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


        public async Task<ObservableCollection<UserDTO>> GetFriends(int userId)
        {
            await Task.Delay(1000);
            return new ObservableCollection<UserDTO>
            {
                new UserDTO
                {
                    FullName = "Maria Gut",
                    Email = "gut22@gmial.com",
                    City = "Lublin",
                    DateOfBirth = new DateTime(2002,2,22),
                    FullAddress = "Skowronkowa 108C, 20-819",
                    Id = 1
                },
                new UserDTO
                {
                    FullName = "Krystyna Gut",
                    Email = "gutkrystyna22@gmial.com",
                    City = "Lublin",
                    DateOfBirth = new DateTime(2002,2,22),
                    FullAddress = "Skowronkowa 108C, 20-819",
                    Id = 1
                },
                new UserDTO
                {
                    FullName = "Zuzia Popiołek",
                    Email = "bibix@gmial.com",
                    City = "Lublin",
                    DateOfBirth = new DateTime(2001,6,22),
                    FullAddress = "Skowronkowa 108C, 20-819",
                    Id = 1
                },
                new UserDTO
                {
                    FullName = "Kamil Smołecki",
                    Email = "kamilsmlo@gmial.com",
                    City = "Kraśnik",
                    DateOfBirth = new DateTime(2000,12,22),
                    FullAddress = "Poddwrokowa 123, 12-619",
                    Id = 1
                },

            };
        }
    }
}
