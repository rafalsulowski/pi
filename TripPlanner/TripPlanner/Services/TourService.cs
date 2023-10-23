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
                HttpResponseMessage response = m_HttpClient.PostAsync($"{m_Configuration.WebApiUrl}/Tour/Create", httpContent).Result;
                RepositoryResponse<int> resp = await response.Content.ReadFromJsonAsync<RepositoryResponse<int>>();
                if (response.IsSuccessStatusCode)
                {
                    return new RepositoryResponse<int> { Data = resp.Data, Message = "", Success = true };
                }
                else
                    return new RepositoryResponse<int> { Data = -1, Message = resp.Message, Success = false };

            }
            catch (Exception e)
            {
                return new RepositoryResponse<int> { Data = -1, Message = $"Wyjątek podczas tworzenia wycieczki. Message = {e.Message}", Success = false };
            }
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

            return new List<string> { "Adam", "Michał", "Alicja", "Kuba", "Rafał", "Maris" };
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




        public async Task<RepositoryResponse<ObservableCollection<ExtendParticipantDTO>>> GetParticipants(int tourId)
        {
            //try
            //{
            //    HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/Tour/GetUserTours/{userId}").Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var tours = await response.Content.ReadFromJsonAsync<List<ExtendParticipantDTO>>();

            //        return new WebApiResponse<ObservableCollection<ExtendParticipantDTO>> { Data = tours.ToObservableCollection(), Success = true, Message = "" };
            //    }
            //}
            //catch (Exception e) { }

            //return null;

            return new RepositoryResponse<ObservableCollection<ExtendParticipantDTO>>
            {
                Success = true,
                Message = "",
                Data = new ObservableCollection<ExtendParticipantDTO>
                {
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Rafał Sulowski",
                        DateOfBirth = new DateTime(2001, 2, 2),
                        City = "Lublin",
                        Email = "rmsulowksi@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2001, 2, 2).Year,
                        IsOrganizer = true,
                        Nickname = "Prezes",
                        Order = 1
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Maria Gut",
                        DateOfBirth = new DateTime(2002, 2, 22),
                        City = "Lublin",
                        Email = "gut22@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2002, 2, 2).Year,
                        IsOrganizer = false,
                        Nickname = "Maris",
                        Order = 2
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Krystyna Gut",
                        DateOfBirth = new DateTime(2002, 2, 22),
                        City = "Lublin",
                        Email = "gutkry22@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2002, 2, 2).Year,
                        IsOrganizer = false,
                        Nickname = "Kris",
                        Order = 3
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Zuzia Popiolek",
                        DateOfBirth = new DateTime(2001, 4, 2),
                        City = "Lublin",
                        Email = "zuzix@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2001, 2, 2).Year,
                        IsOrganizer = false,
                        Nickname = "Bubix",
                        Order = 4
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Rafał Sulowski",
                        DateOfBirth = new DateTime(2001, 2, 2),
                        City = "Lublin",
                        Email = "rmsulowksi@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2001, 2, 2).Year,
                        IsOrganizer = true,
                        Nickname = "Prezes",
                        Order = 5
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Maria Gut",
                        DateOfBirth = new DateTime(2002, 2, 22),
                        City = "Lublin",
                        Email = "gut22@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2002, 2, 2).Year,
                        IsOrganizer = false,
                        Nickname = "Maris",
                        Order = 6
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Krystyna Gut",
                        DateOfBirth = new DateTime(2002, 2, 22),
                        City = "Lublin",
                        Email = "gutkry22@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2002, 2, 2).Year,
                        IsOrganizer = false,
                        Nickname = "Kris",
                        Order = 7
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Zuzia Popiolek",
                        DateOfBirth = new DateTime(2001, 4, 2),
                        City = "Lublin",
                        Email = "zuzix@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2001, 2, 2).Year,
                        IsOrganizer = false,
                        Nickname = "Bubix",
                        Order = 8
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Rafał Sulowski",
                        DateOfBirth = new DateTime(2001, 2, 2),
                        City = "Lublin",
                        Email = "rmsulowksi@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2001, 2, 2).Year,
                        IsOrganizer = true,
                        Nickname = "Prezes",
                        Order = 9
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Maria Gut",
                        DateOfBirth = new DateTime(2002, 2, 22),
                        City = "Lublin",
                        Email = "gut22@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2002, 2, 2).Year,
                        IsOrganizer = false,
                        Nickname = "Maris",
                        Order = 10
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Krystyna Gut",
                        DateOfBirth = new DateTime(2002, 2, 22),
                        City = "Lublin",
                        Email = "gutkry22@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2002, 2, 2).Year,
                        IsOrganizer = false,
                        Nickname = "Kris",
                        Order = 11
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Zuzia Popiolek",
                        DateOfBirth = new DateTime(2001, 4, 2),
                        City = "Lublin",
                        Email = "zuzix@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2001, 2, 2).Year,
                        IsOrganizer = false,
                        Nickname = "Bubix",
                        Order = 12
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Rafał Sulowski",
                        DateOfBirth = new DateTime(2001, 2, 2),
                        City = "Lublin",
                        Email = "rmsulowksi@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2001, 2, 2).Year,
                        IsOrganizer = true,
                        Nickname = "Prezes",
                        Order = 13
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Maria Gut",
                        DateOfBirth = new DateTime(2002, 2, 22),
                        City = "Lublin",
                        Email = "gut22@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2002, 2, 2).Year,
                        IsOrganizer = false,
                        Nickname = "Maris",
                        Order = 14
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Krystyna Gut",
                        DateOfBirth = new DateTime(2002, 2, 22),
                        City = "Lublin",
                        Email = "gutkry22@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2002, 2, 2).Year,
                        IsOrganizer = false,
                        Nickname = "Kris",
                        Order = 15
                    },
                    new ExtendParticipantDTO
                    {
                        Id = 1,
                        FullName = "Zuzia Popiolek",
                        DateOfBirth = new DateTime(2001, 4, 2),
                        City = "Lublin",
                        Email = "zuzix@gmail.com",
                        Age = DateTime.Now.Year - new DateTime(2001, 2, 2).Year,
                        IsOrganizer = false,
                        Nickname = "Bubix",
                        Order = 16
                    },
                }
            };
        }
    }
}
