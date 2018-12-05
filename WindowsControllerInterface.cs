using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using SharpDX.DirectInput;
using System.IO.Ports;

namespace WindowsControllerInterface
{
    class Program
    {
        public static int Dpad = 0;

        static string ButtonTranslate(char button)
        {
            switch (button)
            {
                case '1':
                    return "g";
                case '2':
                    return "h";
                case '3':
                    return "i";
                case '4':
                    return "j";
                case '5':
                    return "k";
                case '6':
                    return "l";
                case '7':
                    return "e";
                case '8':
                    return "f";
                default:
                    return "NADA";
            }
        }

        static void ButtonState(SharpDX.DirectInput.JoystickUpdate state, char number, SerialPort SerialConnection)
        {
            ASCIIEncoding asen = new ASCIIEncoding();

            string Button = ButtonTranslate(number);

            if (state.Value == 128)
            {
                Console.WriteLine("Button " + number + " pressed!");
                if (Button != "NADA")
                {
                    string ClientMessage = (Button + "1");
                    Console.WriteLine(ClientMessage);
                    SerialConnection.Write(ClientMessage);
                }
            }
            else if (state.Value == 0)
            {
                Console.WriteLine("Button " + number + " un-pressed!");
                if (Button != "NADA")
                {
                    string ClientMessage = (Button + "0");
                    Console.WriteLine(ClientMessage);
                    SerialConnection.Write(ClientMessage);
                }
            }
        }

        static void DpadState(SharpDX.DirectInput.JoystickUpdate state, SerialPort SerialConnection)
        {
            switch (state.Value)
            {
                case -1: //ALL DPAD INPUTS OFF
                    switch (Dpad)
                    {
                        case 1:
                            Console.WriteLine("DPAD UP un-pressed");
                            Console.WriteLine("a0");
                            SerialConnection.Write("a0");
                            break;
                        case 2:
                            Console.WriteLine("DPAD UP un-pressed");
                            Console.WriteLine("a0");
                            SerialConnection.Write("a0");

                            Console.WriteLine("DPAD RIGHT un-pressed");
                            Console.WriteLine("d0");
                            SerialConnection.Write("d0");
                            break;
                        case 3:
                            Console.WriteLine("DPAD RIGHT un-pressed");
                            Console.WriteLine("d0");
                            SerialConnection.Write("d0");
                            break;
                        case 4:
                            Console.WriteLine("DPAD RIGHT un-pressed");
                            Console.WriteLine("d0");
                            SerialConnection.Write("d0");

                            Console.WriteLine("DPAD DOWN un-pressed");
                            Console.WriteLine("b0");
                            SerialConnection.Write("b0");
                            break;
                        case 5:
                            Console.WriteLine("DPAD DOWN un-pressed");
                            Console.WriteLine("b0");
                            SerialConnection.Write("b0");
                            break;
                        case 6:
                            Console.WriteLine("DPAD DOWN un-pressed");
                            Console.WriteLine("b0");
                            SerialConnection.Write("b0");

                            Console.WriteLine("DPAD LEFT un-pressed");
                            Console.WriteLine("c0");
                            SerialConnection.Write("c0");
                            break;
                        case 7:
                            Console.WriteLine("DPAD LEFT un-pressed");
                            Console.WriteLine("c0");
                            SerialConnection.Write("c0");
                            break;
                        case 8:
                            Console.WriteLine("DPAD LEFT un-pressed");
                            Console.WriteLine("c0");
                            SerialConnection.Write("c0");

                            Console.WriteLine("DPAD UP un-pressed");
                            Console.WriteLine("a0");
                            SerialConnection.Write("a0");
                            break;
                    }
                    Dpad = 0;
                    break;
                case 0: //UP
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD UP pressed");
                            Console.WriteLine("a1");
                            SerialConnection.Write("a1");
                            break;
                        case 2:
                            Console.WriteLine("DPAD RIGHT un-pressed");
                            Console.WriteLine("d0");
                            SerialConnection.Write("d0");
                            break;
                        case 8:
                            Console.WriteLine("DPAD LEFT un-pressed");
                            Console.WriteLine("c0");
                            SerialConnection.Write("c0");
                            break;
                    }
                    Dpad = 1;
                    break;

                case 4500: //UP RIGHT
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD UP pressed");
                            Console.WriteLine("a1");
                            SerialConnection.Write("a1");

                            Console.WriteLine("DPAD RIGHT pressed");
                            Console.WriteLine("d1");
                            SerialConnection.Write("d1");
                            break;
                        case 1:
                            Console.WriteLine("DPAD RIGHT pressed");
                            Console.WriteLine("d1");
                            SerialConnection.Write("d1");
                            break;
                        case 3:
                            Console.WriteLine("DPAD UP pressed");
                            Console.WriteLine("a1");
                            SerialConnection.Write("a1");
                            break;
                    }
                    Dpad = 2;
                    break;

                case 9000: //RIGHT
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD RIGHT pressed");
                            Console.WriteLine("d1");
                            SerialConnection.Write("d1");
                            break;
                        case 2:
                            Console.WriteLine("DPAD UP un-pressed");
                            Console.WriteLine("a0");
                            SerialConnection.Write("a0");
                            break;
                        case 4:
                            Console.WriteLine("DPAD DOWN un-pressed");
                            Console.WriteLine("b0");
                            SerialConnection.Write("b0");
                            break;
                    }
                    Dpad = 3;
                    break;

                case 13500: //DOWN RIGHT
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD DOWN pressed");
                            Console.WriteLine("b1");
                            SerialConnection.Write("b1");

                            Console.WriteLine("DPAD RIGHT pressed");
                            Console.WriteLine("d1");
                            SerialConnection.Write("d1");
                            break;
                        case 3:
                            Console.WriteLine("DPAD DOWN pressed");
                            Console.WriteLine("b1");
                            SerialConnection.Write("b1");
                            break;
                        case 5:
                            Console.WriteLine("DPAD RIGHT pressed");
                            Console.WriteLine("d1");
                            SerialConnection.Write("d1");
                            break;
                    }
                    Dpad = 4;
                    break;

                case 18000: //DOWN
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD DOWN pressed");
                            Console.WriteLine("b1");
                            SerialConnection.Write("b1");
                            break;
                        case 4:
                            Console.WriteLine("DPAD RIGHT un-pressed");
                            Console.WriteLine("d0");
                            SerialConnection.Write("d0");
                            break;
                        case 6:
                            Console.WriteLine("DPAD LEFT un-pressed");
                            Console.WriteLine("c0");
                            SerialConnection.Write("c0");
                            break;
                    }
                    Dpad = 5;
                    break;

                case 22500: //DOWN LEFT
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD DOWN pressed");
                            Console.WriteLine("b1");
                            SerialConnection.Write("b1");

                            Console.WriteLine("DPAD LEFT pressed");
                            Console.WriteLine("c1");
                            SerialConnection.Write("c1");
                            break;
                        case 5:
                            Console.WriteLine("DPAD LEFT pressed");
                            Console.WriteLine("c1");
                            SerialConnection.Write("c1");
                            break;
                        case 7:
                            Console.WriteLine("DPAD DOWN pressed");
                            Console.WriteLine("b1");
                            SerialConnection.Write("b1");
                            break;
                    }
                    Dpad = 6;
                    break;

                case 27000: //LEFT
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD LEFT pressed");
                            Console.WriteLine("c1");
                            SerialConnection.Write("c1");
                            break;
                        case 6:
                            Console.WriteLine("DPAD DOWN un-pressed");
                            Console.WriteLine("b0");
                            SerialConnection.Write("b0");
                            break;
                        case 8:
                            Console.WriteLine("DPAD UP un-pressed");
                            Console.WriteLine("a0");
                            SerialConnection.Write("a0");
                            break;
                    }
                    Dpad = 7;
                    break;

                case 31500: //UP LEFT
                    switch (Dpad)
                    {
                        case 0:
                            Console.WriteLine("DPAD UP pressed");
                            Console.WriteLine("a1");
                            SerialConnection.Write("a1");

                            Console.WriteLine("DPAD LEFT pressed");
                            Console.WriteLine("c1");
                            SerialConnection.Write("c1");
                            break;
                        case 7:
                            Console.WriteLine("DPAD UP pressed");
                            Console.WriteLine("a1");
                            SerialConnection.Write("a1");
                            break;
                        case 1:
                            Console.WriteLine("DPAD LEFT pressed");
                            Console.WriteLine("c1");
                            SerialConnection.Write("c1");
                            break;
                    }
                    Dpad = 8;
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter COM port to use (example, COM3):");
            string COMport = Console.ReadLine();

            SerialPort SerialConnection = new SerialPort(COMport, 9600, Parity.None, 8, StopBits.One);
            SerialConnection.Open();


            // Initialize DirectInput
            var directInput = new DirectInput();

            // Create Joystick Guid array and name array
            var joystickGuid = Guid.Empty;
            System.Collections.Generic.IList<Guid> joystickGuids = new System.Collections.Generic.List<Guid>();
            System.Collections.Generic.IList<string> joystickNames = new System.Collections.Generic.List<string>();

            int counter = 0;
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
            {
                //joystickGuid = deviceInstance.InstanceGuid;
                Console.WriteLine(counter + " - " + deviceInstance.InstanceName + " - " + deviceInstance.InstanceGuid.ToString());
                joystickGuids.Add(deviceInstance.InstanceGuid);
                joystickNames.Add(deviceInstance.InstanceName);
                counter++;
            }

            // look for a Joysticks
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
            {
                Console.WriteLine(counter + " - " + deviceInstance.InstanceName + " - " + deviceInstance.InstanceGuid.ToString());
                joystickGuids.Add(deviceInstance.InstanceGuid);
                joystickNames.Add(deviceInstance.InstanceName);
                counter++;
            }

            // If Joystick not found, throws an error
            if (joystickGuids.Count < 1)
            {
                Console.WriteLine("No joystick/Gamepad found.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            if (joystickGuids.Count > 1)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the number corresponding to the controller you wish to use:");
                int index = Int32.Parse(Console.ReadLine());
                Console.Title = joystickNames[index] + " - " + joystickGuids[index].ToString();
                joystickGuid = joystickGuids[index];
            }
            else
            {
                Console.Title = joystickNames[0] + " - " + joystickGuids[0].ToString();
                joystickGuid = joystickGuids[0];
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
                        DpadState(state, SerialConnection);
                    }
                    else if (state.Offset == JoystickOffset.Buttons0)
                    {
                        ButtonState(state, '1', SerialConnection);
                    }
                    else if (state.Offset == JoystickOffset.Buttons1)
                    {
                        ButtonState(state, '2', SerialConnection);
                    }
                    else if (state.Offset == JoystickOffset.Buttons2)
                    {
                        ButtonState(state, '3', SerialConnection);
                    }
                    else if (state.Offset == JoystickOffset.Buttons3)
                    {
                        ButtonState(state, '4', SerialConnection);
                    }
                    else if (state.Offset == JoystickOffset.Buttons4)
                    {
                        ButtonState(state, '5', SerialConnection);
                    }
                    else if (state.Offset == JoystickOffset.Buttons5)
                    {
                        ButtonState(state, '6', SerialConnection);
                    }
                    else if (state.Offset == JoystickOffset.Buttons6)
                    {
                        ButtonState(state, '7', SerialConnection);
                    }
                    else if (state.Offset == JoystickOffset.Buttons7)
                    {
                        ButtonState(state, '8', SerialConnection);
                    }

                    SerialConnection.DiscardInBuffer(); //ends up locking the serial connection after a bit without this.
                }
            }

        }
    }
}
