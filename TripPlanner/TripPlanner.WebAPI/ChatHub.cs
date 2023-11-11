using Microsoft.AspNetCore.SignalR;
using TripPlanner.Models.DTO.MessageDTOs;
using Newtonsoft.Json;
using TripPlanner.Models.Models.MessageModels;
using TripPlanner.Services.TourService;
using TripPlanner.Services.UserService;
using TripPlanner.Services.ChatService;
using TripPlanner.Services.QuestionnaireService;
using TripPlanner.Models.Models.MessageModels.QuestionnaireModels;
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;

namespace TripPlanner.WebSocketServer
{
    public class ChatHub : Hub
    {
        private readonly IChatService _ChatService;
        private readonly IUserService _UserService;
        private readonly ITourService _TourService;
        private readonly IQuestionnaireService _QuestionnaireService;
        public ChatHub(ITourService tourService, IUserService userService, IChatService chatService, IQuestionnaireService questionnaireService) 
        {
            _ChatService = chatService;
            _UserService = userService;
            _TourService = tourService;
            _QuestionnaireService = questionnaireService;
        }

        public Task JoinGroup(string groupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public Task LeaveGroup(string groupName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }



        public async Task SendTextMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new HubException($"Pusta wiadomości");

            TextMessageDTO msg = JsonConvert.DeserializeObject<TextMessageDTO>(message);

            if(msg == null)
                throw new HubException($"Nie udało się deserializować wiadomości");

            var resp = await _TourService.GetTourAsync(u => u.Id == msg.TourId);
            if (resp.Data == null)
                throw new HubException($"Nie istnieje wyjazd o id {msg.TourId}");
            var resp2 = await _UserService.GetUserAsync(u => u.Id == msg.UserId);
            if (resp2.Data == null)
                throw new HubException($"Nie istnieje użytkownik o id {msg.UserId}");

            TextMessage newMessage = msg.MapFromDTO();
            newMessage.Date = DateTime.Now;
            var response = await _ChatService.AddTextMessage(newMessage);
            if (response.Success == false)
                throw new HubException($"Nie udało się wysłać wiadomości, błędna odpowiedź z bazy danych");

            string json = JsonConvert.SerializeObject(msg);
            await Clients.Group(msg.TourId.ToString()).SendAsync("MessageReceived", json);
        }


        public async Task SetConnection(string tourId)
        {
            try
            {
                int TourId = Int32.Parse(tourId);
                var resp = await _TourService.GetTourAsync(u => u.Id == TourId, "Messages");
                if (resp.Data == null)
                    throw new HubException($"Nie istnieje wyjazd o id {TourId}");

                await Groups.AddToGroupAsync(Context.ConnectionId, tourId);

                ICollection<MessageDTO> messages = new List<MessageDTO>();
                foreach (var message in resp.Data.Messages)
                {
                    if (message is TextMessage)
                    {
                        messages.Add(new TextMessageDTO
                        {
                            Content = message.Content,
                            UserId = message.UserId,
                            Date = message.Date,
                            Id = message.Id,
                            TourId = message.TourId
                        });
                    }
                    else if (message is NoticeMessage)
                    {
                        messages.Add(new NoticeMessageDTO
                        {
                            Content = message.Content,
                            UserId = message.UserId,
                            Date = message.Date,
                            Id = message.Id,
                            TourId = message.TourId
                        });
                    }
                    else if (message is Questionnaire)
                    {
                        messages.Add(new QuestionnaireDTO
                        {
                            Content = message.Content,
                            UserId = message.UserId,
                            Date = message.Date,
                            Id = message.Id,
                            TourId = message.TourId
                        });
                    }
                }

                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string json = JsonConvert.SerializeObject(messages, settings);
                await Clients.Caller.SendAsync("SetConnection", json);
            }
            catch (Exception)
            {
                throw new HubException($"Błędny argument: {tourId}");
            }
        }
    }
}
