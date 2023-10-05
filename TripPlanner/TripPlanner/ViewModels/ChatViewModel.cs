using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using TripPlanner.Models;
using TripPlanner.Models.DTO.ChatDTOs;
using TripPlanner.Models.DTO.GroupDTOs;
using TripPlanner.Models.DTO.TourDTOs;

namespace TripPlanner.ViewModels
{
    [QueryProperty("passTour", "Tour")]
    public partial class ChatViewModel : ObservableObject, IQueryAttributable
    {
        private readonly Configuration m_Configuration;

        [ObservableProperty]
        TourDTO tour;

        [ObservableProperty]
        ChatDTO chat;

        [ObservableProperty]
        List<MessageDTO> messages;

        [ObservableProperty]
        bool promptLabel;

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        bool isMoreActionClicked;

        public ChatViewModel(Configuration configuration)
        {
            m_Configuration = configuration;
            IsRefreshing = false;
            IsMoreActionClicked = false;
            Messages = new List<MessageDTO>();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Tour = (TourDTO)query["passTour"];

            if (Tour != null)
            {
                //pobrac z api dane czatu czyli wiadomosci i ankiety

                Chat = Tour.Chat;
                Chat.Messages = Chat.Messages.Reverse().ToList();
                if (Chat.Messages.Count >= m_Configuration.AddChatMessagesWhileReload)
                {
                    Messages = Chat.Messages.Take(m_Configuration.AddChatMessagesWhileReload).ToList();
                }
                else
                {
                    Messages = Chat.Messages.ToList();
                }

            }
            else
            {
            }

            PromptLabel = Messages.Count > 0 ? false : true;
        }


        [RelayCommand]
        async Task GoBack()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTour",  Tour}
            };
            await Shell.Current.GoToAsync($"Tour", navigationParameter);
        }

        [RelayCommand]
        async Task GoSettings()
        {
            await Shell.Current.GoToAsync("..");
        }
        
        [RelayCommand]
        async Task LoadMoreMessages()
        {
            IsRefreshing = true;
            for(int i = 0; i < m_Configuration.AddChatMessagesWhileReload; i++)
            {
                if (Messages.Count == Chat.Messages.Count)
                {
                    //pobrac z api wiecej wiadomosci,
                    //dac wtedy activitiindicator zeby sie krecil
                    //potem break
                    break;
                }

                Messages.Add(Chat.Messages.ElementAt(Messages.Count));
            }
            IsRefreshing = false;
        }

        [RelayCommand]
        async Task ShowMoreChatAction()
        {
            IsMoreActionClicked = !IsMoreActionClicked;
        }

        [RelayCommand]
        async Task AddQuestionnaire()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTour",  Tour},
                { "passChatId",  Chat.Id},
            };
            await Shell.Current.GoToAsync($"CreateQuestionnaire", navigationParameter);
        }
    }
}
