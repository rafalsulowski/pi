using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.ObjectModel;
using TripPlanner.Models.DTO.MessageDTOs;
using TripPlanner.ViewModels;

namespace TripPlanner.Views.ChatViews;

public partial class ChatPage : ContentPage
{
    private readonly Configuration m_Configuration;
    private readonly HubConnection _connection;
    private ObservableCollection<MessageDTO> m_Messages = new ObservableCollection<MessageDTO>();
    public ChatPage(ChatViewModel chatViewModel, Configuration configuration)
    {
        InitializeComponent();
        BindingContext = chatViewModel;

        m_Configuration = configuration;
        m_Messages.Add(new TextMessageDTO { Content = "test1", Date = DateTime.Now, });
        m_Messages.Add(new TextMessageDTO { Content = "test2", Date = DateTime.Now, });
        //m_Messages.Add(new TextMessageDTO { Content = "test3", Date = DateTime.Now, });
        //m_Messages.Add(new TextMessageDTO { Content = "test3", Date = DateTime.Now, });
        //m_Messages.Add(new TextMessageDTO { Content = "test3", Date = DateTime.Now, });
        //m_Messages.Add(new TextMessageDTO { Content = "test3", Date = DateTime.Now, });
        //m_chatControl.ItemsSource = m_Messages;


        _connection = new HubConnectionBuilder()
            .WithUrl(m_Configuration.WssUrl)
            .Build();

        _connection.On<string>("MessageReceived", (message) =>
        {
            m_Messages.Add(
                new TextMessageDTO
                {
                    Content = $"{Environment.NewLine}{message}"
                });
        });
        m_chatControl.ItemsSource = m_Messages;

        Task.Run(() =>
        {
            Dispatcher.Dispatch(async () =>
            await _connection.StartAsync());
        });
    }

    private async void OnSendClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(m_Message.Text))
            return;

        await _connection.InvokeCoreAsync("SendMessage", args: new[] { m_Message.Text });
        m_Message.Text = String.Empty;
    }
}