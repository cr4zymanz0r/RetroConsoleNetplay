using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO.Ports;

namespace ControllerServer
{
    class Program
    {
        public static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        static void Main(string[] args)
        {
            string ClientMessage = "";
            int port = 8000;
            IPAddress IPaddr = GetLocalIPAddress();

            Console.WriteLine("Enter COM port to use (example, COM3):");
            string COMport = Console.ReadLine();

            TcpListener TCPserver = new TcpListener(IPaddr,port);
            TCPserver.Start();

            Console.WriteLine("The server is running at port " + port + "...");
            Console.WriteLine("The local End point is: " + TCPserver.LocalEndpoint);
            Console.WriteLine("Waiting for a connection.....");


            Socket TCPsocket = TCPserver.AcceptSocket();
            Console.WriteLine("Connection accepted from " + TCPsocket.RemoteEndPoint);

            SerialPort SerialConnection = new SerialPort(COMport, 9600, Parity.None, 8, StopBits.One);
            SerialConnection.Open();

            while (true)
            {
                byte[] byteArray = new byte[2];
                int k = TCPsocket.Receive(byteArray);
                Console.Write("Recieved: ");

                ClientMessage = "";
                for (int i = 0; i < k; i++)
                {
                    //Console.Write(Convert.ToChar(byteArray[i]));
                    ClientMessage += Convert.ToChar(byteArray[i]);
                }

                Console.WriteLine(ClientMessage);
                SerialConnection.Write(ClientMessage);
                SerialConnection.DiscardInBuffer(); //ends up locking the serial connection after a bit without this.
                //SerialConnection.DiscardOutBuffer();
            }

            /*catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }

            Console.WriteLine("The End. Press Enter to exit...");
            Console.ReadLine();*/
        }
    }
}
