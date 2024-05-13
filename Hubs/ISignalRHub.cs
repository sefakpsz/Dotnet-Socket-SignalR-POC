namespace SignalR_Poc.Hubs
{
    public interface ISignalRHub
    {
        Task ReceiveMessage(string message);
        Task DataCreated(string message);
    }
}