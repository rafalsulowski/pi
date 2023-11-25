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

namespace TripPlanner.WebAPI.Hubs
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

            CreateTextMessageDTO msg = JsonConvert.DeserializeObject<CreateTextMessageDTO>(message);

            if (msg == null)
                throw new HubException($"Nie udało się deserializować wiadomości");

            TextMessage newMessage = msg;
            newMessage.Date = DateTime.Now;

            var response = await _ChatService.AddTextMessage(newMessage);
            if (!response.Success || !response.Data)
                throw new HubException(response.Message);

            string json = JsonConvert.SerializeObject(newMessage.MapToDTO());
            await Clients.Group(newMessage.TourId.ToString()).SendAsync("TextMessageReceived", json);
        }

        public async Task SendNoticeMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new HubException($"Pusta wiadomości");

            CreateNoticeMessageDTO msg = JsonConvert.DeserializeObject<CreateNoticeMessageDTO>(message);

            if (msg == null)
                throw new HubException($"Nie udało się deserializować wiadomości");

            NoticeMessage newMessage = msg;
            newMessage.Date = DateTime.Now;

            var response = await _ChatService.AddNoticeMessage(newMessage);
            if (!response.Success || !response.Data)
                throw new HubException(response.Message);

            string json = JsonConvert.SerializeObject(newMessage.MapToDTO());
            await Clients.Group(newMessage.TourId.ToString()).SendAsync("NoticeMessageReceived", json);
        }

        public async Task SendQuestionnaireMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new HubException($"Pusta wiadomości");

            CreateQuestionnaireDTO createQuestionnaireDTO = JsonConvert.DeserializeObject<CreateQuestionnaireDTO>(message);

            if (createQuestionnaireDTO == null)
                throw new HubException($"Nie udało się deserializować ankiety");

            Questionnaire newQuestionnaire = createQuestionnaireDTO;
            newQuestionnaire.Date = DateTime.Now;

            var response = await _QuestionnaireService.CreateQuestionnaire(newQuestionnaire);
            if (!response.Success || !response.Data)
                throw new HubException(response.Message);

            string json = JsonConvert.SerializeObject(newQuestionnaire.MapToDTO());
            await Clients.Group(newQuestionnaire.TourId.ToString()).SendAsync("QuestionnaireReceived", json);
        }


        public async Task SendQuestionnaireVote(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new HubException($"Pusta wiadomości");

            CreateQuestionnaireVoteDTO questionnaireVoteDTO = JsonConvert.DeserializeObject<CreateQuestionnaireVoteDTO>(message);

            if (questionnaireVoteDTO == null)
                throw new HubException($"Nie udało się deserializować informacji do oddania głosu w ankiecie");

            var response = await _QuestionnaireService.AddVoteToAnswer(questionnaireVoteDTO);
            if (!response.Success || !response.Data)
                throw new HubException(response.Message);

            var response2 = await _QuestionnaireService.GetQuestionnaireAsync(u => u.Id == questionnaireVoteDTO.QuestionnaireId, "Answers.Votes");
            if (!response2.Success || response2.Data == null)
                throw new HubException(response.Message);

            string json = JsonConvert.SerializeObject(response2.Data.MapToDTO());
            await Clients.Group(questionnaireVoteDTO.TourId.ToString()).SendAsync("QuestionnaireVoteReceived", json);
        }

        public async Task SetConnection(string tourId)
        {
            try
            {
                int TourId = int.Parse(tourId);
                var respQ = await _QuestionnaireService.GetQuestionnairesAsync(u => u.TourId == TourId, "Answers.Votes");
                var respT = await _ChatService.GetTextMessagesAsync(u => u.TourId == TourId);
                var respN = await _ChatService.GetNoticeMessagesAsync(u => u.TourId == TourId);

                List<MessageDTO> Messages = new List<MessageDTO>();
                Messages.AddRange(respN.Data.Select(u => u.MapToDTO()).ToList());
                Messages.AddRange(respT.Data.Select(u => u.MapToDTO()).ToList());
                Messages.AddRange(respQ.Data.Select(u => u.MapToDTO()).ToList());
                Messages = Messages.OrderBy(u => u.Date).ToList();

                await Groups.AddToGroupAsync(Context.ConnectionId, tourId);

                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string json = JsonConvert.SerializeObject(Messages, settings);
                await Clients.Caller.SendAsync("SetConnection", json);
            }
            catch (Exception)
            {
                throw new HubException($"Błędny argument: {tourId}");
            }
        }
    }
}
