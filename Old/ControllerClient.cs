using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using SharpDX.DirectInput;

namespace ControllerTestConsole
{
    class Program
    {
        public static int Dpad = 0;

        static string ButtonTranslate(char button)
        {
            switch(button)
            {
                case '1':
                    return "g";
                case '2':
                    return "h";
                case '3':
                    return "i";
                case '4':
                    return "j";
                case '7':
                    return "e";
                case '8':
                    return "f";
                default:
                    return "NADA";
            }
        }

        static void ButtonState(SharpDX.DirectInput.JoystickUpdate state, char number, Stream TCPstream)
        {
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] byteArray = null; //asen.GetBytes(message);

            string Button = ButtonTranslate(number);

            if (state.Value == 128)
            {
                Console.WriteLine("Button " + number + " pressed!");
                if (Button != "NADA")
                {
                    byteArray = asen.GetBytes(Button + "1");
                    TCPstream.Write(byteArray, 0, byteArray.Length);
                }
            }
            else if (state.Value == 0)
            {
                Console.WriteLine("Button " + number + " un-pressed!");
                if (Button != "NADA")
                {
                    byteArray = asen.GetBytes(Button + "0");
                    TCPstream.Write(byteArray, 0, byteArray.Length);
                }
            }
        }

        static void DpadState(SharpDX.DirectInput.JoystickUpdate state, Stream TCPstream)
        {
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] byteArray = null; //asen.GetBytes(message);

            switch (state.Value)
            {
                case -1: //ALL DPAD INPUTS OFF
                    switch (Dpad)
                    {
                        case 1:
                            Console.WriteLine("DPAD UP un-pressed");
                            byteArray = asen.GetBytes("a0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 2:
                            Console.WriteLine("DPAD UP un-pressed");
                            byteArray = asen.GetBytes("a0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);

                            Console.WriteLine("DPAD RIGHT un-pressed");
                            byteArray = asen.GetBytes("d0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 3:
                            Console.WriteLine("DPAD RIGHT un-pressed");
                            byteArray = asen.GetBytes("d0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 4:
                            Console.WriteLine("DPAD RIGHT un-pressed");
                            byteArray = asen.GetBytes("d0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);

                            Console.WriteLine("DPAD DOWN un-pressed");
                            byteArray = asen.GetBytes("b0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 5:
                            Console.WriteLine("DPAD DOWN un-pressed");
                            byteArray = asen.GetBytes("b0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 6:
                            Console.WriteLine("DPAD DOWN un-pressed");
                            byteArray = asen.GetBytes("b0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);

                            Console.WriteLine("DPAD LEFT un-pressed");
                            byteArray = asen.GetBytes("c0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 7:
                            Console.WriteLine("DPAD LEFT un-pressed");
                            byteArray = asen.GetBytes("c0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 8:
                            Console.WriteLine("DPAD LEFT un-pressed");
                            byteArray = asen.GetBytes("c0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);

                            Console.WriteLine("DPAD UP un-pressed");
                            byteArray = asen.GetBytes("a0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                    }
                    Dpad = 0;
                    break;
                case 0: //UP
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD UP pressed");
                            byteArray = asen.GetBytes("a1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 2:
                            Console.WriteLine("DPAD RIGHT un-pressed");
                            byteArray = asen.GetBytes("d0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 8:
                            Console.WriteLine("DPAD LEFT un-pressed");
                            byteArray = asen.GetBytes("c0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                    }
                    Dpad = 1;
                    break;

                case 4500: //UP RIGHT
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD UP pressed");
                            byteArray = asen.GetBytes("a1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);

                            Console.WriteLine("DPAD RIGHT pressed");
                            byteArray = asen.GetBytes("d1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 1:
                            Console.WriteLine("DPAD RIGHT pressed");
                            byteArray = asen.GetBytes("d1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 3:
                            Console.WriteLine("DPAD UP pressed");
                            byteArray = asen.GetBytes("a1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                    }
                    Dpad = 2;
                    break;

                case 9000: //RIGHT
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD RIGHT pressed");
                            byteArray = asen.GetBytes("d1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 2:
                            Console.WriteLine("DPAD UP un-pressed");
                            byteArray = asen.GetBytes("a0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 4:
                            Console.WriteLine("DPAD DOWN un-pressed");
                            byteArray = asen.GetBytes("b0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                    }
                    Dpad = 3;
                    break;

                case 13500: //DOWN RIGHT
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD DOWN pressed");
                            byteArray = asen.GetBytes("b1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);

                            Console.WriteLine("DPAD RIGHT pressed");
                            byteArray = asen.GetBytes("d1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 3:
                            Console.WriteLine("DPAD DOWN pressed");
                            byteArray = asen.GetBytes("b1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 5:
                            Console.WriteLine("DPAD RIGHT pressed");
                            byteArray = asen.GetBytes("d1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                    }
                    Dpad = 4;
                    break;

                case 18000: //DOWN
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD DOWN pressed");
                            byteArray = asen.GetBytes("b1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 4:
                            Console.WriteLine("DPAD RIGHT un-pressed");
                            byteArray = asen.GetBytes("d0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 6:
                            Console.WriteLine("DPAD LEFT un-pressed");
                            byteArray = asen.GetBytes("c0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                    }
                    Dpad = 5;
                    break;

                case 22500: //DOWN LEFT
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD DOWN pressed");
                            byteArray = asen.GetBytes("b1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);

                            Console.WriteLine("DPAD LEFT pressed");
                            byteArray = asen.GetBytes("c1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 5:
                            Console.WriteLine("DPAD LEFT pressed");
                            byteArray = asen.GetBytes("c1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 7:
                            Console.WriteLine("DPAD DOWN pressed");
                            byteArray = asen.GetBytes("b1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                    }
                    Dpad = 6;
                    break;

                case 27000: //LEFT
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD LEFT pressed");
                            byteArray = asen.GetBytes("c1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 6:
                            Console.WriteLine("DPAD DOWN un-pressed");
                            byteArray = asen.GetBytes("b0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 8:
                            Console.WriteLine("DPAD UP un-pressed");
                            byteArray = asen.GetBytes("a0");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                    }
                    Dpad = 7;
                    break;

                case 31500: //UP LEFT
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD UP pressed");
                            byteArray = asen.GetBytes("a1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);

                            Console.WriteLine("DPAD LEFT pressed");
                            byteArray = asen.GetBytes("c1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 7:
                            Console.WriteLine("DPAD UP pressed");
                            byteArray = asen.GetBytes("a1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                        case 1:
                            Console.WriteLine("DPAD LEFT pressed");
                            byteArray = asen.GetBytes("c1");
                            TCPstream.Write(byteArray, 0, byteArray.Length);
                            break;
                    }
                    Dpad = 8;
                    break;
            }
        }

        static void Main(string[] args)
        {
            TcpClient tcpclnt = new TcpClient();
            Console.WriteLine("Enter the IP address or hostname of the PC you wish to connect to:");
            string IPAddr = Console.ReadLine();

            Console.WriteLine("Enter the port:");
            string portString = Console.ReadLine();
            int port = Int32.Parse(portString);

            Console.WriteLine("Connecting.....");
            try
            {
                tcpclnt.Connect(IPAddr, port);
            }
            catch
            {
                Console.WriteLine("Connection failed. Hit enter to exit");
                Console.ReadLine();
                System.Environment.Exit(1);
            }

            //send test message on TCP connection
            //string message = "Hello thar TCP!";
            Stream TCPstream = tcpclnt.GetStream();
            //ASCIIEncoding asen = new ASCIIEncoding();
            //byte[] byteArray = asen.GetBytes(message);

            //TCPstream.Write(byteArray, 0, byteArray.Length);
            /*byte[] TempByteArray = new byte[100];
            int k = TCPstream.Read(TempByteArray, 0, 100);

            for(int i = 0; i < k; i++)
            {
                Console.Write(Convert.ToChar(TempByteArray[i]));
            }*/


            // Initialize DirectInput
            var directInput = new DirectInput();

            // Find a Joystick Guid
            var joystickGuid = Guid.Empty;

            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
            {
                joystickGuid = deviceInstance.InstanceGuid;
            }

            // If Gamepad not found, look for a Joystick
            if (joystickGuid == Guid.Empty)
            {
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = deviceInstance.InstanceGuid;
                }
            }

            // If Joystick not found, throws an error
            if (joystickGuid == Guid.Empty)
            {
                Console.WriteLine("No joystick/Gamepad found.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            // Instantiate the joystick
            var joystick = new Joystick(directInput, joystickGuid);

            Console.WriteLine("Found Joystick/Gamepad with GUID: {0}", joystickGuid);

            // Query all suported ForceFeedback effects
            var allEffects = joystick.GetEffects();
            foreach (var effectInfo in allEffects)
            {
                Console.WriteLine("Effect available {0}", effectInfo.Name);
            }

            // Set BufferSize in order to use buffered data.
            joystick.Properties.BufferSize = 128;

            // Acquire the joystick
            joystick.Acquire();

            // Poll events from joystick
            while (true)
            {
                joystick.Poll();
                var datas = joystick.GetBufferedData();
                foreach (var state in datas)
                {
                    //Console.WriteLine(state);
                    if (state.Offset == JoystickOffset.PointOfViewControllers0)
                    {
                        DpadState(state,TCPstream);
                    }
                    else if (state.Offset == JoystickOffset.Buttons0)
                    {
                        ButtonState(state,'1',TCPstream);
                    }
                    else if (state.Offset == JoystickOffset.Buttons1)
                    {
                        ButtonState(state, '2',TCPstream);
                    }
                    else if (state.Offset == JoystickOffset.Buttons2)
                    {
                        ButtonState(state, '3', TCPstream);
                    }
                    else if (state.Offset == JoystickOffset.Buttons3)
                    {
                        ButtonState(state, '4', TCPstream);
                    }
                    else if (state.Offset == JoystickOffset.Buttons4)
                    {
                        ButtonState(state, '5', TCPstream);
                    }
                    else if (state.Offset == JoystickOffset.Buttons5)
                    {
                        ButtonState(state, '6', TCPstream);
                    }
                    else if (state.Offset == JoystickOffset.Buttons6)
                    {
                        ButtonState(state, '7', TCPstream);
                    }
                    else if (state.Offset == JoystickOffset.Buttons7)
                    {
                        ButtonState(state, '8', TCPstream);
                    }
                }
            }

        }
    }
}
