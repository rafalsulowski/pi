using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TripPlanner.Controls.QuestionnaireControls;
using TripPlanner.Models.DTO.QuestionnaireDTOs;
using TripPlanner.Models.Models.Message;
using TripPlanner.Services;
using TripPlanner.Views.ChatViews;

namespace TripPlanner.ViewModels
{
    public partial class QuestionnaireViewModel : ObservableObject
    {
        private readonly Configuration m_Configuration;
        private readonly QuestionnaireService m_QuestionnaireService;

        [ObservableProperty]
        QuestionnaireDTO questionnaire;

        public QuestionnaireViewModel(Configuration configuration, QuestionnaireService questionnaireService, QuestionnaireDTO questionnaire)
        {
            m_Configuration = configuration;
            m_QuestionnaireService = questionnaireService;
            Questionnaire = questionnaire;
        }


        [RelayCommand]
        async Task Vote(QuestionnaireAnswerDTO answer)
        {
            var res = m_QuestionnaireService.VoteForAnswer(m_Configuration.User.Id, answer.Id);

            if(res.Result == false)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się oddać głosu!", "Ok");
            }
        }

        [RelayCommand]
        async Task ShowVoter(AnswerGDTO answer)
        {
            var res = m_QuestionnaireService.GetAnswerVoters(answer.Id);

            if (res.Result != null)
            {
                await Shell.Current.CurrentPage.ShowPopupAsync(new PeopleChatListPopups($"Zagłosowali na \"{answer.Answer}\"", res.Result));
            }
            else
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się pobrać listy osób czatu!", "Ok");
        }
    }
}
