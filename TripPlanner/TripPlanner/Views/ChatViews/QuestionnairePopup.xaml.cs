using CommunityToolkit.Maui.Views;
using TripPlanner.ViewModels;

namespace TripPlanner.Views.ChatViews;

public partial class QuestionnairePopup : Popup
{
	public QuestionnairePopup(QuestionnaireViewModel questionnaireViewModel)
	{
		InitializeComponent();
        BindingContext = questionnaireViewModel;
    }
}