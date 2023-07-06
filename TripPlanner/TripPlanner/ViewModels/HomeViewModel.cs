using CommunityToolkit.Mvvm.ComponentModel;

namespace TripPlanner.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Info))]
        string mTitle;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Info))]
        string mDate;

        public string Info => $"{MTitle} {MDate}";
    }
}
