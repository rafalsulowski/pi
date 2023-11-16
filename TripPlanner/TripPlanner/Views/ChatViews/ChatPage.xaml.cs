using TripPlanner.ViewModels;
using TripPlanner.ViewModels.Chat;

namespace TripPlanner.Views.ChatViews;

public partial class ChatPage : ContentPage, IHasCollectionView
{
    public ChatPage(ChatViewModel chatViewModel)
    {
        InitializeComponent();
        BindingContext = chatViewModel;
    }

    CollectionView IHasCollectionView.CollectionView => MessagesList;

    protected override void OnBindingContextChanged()
    {
        if (this.BindingContext is IHasCollectionViewModel hasCollectionViewModel)
        {
            hasCollectionViewModel.View = this;
        }
        base.OnBindingContextChanged();
    }
}