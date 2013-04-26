using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace OscopeTools
{
    public struct oscope_id
    {
        public string make;
        public string model;
        public float version;
    }

    public struct oscope_data
    {
        public int raw;
        public float time;
        public float voltage;
    }

    class Oscope
    {
        private SerialPort port;

        public oscope_id ID
        {
            get
            {
                port.WriteLine("*IDN?");
                string resp = port.ReadLine();
                oscope_id ret;
                string[] parts = resp.Split(',');
                ret.make = parts[0];
                ret.model = parts[1];
                ret.version = float.Parse(parts[3]);
                return ret;
            }
        }

        public bool Connected
        {
            get
            {
                return port.IsOpen;
            }
        }

        public Oscope()
        {
            port = new SerialPort();
            port.Handshake = Handshake.XOnXOff;
            port.DtrEnable = true;
            port.RtsEnable = true;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.ReadTimeout = 1000;
        }

        public Oscope(string portName, int baud=19200)
            : this()
        {
            this.Connect(portName, baud);
        }

        public void Connect(string portName, int baud = 19200)
        {
            port.PortName = portName;
            port.BaudRate = baud;

            port.Open();
        }

        public void Disconnect()
        {
            if (this.Connected)
            {
                port.Close();
            }
        }

        public oscope_data[] GetData(int channel=1, int points=100)
        {
            if (channel < 1 || channel > 4)
            {
                // Only channels 1-4 exist.
                throw new Exception("Error: Channel outside range.");
            }

            // First, digitize
            string strChannel = String.Format("Channel{0}", channel);
            port.WriteLine(":WAVEFORM:POINTS " + points + ";SOURCE " + strChannel + port.NewLine + ":DIGITIZE " + strChannel);

            // Set up read and ask for preamble
            port.WriteLine(":WAVEFORM:FORMAT byte;Preamble?");
            string preamble = port.ReadLine();
            string[] preambles = preamble.Split(',');

            // Ask for data
            port.WriteLine(":WAVEFORM:DATA?");
            // First byte should be a # to indicate fixed-length data
            byte data = (byte)port.ReadByte();
            if (data != '#')
            {
                // Didn't get the right data -- discard the rest
                port.DiscardInBuffer();
                throw new Exception("Did not receive correct format of data");
            }

            // Next byte tells how many bytes follow for size
            data = (byte)port.ReadByte();
            int size_length = Int32.Parse(((char)data).ToString());
            // Now, receive that many bytes in length
            byte[] baLength = new byte[size_length];
            int read = 0;
            while (read < size_length)
            {
                read += port.Read(baLength, read, size_length - read);
            }
            int length = baToInt(baLength);

            byte[] datab = new byte[length];
            read = 0;
            while (read < length)
            {
                read += port.Read(datab, read, length - read);
            }

            // We'll need to read one more byte -- the "end of line" marker.
            port.ReadByte();

            oscope_data[] ret = new oscope_data[datab.Length];

            for (int i = 0; i < datab.Length; i++)
            {
                //Console.WriteLine(String.Format("data[i]: {0} ; {0:X} ; {1} ; {2:X}", data[i], (int)data[i], datab[i]));
                float v = ((int)datab[i] - float.Parse(preambles[9])) * float.Parse(preambles[7]) + float.Parse(preambles[8]);
                float t = (i - float.Parse(preambles[6])) * float.Parse(preambles[4]) + float.Parse(preambles[5]);
                ret[i].raw = datab[i];
                ret[i].time = t;
                ret[i].voltage = v;
            }

            return ret;
        }

        private int baToInt(byte[] ba)
        {
            int ret = 0;
            foreach (char c in ba)
            {
                ret = ret * 10 + Int32.Parse(c.ToString());
            }
            return ret;
        }
    }
}
