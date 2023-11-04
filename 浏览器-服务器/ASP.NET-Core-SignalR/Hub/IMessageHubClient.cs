namespace BrowserServerSingnalR
{
    public interface IMessageHubClient
    {
		Task SendOffersToUser(List<string> message);
	}
}
