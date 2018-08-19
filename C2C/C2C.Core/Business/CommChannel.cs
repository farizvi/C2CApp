using C2C.Core.Contracts;
using C2C.Core.Domain;

namespace C2C.Core.Business
{
    public class CommChannel : IComm
    {
        private Device _device;
        public CommChannel(Device device)
        {
            _device = device;
        }

        public string SendComm(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return "Cannot send a blank message";

            if (_device.CommChannel == null)
                return "Cannot send comms unless Channel is set";

            if (string.IsNullOrWhiteSpace(_device.CommProtocol))
                return "Cannot send comms unless Protocol is set";

            return "Sending message: " + message 
                    + " to device " + _device.Name 
                    + " through Channel " + _device.CommChannel.ChannelName 
                    + "using Port " + _device.CommPortNumber 
                    + " and " + _device.CommProtocol + " protocol";
        }

        public string SetChannel(Channel channel)
        {
            if (channel == null)
                return "Channel is required";

            if (string.IsNullOrWhiteSpace(channel.ChannelName))
                return "Channel Name is required";

            _device.CommChannel = channel;
            return "Comm Channel for device " + _device.Name + " set to " + channel.ChannelName;
        }

        public string SetPortNumber(int portNumber)
        {
            if (portNumber == 0)
                return "Port Number is required";

            _device.CommPortNumber = portNumber;
            return "Comm port for device " + _device.Name + " set to " + portNumber;
        }

        public string SetProtocol(string protocol)
        {
            if (string.IsNullOrWhiteSpace(protocol))
                return "Protocol is required";

            _device.CommProtocol = protocol;
            return "Comm Protocol for device " + _device.Name + " set to " + protocol;
        }
    }
}
