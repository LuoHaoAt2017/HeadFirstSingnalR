using Microsoft.AspNetCore.SignalR;

namespace BrowserServerSingnalR.Hub
{
	public class MessageHub: Hub<IMessageHubClient>
	{
		public async Task SendWeatherForecastToUser(List<WeatherForecast> message)
		{
			await Clients.All.PushWeatherForecastToUser(message);
		}
	}
}
