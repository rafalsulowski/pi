using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR;
using System.Collections.ObjectModel;
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;
using TripPlanner.Services;
using TripPlanner.Views.ChatViews;
using Newtonsoft.Json;

namespace TripPlanner.ViewModels
{
    public partial class CreateQuestionnaireViewModel : ObservableObject, IQueryAttributable
    {
        private readonly ChatService m_ChatService;
        private readonly Configuration m_Configuration;
        private HubConnection m_Connection;
        private int TourId;
        
        [ObservableProperty]
        ObservableCollection<string> answers;

        [ObservableProperty]
        string question;
        
        public CreateQuestionnaireViewModel(Configuration configuration, ChatService chatService)
        {
            m_Configuration = configuration;
            m_ChatService = chatService;
            Question = "Pytanie";
            Answers = new ObservableCollection<string> { new string("asd"), new string("asd2"), new string("asd3"), };
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
           TourId = (int)query["passTourId"];
           await Connect();
        }

        async Task Connect()
        {
            try
            {
                m_Connection = new HubConnectionBuilder()
                .WithUrl(m_Configuration.WssUrl)
                .Build();
                await m_Connection.StartAsync();
            }
            catch (HubException ex)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"{ex.Message}", "Ok");
            }
            catch (Exception)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nieznany błąd", "Ok");
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  TourId}
            };
            await Shell.Current.GoToAsync($"Tour/Chat", navigationParameter);
        }

        [RelayCommand]
        async Task AddAnswer()
        {
            var result = await Shell.Current.CurrentPage.ShowPopupAsync(new AddQuesionnaireAnswerPopups(Answers.ToList()));
            if(result is not null)
            {
                string answer = result.ToString().TrimStart().TrimEnd();
                Answers.Add(answer);
            }
        }

        [RelayCommand]
        async Task DeleteAnswer(string answer)
        {
            Answers.Remove(answer);
        }

        [RelayCommand]
        async Task Create()
        {
            if (string.IsNullOrEmpty(Question))
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie zadałeś pytania!", "Ok");
            else if(Answers.Count < 2)
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Ankieta musi posiadać chociaż dwie odpowiedzi!", "Ok");
            else
            {
                CreateQuestionnaireDTO questionnaireDTO = new CreateQuestionnaireDTO();
                questionnaireDTO.Content = Question;
                questionnaireDTO.TourId = TourId;
                questionnaireDTO.UserId = m_Configuration.User.Id;
                
                foreach(var answer in Answers)
                {
                    questionnaireDTO.Answers.Add(new CreateQuestionnaireAnswerDTO
                    {
                        Answer = answer,
                        QuestionnaireId = -1
                    });
                }


                try
                {
                    string json = JsonConvert.SerializeObject(questionnaireDTO);
                    await m_Connection.InvokeCoreAsync("SendQuestionnaireMessage", args: new[] { json });
                    var navigationParameter = new Dictionary<string, object>
                    {
                        { "passTourId",  TourId}
                    };
                    await Shell.Current.GoToAsync($"Tour/Chat", navigationParameter);
                }
                catch (HubException ex)
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"{ex.Message}", "Ok");
                }
                catch (Exception)
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nieznany błąd", "Ok");
                }
            }
        }
    }
}
