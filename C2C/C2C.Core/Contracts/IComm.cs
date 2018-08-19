using C2C.Core.Domain;

namespace C2C.Core.Contracts
{
    public interface IComm
    {
        string SendComm(string message);
        string SetChannel(Channel channel);
        string SetPortNumber(int portNumber);
        string SetProtocol(string protocol);
    }
}
