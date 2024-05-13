using SignalR_Poc.Constants;
using SignalR_Poc.Models;

namespace SignalR_Poc.Services
{
    public interface ISocketService
    {
        Task DataCreated(DataTypes message);
        Task DataCreated<T>(SocketModel<T> data);
    }
}