using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public async Task<string> AddParticipant(int tourId, int userId)
        {
            return "";
        }




        public async Task<ObservableCollection<ExtendParticipantDTO>> GetParticipants(int tourId)
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

            return new ObservableCollection<ExtendParticipantDTO>
            {
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Rafał Sulowski",
                    DateOfBirth = new DateTime(2001,2,2),
                    City = "Lublin",
                    Email = "rmsulowksi@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2001,2,2).Year,
                    IsOrganizer = true,
                    Nickname = "Prezes",
                    Order = 1
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Maria Gut",
                    DateOfBirth = new DateTime(2002,2,22),
                    City = "Lublin",
                    Email = "gut22@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2002,2,2).Year,
                    IsOrganizer = false,
                    Nickname = "Maris",
                    Order = 2
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Krystyna Gut",
                    DateOfBirth = new DateTime(2002,2,22),
                    City = "Lublin",
                    Email = "gutkry22@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2002,2,2).Year,
                    IsOrganizer = false,
                    Nickname = "Kris",
                    Order = 3
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Zuzia Popiolek",
                    DateOfBirth = new DateTime(2001,4,2),
                    City = "Lublin",
                    Email = "zuzix@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2001,2,2).Year,
                    IsOrganizer = false,
                    Nickname = "Bubix",
                    Order = 4
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Rafał Sulowski",
                    DateOfBirth = new DateTime(2001,2,2),
                    City = "Lublin",
                    Email = "rmsulowksi@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2001,2,2).Year,
                    IsOrganizer = true,
                    Nickname = "Prezes",
                    Order = 1
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Maria Gut",
                    DateOfBirth = new DateTime(2002,2,22),
                    City = "Lublin",
                    Email = "gut22@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2002,2,2).Year,
                    IsOrganizer = false,
                    Nickname = "Maris",
                    Order = 2
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Krystyna Gut",
                    DateOfBirth = new DateTime(2002,2,22),
                    City = "Lublin",
                    Email = "gutkry22@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2002,2,2).Year,
                    IsOrganizer = false,
                    Nickname = "Kris",
                    Order = 3
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Zuzia Popiolek",
                    DateOfBirth = new DateTime(2001,4,2),
                    City = "Lublin",
                    Email = "zuzix@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2001,2,2).Year,
                    IsOrganizer = false,
                    Nickname = "Bubix",
                    Order = 4
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Rafał Sulowski",
                    DateOfBirth = new DateTime(2001,2,2),
                    City = "Lublin",
                    Email = "rmsulowksi@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2001,2,2).Year,
                    IsOrganizer = true,
                    Nickname = "Prezes",
                    Order = 1
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Maria Gut",
                    DateOfBirth = new DateTime(2002,2,22),
                    City = "Lublin",
                    Email = "gut22@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2002,2,2).Year,
                    IsOrganizer = false,
                    Nickname = "Maris",
                    Order = 2
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Krystyna Gut",
                    DateOfBirth = new DateTime(2002,2,22),
                    City = "Lublin",
                    Email = "gutkry22@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2002,2,2).Year,
                    IsOrganizer = false,
                    Nickname = "Kris",
                    Order = 3
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Zuzia Popiolek",
                    DateOfBirth = new DateTime(2001,4,2),
                    City = "Lublin",
                    Email = "zuzix@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2001,2,2).Year,
                    IsOrganizer = false,
                    Nickname = "Bubix",
                    Order = 4
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Rafał Sulowski",
                    DateOfBirth = new DateTime(2001,2,2),
                    City = "Lublin",
                    Email = "rmsulowksi@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2001,2,2).Year,
                    IsOrganizer = true,
                    Nickname = "Prezes",
                    Order = 1
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Maria Gut",
                    DateOfBirth = new DateTime(2002,2,22),
                    City = "Lublin",
                    Email = "gut22@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2002,2,2).Year,
                    IsOrganizer = false,
                    Nickname = "Maris",
                    Order = 2
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Krystyna Gut",
                    DateOfBirth = new DateTime(2002,2,22),
                    City = "Lublin",
                    Email = "gutkry22@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2002,2,2).Year,
                    IsOrganizer = false,
                    Nickname = "Kris",
                    Order = 3
                },
                new ExtendParticipantDTO
                {
                    Id = 1,
                    FullName = "Zuzia Popiolek",
                    DateOfBirth = new DateTime(2001,4,2),
                    City = "Lublin",
                    Email = "zuzix@gmail.com",
                    Age = DateTime.Now.Year - new DateTime(2001,2,2).Year,
                    IsOrganizer = false,
                    Nickname = "Bubix",
                    Order = 4
                },
            };
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
