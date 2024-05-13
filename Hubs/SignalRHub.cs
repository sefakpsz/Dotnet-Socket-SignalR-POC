using Microsoft.AspNetCore.SignalR;
using SignalR_Poc.Hubs;

namespace SignalR_Poc
{
    public sealed class SignalRHub(ILogger<SignalRHub> logger) : Hub<ISignalRHub>
    {
        private readonly ILogger<SignalRHub> _logger = logger;

        public override async Task OnConnectedAsync()
        {
            // var httpContext = Context.GetHttpContext();
            // if (httpContext is not null)
            // {
            //     var token = httpContext.Request.Headers.Authorization;
            //     _logger.LogInformation(token.ToString());

            //     // validation of token
            //     // adding user of owner of token to a group
            // }

            await Clients.All.ReceiveMessage($"{Context.ConnectionId} joined the chat");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (exception is not null)
                _logger.LogError("An error occurred with the chat hub --> {message}", exception.Message);

            await Clients.All.ReceiveMessage($"{Context.ConnectionId} left the chat");

            // remove user from group
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.ReceiveMessage($"{Context.ConnectionId}: {message}");
        }

        public async Task JoinChat(string username)
        {
            await Clients.All.ReceiveMessage($"{username} joined the chat");
        }

        public async Task JoinSpecificChatRoom(string username, string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName)
                .ReceiveMessage($"{username} joined the chat");
        }
    }
}