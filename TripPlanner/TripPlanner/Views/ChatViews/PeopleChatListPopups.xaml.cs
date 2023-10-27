using CommunityToolkit.Maui.Views;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;

namespace TripPlanner.Views.ChatViews;

public partial class PeopleChatListPopups : Popup
{
	public PeopleChatListPopups(string title, List<ExtendParticipantDTO> participants)
	{
		InitializeComponent();
        
        if(participants == null)
            participants = new List<ExtendParticipantDTO>();

        m_Header.Text = title;
        m_List.ItemsSource = participants;
        m_Footer.Text = $"Liczba osób {participants.Count}";
    }
}