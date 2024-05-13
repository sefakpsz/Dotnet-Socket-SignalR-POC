using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SignalR_Poc.Constants;
using SignalR_Poc.Extensions;
using SignalR_Poc.Hubs;

namespace SignalR_Poc.Services
{
    public class SocketService(IHubContext<SignalRHub, ISignalRHub> hubContext) : ISocketService
    {
        private readonly IHubContext<SignalRHub, ISignalRHub> _hubContext = hubContext;

        public async Task DataCreated(DataTypes message)
        {
            await _hubContext.Clients.All.DataCreated(message.EnumToString());
        }

        public async Task DataCreated<T>(T data) where T : class
        {
            var jsonData = JsonConvert.SerializeObject(data);

            await _hubContext.Clients.All.DataCreated(jsonData);
        }
    }
}