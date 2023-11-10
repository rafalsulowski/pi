
using TripPlanner.Models.DTO.UserDTOs;

namespace TripPlanner
{
    public class Configuration
    {
        public readonly int AddChatMessagesWhileReload = 200; //ile wiadomosci dodatkowo wyswietlic na czacie przy odswierzeniu okna

        public readonly string WebApiUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5119/api" : "http://localhost:5119/api";
        public readonly string WssUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5119/chat" : "http://localhost:5119/chat";
        public UserDTO User { get; private set; } = new UserDTO
        {
            Id = 1,
            FullName = "Rafał Sulowski", 
            FullAddress = "Willowa 34a, Lublin 20-819", 
            City = "Lublin", 
            Email = "rmsulowski@gmail.com"
        };

        public string GetLongNameOfDayWeek(DateTime dt)
        {
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "Niedziela";
                case DayOfWeek.Monday:
                    return "Poniedziałek";
                case DayOfWeek.Tuesday:
                    return "Wtorek";
                case DayOfWeek.Wednesday:
                    return "Środa";
                case DayOfWeek.Thursday:
                    return "Czwartek";
                case DayOfWeek.Friday:
                    return "Piątek";
                case DayOfWeek.Saturday:
                    return "Sobota";
                default:
                    return "";
            }
        }

        public string GetShortNameOfDayWeek(DateTime dt)
        {
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "Nd";
                case DayOfWeek.Monday:
                    return "Pn";
                case DayOfWeek.Tuesday:
                    return "Wt";
                case DayOfWeek.Wednesday:
                    return "Śr";
                case DayOfWeek.Thursday:
                    return "Czw";
                case DayOfWeek.Friday:
                    return "Pt";
                case DayOfWeek.Saturday:
                    return "Sb";
                default:
                    return "";
            }
        }

        
    }
}
