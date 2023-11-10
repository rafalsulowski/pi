using CommunityToolkit.Maui.Views;

namespace TripPlanner.Views.ChatViews;

public partial class AddQuesionnaireAnswerPopups : Popup
{
	private readonly List<string> Answers;

    public AddQuesionnaireAnswerPopups(List<string> answers)
	{
		InitializeComponent();
        Answers = answers;
    }

	async void Submit_Clicked(Object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(m_Answer.Text))
		{
			await Shell.Current.CurrentPage.DisplayAlert("B��d", "Odpowied� nie mo�e by� pusta", "Ok");
			await CloseAsync(null);
		}
		else if (Answers.IndexOf(m_Answer.Text) != -1)
		{
			await Shell.Current.CurrentPage.DisplayAlert("B��d", "Nie mo�na doda� 2 takich samych odpowiedzi!", "Ok");
			await CloseAsync(null); 
		}
        else
			await CloseAsync(m_Answer.Text);
	}
}