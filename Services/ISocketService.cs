using SignalR_Poc.Constants;

namespace SignalR_Poc.Services
{
    public interface ISocketService
    {
        Task DataCreated(DataTypes message);
        Task DataCreated<T>(T data) where T : class;
    }
}