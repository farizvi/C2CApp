using C2C.Core.Business;
using C2C.Core.Contracts;
using C2C.Core.Domain;
using System;

namespace C2C.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating Camera
            Camera camera = new Camera
            {
                ID = 1,
                Name = "New Camera",
                ManufacturerName = "Acme Corp.",
                MaxZoom = 4,
                Dimensions = new Dimension
                {
                    Height = 25,
                    Width = 15,
                    Length = 20
                },
                CommChannel = new Channel
                {
                    ChannelName = "Channel 01",
                    Description = "Channel Number 01"
                },
                CommPortNumber = 1080,
                CommProtocol = "TCP",
                YearManufactured = 2017
            };

            IComm comm;
            ICameraOperations operations;

            comm = new CameraCommChannel(camera);
            operations = new CameraOperations(comm, camera);

            //Powering ON the camera
            Console.WriteLine("Powering ON " + camera.Name);
            Console.WriteLine(operations.PowerOn());

            //Connecting to server
            Console.WriteLine("Connecting to remote server...");
            Console.WriteLine(operations.Connect());

            //Zooming IN
            Console.WriteLine("Zooming in 2X...");
            Console.WriteLine(operations.ZoomIn(2));

            //Zooming OUT
            Console.WriteLine("Zooming out 1X...");
            Console.WriteLine(operations.ZoomIn(1));

            //Disconnecting
            Console.WriteLine("Disconnecting...");
            Console.WriteLine(operations.Disconnect());

            //Turning OFF the camera
            Console.WriteLine("Turing off " + camera.Name);
            Console.WriteLine(operations.PowerOff());

            Console.ReadLine();
        }
    }
}
