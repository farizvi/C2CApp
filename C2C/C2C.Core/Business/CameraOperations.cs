using C2C.Core.Contracts;
using C2C.Core.Domain;

namespace C2C.Core.Business
{
    public class CameraOperations : DeviceOperations, ICameraOperations
    {
        private Camera _camera;
        private IComm _comm;

        public CameraOperations(IComm comm, Camera camera) : base(camera)
        {
            _comm = comm;
            _camera = camera;
        }

        public string ZoomIn(int factor)
        {            
            _camera.Zoom += factor;

            if (_camera.Zoom > _camera.MaxZoom)
                return  "Cannot zoom more than " + _camera.MaxZoom;

            return "Device " + _camera.Name + " ZOOMED IN by " + factor + "X";
        }

        public string ZoomOut(int factor)
        {
            _camera.Zoom -= factor;

            if (_camera.Zoom < 1)
                return "Cannot zoom out less than 1X";

            return "Device " + _camera.Name + " ZOOMED OUT by " + factor + "X";
        }
    }
}
