using C2C.Core.Contracts;
using C2C.Core.Domain;
using C2C.Core.Enums;

namespace C2C.Core.Business
{
    public class DeviceOperations : IOperations
    {
        private Device _device;
        public DeviceOperations(Device device)
        {
            _device = device;
        }

        public string Connect()
        {
            if (_device.ConnectionStatus == ConnectionStatus.Online)
                return "This device is already ONLINE";

            _device.ConnectionStatus = ConnectionStatus.Online;
            return "Device " + _device.Name + " is ONLINE";
        }

        public string Disconnect()
        {
            if (_device.ConnectionStatus == ConnectionStatus.Offline)
                return "This device is already OFFLINE";

            _device.ConnectionStatus = ConnectionStatus.Offline;
            return "Device " + _device.Name + " turned OFFLINE";
        }

        public string PowerOff()
        {
            if (_device.PowerStatus == PowerStatus.Off)
                return "This device is already turned OFF";

            _device.PowerStatus = PowerStatus.Off;
            return "Device " + _device.Name + " turned OFF";
        }

        public string PowerOn()
        {
            if (_device.PowerStatus == PowerStatus.On)
                return "This device is already turned ON";

            _device.PowerStatus = PowerStatus.On;
            return "Device " + _device.Name + " turned ON";
        }       
    }
}
