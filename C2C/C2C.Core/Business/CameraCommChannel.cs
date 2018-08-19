using C2C.Core.Contracts;
using C2C.Core.Domain;

namespace C2C.Core.Business
{
    public class CameraCommChannel : CommChannel, ICameraCommChannel
    {
        public CameraCommChannel(Device device) :base(device)
        {

        }
    }
}
