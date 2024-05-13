using SignalR_Poc.Constants;

namespace SignalR_Poc.Hubs
{
    public interface ISignalRHub
    {
        Task ReceivedMessage(string message);
        Task DataCreated(string message);
    }
}