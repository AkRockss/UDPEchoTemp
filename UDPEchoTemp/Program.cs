using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPEchoTemp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UDP Echo Temp Server");

            //initialize
            UdpClient socket = new UdpClient();
            socket.Client.Bind(new IPEndPoint(IPAddress.Any, 7015));

            while (true)
            {
                //receieve data
                IPEndPoint from = null;
                byte[] data = socket.Receive(ref from);
                string dataString = Encoding.UTF8.GetString(data);
                Console.WriteLine("Received from Raspberry PI 108 " + dataString + " - " + from.Address);

                dataString = "move " + dataString;
                byte[] toBeSend = Encoding.UTF8.GetBytes(dataString);
                //Echo back data
                socket.Send(toBeSend, toBeSend.Length, from);

            }


        }
    }
}
