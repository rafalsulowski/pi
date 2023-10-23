using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;
using TripPlanner.Views.ChatViews;

namespace TripPlanner.ViewModels
{
    [QueryProperty("passTour", "Tour")]
    [QueryProperty("passChatId", "ChatId")]
    public partial class CreateQuestionnaireViewModel : ObservableObject, IQueryAttributable
    {
        private readonly Configuration m_Configuration;
        private readonly QuestionnaireService m_QuestionnaireService;

        [ObservableProperty]
        TourDTO tour;

        [ObservableProperty]
        ObservableCollection<string> answers;

        [ObservableProperty]
        string question;
        
        int ChatId;

        public CreateQuestionnaireViewModel(Configuration configuration, QuestionnaireService questionnaireService)
        {
            m_QuestionnaireService = questionnaireService;
            m_Configuration = configuration;
            Answers = new ObservableCollection<string>();
            Answers.Add("tak");
            Answers.Add("nie");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
           Tour = (TourDTO)query["passTour"];
           ChatId = (int)query["passChatId"];
        }


        [RelayCommand]
        async Task GoBack()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTour",  Tour}
            };
            await Shell.Current.GoToAsync($"Tour/Chat", navigationParameter);
        }

        [RelayCommand]
        async Task AddAnswer()
        {
            var result = await Shell.Current.CurrentPage.ShowPopupAsync(new AddQuesionnaireAnswerPopups());

            if (result is string answer)
            {
                if (answer != null && answer != "")
                {
                    if(Answers.IndexOf(answer) != -1)
                        await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie można dodać 2 takich samych odpowiedzi!", "Ok");
                    else
                        Answers.Add(answer);
                }
                else
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Odpowiedź nie może być pusta!", "Ok");
                }
            }
        }

        [RelayCommand]
        async Task DeleteAnswer(string answer)
        {
            if(Answers.Count <= 2)
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Ankieta musi posiadać chociaż dwie odpowiedzi!", "Ok");
            else
                Answers.Remove(answer);

        }

        [RelayCommand]
        async Task Create()
        {
            if(Question == null || Question == "")
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie zadałeś pytania!", "Ok");
            else if(Answers.Count < 2)
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Ankieta musi posiadać chociaż dwie odpowiedzi!", "Ok");
            else
            {
                CreateQuestionnaireDTO questionnaireDTO = new CreateQuestionnaireDTO();
                questionnaireDTO.Content = Question;
                questionnaireDTO.TourId = Tour.Id;
                questionnaireDTO.UserId = m_Configuration.User.Id;
                
                foreach(var answer in Answers)
                {
                    questionnaireDTO.Answers.Add(new CreateQuestionnaireAnswerDTO
                    {
                        Answer = answer,
                        QuestionnaireId = -1
                    });
                }

                var result = await m_QuestionnaireService.CreateQuestionnaire(questionnaireDTO);

                if(result != null)
                {
                    var navigationParameter = new Dictionary<string, object>
                    {
                        { "passTour",  Tour}
                    };
                    await Shell.Current.GoToAsync($"Tour/Chat", navigationParameter);
                }
                else
                    await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się utworzyć ankiety!", "Ok");
            }
        }
    }
}
