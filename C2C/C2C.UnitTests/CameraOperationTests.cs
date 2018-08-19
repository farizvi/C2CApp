using Microsoft.VisualStudio.TestTools.UnitTesting;
using C2C.Core.Domain;
using C2C.Core.Contracts;
using C2C.Core.Business;

namespace C2C.UnitTests
{
    /// <summary>
    /// Unit tests for zoom operations
    /// </summary>
    [TestClass]
    public class CameraOperationTests
    {
        Camera _camera;
        IComm _comm;
        ICameraOperations _operations;

        public CameraOperationTests()
        {
            _camera = new Camera
            {
                Name = "Test Camera",
                MaxZoom = 4
            };
            _comm = new CameraCommChannel(_camera);
            _operations = new CameraOperations(_comm, _camera);
        }        

        [TestMethod]
        public void ZoomInMoreThanMaxZoom_ShouldFail()
        {
            var result = _operations.ZoomIn(5);
            Assert.AreEqual(result, "Cannot zoom more than " + _camera.MaxZoom);
        }

        [TestMethod]
        public void ZoomOutLessThan1X_ShouldFail()
        {
            var result = _operations.ZoomOut(5);
            Assert.AreEqual(result, "Cannot zoom out less than 1X");
        }

        [TestMethod]
        public void ZoomInLessThanOrEqualToMaxZoom_ShouldPass()
        {
            var factor = 4;
            var result = _operations.ZoomIn(factor);
            Assert.AreEqual(result, "Device " + _camera.Name + " ZOOMED IN by " + factor + "X");
        }

        [TestMethod]
        public void ZoomOutEqualTo1X_ShouldPass()
        {
            _camera.Zoom = 4;
            var factor = 3;
            var result = _operations.ZoomOut(factor);
            Assert.AreEqual(result, "Device " + _camera.Name + " ZOOMED OUT by " + factor + "X");            
        }
    }
}
