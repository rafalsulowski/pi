using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.UserDTOs;
using TripPlanner.Models.Models;

namespace TripPlanner.Services
{
    public class UserService
    {
        private readonly HttpClient m_HttpClient;
        private readonly Configuration m_Configuration;

        public UserService(IHttpClientFactory httpClient, Configuration configuration)
        {
            m_HttpClient = httpClient.CreateClient("httpClient");
            m_Configuration = configuration;
        }


        // Zwraca liste znajomych
        public async Task<List<ExtendFriendDTO>> GetFriends(int userId)
        {
            try
            {
                HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/User/{userId}/GetFriends").Result;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ExtendFriendDTO>>();
                }
            }
            catch (Exception) { }
            return null;
        }

        // Zwraca liste wyjazdów do których należy dany użytkownik
        public async Task<List<TourDTO>> GetToursOfUser(int userId)
        {
            try
            {
                HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/User/GetToursOfUser/{userId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<TourDTO>>();
                }
            }
            catch (Exception) { }
            return null;
        }

        // Zwraca liste znajomych z wyjazdu
        public async Task<List<ExtendFriendDTO>> GetFriendsWithInfoAboutTour(int userId, int tourId)
        {
            try
            {
                HttpResponseMessage response = m_HttpClient.GetAsync($"{m_Configuration.WebApiUrl}/User/{userId}/GetFriendsWithInfoAboutTour/{tourId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ExtendFriendDTO>>();
                }
            }
            catch (Exception) { }
            return null;
        }


        // Logowanie
        public async Task<RepositoryResponse<UserDTO>> Login(string emial, string password)
        {
            string errMsg = "";
            try
            {
                LoginDTO loginDto = new LoginDTO
                {
                    Email = emial,
                    PasswordHash = password
                };

                string json = JsonConvert.SerializeObject(loginDto);
                StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = m_HttpClient.PostAsync($"{m_Configuration.WebApiUrl}/User/login", httpContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    RepositoryResponse<UserDTO> resp = await response.Content.ReadFromJsonAsync<RepositoryResponse<UserDTO>>();
                    if (resp.Success)
                        return new RepositoryResponse<UserDTO> { Data = resp.Data, Message = "", Success = true };
                    else
                        errMsg = resp.Message;
                }
                else
                    errMsg = $"Kod błędu: {response.StatusCode}";
            }
            catch (Exception e)
            {
                errMsg = $"Wyjątek: {e.Message}";
            }
            return new RepositoryResponse<UserDTO> { Data = null, Message = errMsg, Success = false };
        }

        //Tworzenie nowego użytkownika
        public async Task<RepositoryResponse<UserDTO>> Register(CreateUserDTO user)
        {
            string errMsg = "";
            try
            {
                string json = JsonConvert.SerializeObject(user);
                StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = m_HttpClient.PostAsync($"{m_Configuration.WebApiUrl}/User", httpContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    RepositoryResponse<UserDTO> resp = await response.Content.ReadFromJsonAsync<RepositoryResponse<UserDTO>>();
                    if (resp.Success)
                        return new RepositoryResponse<UserDTO> { Data = resp.Data, Message = "", Success = true };
                    else
                        errMsg = resp.Message;
                }
                else
                    errMsg = $"Kod błędu: {response.StatusCode}";
            }
            catch (Exception e)
            {
                errMsg = $"Wyjątek: {e.Message}";
            }
            return new RepositoryResponse<UserDTO> { Data = null, Message = errMsg, Success = false };
        }
    }
}
