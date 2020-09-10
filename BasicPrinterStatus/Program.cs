using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace BasicPrinterStatus
{
    class Program
    {
        public static bool statusResultRead = false;
        public static int statusResult = -1;
        public static SerialPort comport = new SerialPort();
        static void Main(string[] args)
        {
            
            Console.WriteLine("Console port is open: " + comport.IsOpen);
            if (!comport.IsOpen)
            {
                // Set the port's settings
                comport.BaudRate = int.Parse("9600");
                comport.DataBits = int.Parse("8");
                comport.StopBits = StopBits.One;
                comport.Parity = Parity.None;

                comport.DtrEnable = true;

                comport.PortName = "COM3"; //"COM15";
                // Open the port
                comport.Open();
            }
            _writeByte(0x1B);
            _writeByte(0x76);

            //comport.Write(new byte[] { 0x1B }, 0,1);
            //comport.Write(new byte[] { 0x76 }, 0,1);

            int x = comport.ReadByte();
            Console.WriteLine(x.ToString());

            comport.Close();
            Console.WriteLine("Hello World!");
        }
        private static void _writeByte(byte valueToWrite)
        {
            byte[] tempArray = { valueToWrite };
            comport.Write(tempArray, 0, 1);
        }

    }
}
