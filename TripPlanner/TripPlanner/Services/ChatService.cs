using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Services
{
    public class ChatService : IService
    {
        private readonly HttpClient m_HttpClient;
        private readonly Configuration m_Configuration;
        //private readonly ILogger<Worker> _logger;

        public ChatService(HttpClient _httpClient, Configuration configuration)
        {
            m_HttpClient = _httpClient;
            m_Configuration = configuration;
        }



    }
}
