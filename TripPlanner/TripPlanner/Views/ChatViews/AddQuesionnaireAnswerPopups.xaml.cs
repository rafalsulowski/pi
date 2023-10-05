using CommunityToolkit.Maui.Views;

namespace TripPlanner.Views.ChatViews;

public partial class AddQuesionnaireAnswerPopups : Popup
{
	public AddQuesionnaireAnswerPopups()
	{
		InitializeComponent();
	}

	async void Submit_Clicked(Object sender, EventArgs e)
	{
        await CloseAsync(m_Answer.Text);
	}
}