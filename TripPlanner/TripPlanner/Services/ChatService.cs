using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.MessageDTOs;
using TripPlanner.Models.Models.MessageModels;

namespace TripPlanner.Services
{
    public class ChatService : IService
    {
        private readonly HttpClient m_HttpClient;
        private readonly Configuration m_Configuration;
        //private HubConnection m_HubConnection;
        //public bool IsConnected => m_HubConnection?.State == HubConnectionState.Connected;

        public ChatService(IHttpClientFactory httpClient, Configuration configuration)
        {
            m_HttpClient = httpClient.CreateClient("httpClient");
            m_Configuration = configuration;
        }

        public async Task<bool> Connect()
        {
            //m_HubConnection = new HubConnectionBuilder()
            //    .WithUrl("wss://localhost:7035/chat")
            //    .WithAutomaticReconnect()
            //    .Build();

            //m_HubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            //{
            //    var formattedMessage = $"cos tam";
            //    //Messages.Add(new TextMessageDTO { Content = $"{user} {message}" });
            //});

            //await m_HubConnection.StartAsync();
            return true;
        }

        public async Task<int> SendMessage(string message)
        {

            return 1;
        }


    }
}
