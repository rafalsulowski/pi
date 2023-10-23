namespace TripPlanner.WebSocketServer
{
    public interface IChatClient
    {
        Task SendMessage(string user, string message);
    }
}
