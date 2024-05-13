using SignalR_Poc.Constants;

namespace SignalR_Poc.Models
{
    public class SocketModel<T>
    {
        public required T Data { get; set; }
        public DataTypes DataType { get; set; }
    }
}