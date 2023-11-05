using BrowserServerSingnalR.Hub;
using BrowserServerSingnalR.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BrowserServerSingnalR.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;

		private IHubContext<MessageHub, IMessageHubClient> _messageHub;

		private MyDbContext _context;

		public WeatherForecastController(MyDbContext dbContext, IHubContext<MessageHub, IMessageHubClient> messageHub, ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
			_context = dbContext;
			_messageHub = messageHub;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public IActionResult Get()
		{
			var list = _context.WeatherForecasts.ToList();
			return Ok(list);
		}

		[HttpDelete(Name = "DelWeatherForecast")]
		public IActionResult Delete([FromQuery] long id)
		{
			var elem = _context.WeatherForecasts.Find(id);
			if (elem == null)
			{
				return BadRequest("删除项不存在");
			}
			_context.WeatherForecasts.Remove(elem);
			_context.SaveChanges();
			var list = _context.WeatherForecasts.ToList();
			_messageHub.Clients.All.PushWeatherForecastToUser(list);
			return Ok(true);
		}

		[HttpPut(Name = "AddWeatherForecast")]
		public IActionResult Add([FromBody] WeatherForecast forecast)
		{
			_context.WeatherForecasts.Add(forecast);
			_context.SaveChanges();
			var list = _context.WeatherForecasts.ToList();
			_messageHub.Clients.All.PushWeatherForecastToUser(list);
			return Ok(true);
		}

		[HttpPost(Name = "EditWeatherForecast")]
		public IActionResult Edit([FromBody] WeatherForecast forecast)
		{
			var elem = _context.WeatherForecasts.Find(forecast.Id);
			if (elem == null)
			{
				return BadRequest("更新项不存在");
			}
			elem.Date = forecast.Date;
			elem.TemperatureC = forecast.TemperatureC;
			elem.Summary = forecast.Summary;
			_context.SaveChanges();
			var list = _context.WeatherForecasts.ToList();
			_messageHub.Clients.All.PushWeatherForecastToUser(list);
			return Ok(true);
		}
	}
}