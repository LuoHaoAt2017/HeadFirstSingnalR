namespace BrowserServerSingnalR
{
    public interface IMessageHubClient
    {
		Task PushWeatherForecastToUser(List<WeatherForecast> message);
	}
}
