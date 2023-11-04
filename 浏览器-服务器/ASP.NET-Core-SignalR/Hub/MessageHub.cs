﻿using Microsoft.AspNetCore.SignalR;

namespace BrowserServerSingnalR.Hub
{
	public class MessageHub: Hub<IMessageHubClient>
	{
		public async Task SendOffersToUser(List<string> message)
		{
			await Clients.All.SendOffersToUser(message);
		}
	}
}
