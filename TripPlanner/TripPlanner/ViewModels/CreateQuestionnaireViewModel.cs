using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;
using TripPlanner.Services;
using TripPlanner.Views.ChatViews;

namespace TripPlanner.ViewModels
{
    public partial class CreateQuestionnaireViewModel : ObservableObject, IQueryAttributable
    {
        private readonly ChatService m_ChatService;
        private readonly Configuration m_Configuration;
        private int TourId;
        
        [ObservableProperty]
        ObservableCollection<string> answers;

        [ObservableProperty]
        string question;
        
        public CreateQuestionnaireViewModel(Configuration configuration, ChatService chatService)
        {
            m_Configuration = configuration;
            m_ChatService = chatService;
            Answers = new ObservableCollection<string>();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
           TourId = (int)query["passTourId"];
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
                Answers.Add((string)result);
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

                var result = await m_ChatService.CreateQuestionnaire(questionnaireDTO);
                if(result.Success)
                {
                    var navigationParameter = new Dictionary<string, object>
                    {
                        { "passTourId",  TourId}
                    };
                    await Shell.Current.GoToAsync($"Tour/Chat", navigationParameter);

                }
                else
                    await Shell.Current.CurrentPage.DisplayAlert("Błąd", result.Message, "Ok");
            }
        }
    }
}
