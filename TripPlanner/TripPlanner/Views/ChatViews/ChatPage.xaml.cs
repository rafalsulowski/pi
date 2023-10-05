using CommunityToolkit.Maui.Views;
using TripPlanner.ViewModels;

namespace TripPlanner.Views.ChatViews;

public partial class ChatPage : ContentPage
{
    public ChatPage(ChatViewModel chatViewModel)
    {
        InitializeComponent();
        BindingContext = chatViewModel;
    }
}