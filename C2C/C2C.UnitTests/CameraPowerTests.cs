using C2C.Core.Business;
using C2C.Core.Contracts;
using C2C.Core.Domain;
using C2C.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C2C.UnitTests
{
    /// <summary>
    /// Unit Tests for turning camera on and off
    /// </summary>
    [TestClass]
    public class CameraPowerTests
    {
        Camera _camera;
        IComm _comm;
        ICameraOperations _operations;

        public CameraPowerTests()
        {
            _camera = new Camera
            {
                Name = "Test Camera"
            };
            _comm = new CameraCommChannel(_camera);
            _operations = new CameraOperations(_comm, _camera);
        }

        [TestMethod]
        public void TurnOnCameraWithPowerStatusOn_ShouldFail()
        {
            _camera.PowerStatus = PowerStatus.On;
            var result = _operations.PowerOn();
            Assert.AreEqual(result, "This device is already turned ON");
        }

        [TestMethod]
        public void TurnOffCameraWithPowerStatusOff_ShouldFail()
        {
            _camera.PowerStatus = PowerStatus.Off;
            var result = _operations.PowerOff();
            Assert.AreEqual(result, "This device is already turned OFF");
        }

        [TestMethod]
        public void TurnOnCameraWithPowerStatusOff_ShouldPass()
        {
            _camera.PowerStatus = PowerStatus.Off;
            var result = _operations.PowerOn();
            Assert.AreEqual(result, "Device " + _camera.Name + " turned ON");
        }

        [TestMethod]
        public void TurnOffCameraWithPowerStatusOn_ShouldPass()
        {
            _camera.PowerStatus = PowerStatus.On;
            var result = _operations.PowerOff();
            Assert.AreEqual(result, "Device " + _camera.Name + " turned OFF");
        }
    }
}
