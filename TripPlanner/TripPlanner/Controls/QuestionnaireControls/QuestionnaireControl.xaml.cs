using CommunityToolkit.Maui.Views;
using System.Runtime.CompilerServices;
using TripPlanner.Helpers;
using TripPlanner.Models;
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;
using TripPlanner.ViewModels;

namespace TripPlanner.Controls.QuestionnaireControls
{
	public partial class QuestionnaireControl : ContentView
	{
		public static readonly BindableProperty QuestionnaireProperty = BindableProperty.Create(nameof(Questionnaire),
			typeof(QuestionnaireDTO),
			typeof(QuestionnaireControl),
			defaultValue: null,
			propertyChanged: (bindable, oldValue, newValue) =>
				{
					var control = (QuestionnaireControl)bindable;
					control.m_Date.Text = control.Questionnaire.Date.ToString();
					control.m_Content.Text = control.Questionnaire.Content;

					int votesSum = control.Questionnaire.Answers.Sum(item => item.Votes.Count);
					List<AnswerGDTO> list = new List<AnswerGDTO>();
					foreach (var answer in control.Questionnaire.Answers)
					{
						AnswerGDTO ans = new AnswerGDTO();
						ans.Answer = answer.Answer;
						ans.Votes = answer.Votes;
						ans.AccurateIcon = "circle_sec.png";
						ans.PercentageShare = (double)ans.Votes.Count / votesSum;
						list.Add(ans);
					}

					control.m_VoteFor.Text = $"Nie odda³eœ g³osu";
					foreach (AnswerGDTO answer in list)
					{
						foreach (QuestionnaireVoteDTO vote in answer.Votes)
						{
							if (vote.UserId == control.m_Configuration.User.Id)
							{
								control.m_VoteFor.Text = $"Zag³osowa³eœ na \"{answer.Answer}\"";
								answer.AccurateIcon = "circle_ok_sec.png";
							}
						}
					}
					control.m_List.ItemsSource = list;
				});

        public QuestionnaireDTO Questionnaire
		{
			get => GetValue(QuestionnaireProperty) as QuestionnaireDTO;
			set => SetValue(QuestionnaireProperty, value);
		}

		private readonly Configuration m_Configuration;

        public QuestionnaireControl()
		{
			InitializeComponent();
			//do dodania kiedys w przyszlosci servicehelper jako statyczna klasa do omienicia wymaganych konstruktowrow bezparametrowych
			//dodatkowo nie waidomo czy nie bedzie null exception z kodu ponizej !!!
			//m_Configuration = Application.Current.MainPage.Handler.MauiContext.Services.GetService(typeof(Configuration)) as Configuration;
			try
			{
				m_Configuration = ServicesHelper.GetService<Configuration>();
			}
			catch (Exception ex)
			{
				Shell.Current.CurrentPage.DisplayAlert("Awaria", "Z³y system operacyjny! Ankiety dzia³aj¹ tylko na: Windows, Android, Ios, MacCatalyst", "Ok :(");
			}

        }
    }
}