using C2C.Core.Business;
using C2C.Core.Contracts;
using C2C.Core.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C2C.UnitTests
{
    /// <summary>
    /// Unit tests for camera comms
    /// </summary>
    [TestClass]
    public class CameraCommsTests
    {
        Camera _camera;
        IComm _comm;        

        public CameraCommsTests()
        {
            _camera = new Camera
            {
                Name = "Test Camera"                
            };
            _comm = new CameraCommChannel(_camera);            
        }

        #region "Channel Tests"

        [TestMethod]
        public void SetChannelWithNullParameter_ShouldFail()
        {
            var result = _comm.SetChannel(null);
            Assert.AreEqual(result, "Channel is required");
        }

        [TestMethod]
        public void SetChannelWithEmptyChannelName_ShouldFail()
        {
            Channel channel = new Channel
            {
                ChannelName = ""
            };

            var result = _comm.SetChannel(channel);
            Assert.AreEqual(result, "Channel Name is required");
        }

        [TestMethod]
        public void SetChannelWithChannelName_ShouldPass()
        {
            Channel channel = new Channel
            {
                ChannelName = "Test Channel"
            };

            var result = _comm.SetChannel(channel);
            Assert.AreEqual(result, "Comm Channel for device " + _camera.Name + " set to " + channel.ChannelName);
        }

        #endregion

        #region "Port Tests"
        [TestMethod]
        public void SetPortNumberWithZeroValue_ShouldFail()
        {
            var result = _comm.SetPortNumber(0);
            Assert.AreEqual(result, "Port Number is required");
        }

        [TestMethod]
        public void SetPortNumberWithNonZeroValue_ShouldPass()
        {
            int portNumber = 123;

            var result = _comm.SetPortNumber(portNumber);
            Assert.AreEqual(result, "Comm port for device " + _camera.Name + " set to " + portNumber);
        }

        #endregion

        #region "Protocol Tests"
        [TestMethod]
        public void SetProtocolWithEmptyString_ShouldFail()
        {
            var result = _comm.SetProtocol("");
            Assert.AreEqual(result, "Protocol is required");
        }

        [TestMethod]
        public void SetProtocolWithStringValue_ShouldPass()
        {
            var protocol = "Test Protocol";
            var result = _comm.SetProtocol(protocol);
            Assert.AreEqual(result, "Comm Protocol for device " + _camera.Name + " set to " + protocol);
        }

        #endregion

        #region "Comms Tests"

        [TestMethod]
        public void SendCommWithEmptyMessage_ShouldFail()
        {
            var message = "";

            var result = _comm.SendComm(message);
            Assert.AreEqual(result, "Cannot send a blank message");
        }

        [TestMethod]
        public void SendCommWithNullChannel_ShouldFail()
        {
            var message = "Test Message";
            _camera.CommChannel = null;

            var result = _comm.SendComm(message);
            Assert.AreEqual(result, "Cannot send comms unless Channel is set");
        }

        [TestMethod]
        public void SendCommWithEmptyProtocol_ShouldFail()
        {
            var message = "Test Message";
            _camera.CommChannel = new Channel
            {
                ChannelName = "Test Channel"
            };
            _camera.CommProtocol = "";

            var result = _comm.SendComm(message);
            Assert.AreEqual(result, "Cannot send comms unless Protocol is set");
        }

        [TestMethod]
        public void SendCommWithChannelProtocolAndMessage_ShouldPass()
        {
            var message = "Test Message";
            _camera.CommChannel = new Channel
            {
                ChannelName = "Test Channel"
            };
            _camera.CommProtocol = "Test Protocol";

            var result = _comm.SendComm(message);
            Assert.AreEqual(result, "Sending message: " + message
                                    + " to device " + _camera.Name
                                    + " through Channel " + _camera.CommChannel.ChannelName
                                    + "using Port " + _camera.CommPortNumber
                                    + " and " + _camera.CommProtocol + " protocol");
        }

        #endregion

    }
}
