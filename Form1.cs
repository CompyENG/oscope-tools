using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OscopeTools
{
    public partial class Form1 : Form
    {
        delegate void appendMessageCallback(string text);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbSerialPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (System.IO.Ports.SerialPort.GetPortNames().Length > 0)
            {
                cmbSerialPort.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No serial ports found.");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (spComm.IsOpen)
            {
                spComm.Close();
            }
        }

        private void btnSpConnect_Click(object sender, EventArgs e)
        {
            try
            {
                spComm.PortName = (string)cmbSerialPort.SelectedItem;
                spComm.Open();
                MessageBox.Show("Opened " + (string)cmbSerialPort.SelectedItem);
            }
            catch
            {
                MessageBox.Show("Could not open " + (string)cmbSerialPort.SelectedItem);
            }
        }

        private void spComm_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            appendMessage(spComm.ReadExisting());
        }

        private void btnSpSend_Click(object sender, EventArgs e)
        {
            spComm.WriteLine(txtSend.Text);
            spComm.ReadTimeout = 1000;
            /*try
            {
                txtReceived.Text += spComm.ReadLine();
            }
            catch
            {
                MessageBox.Show("Could not read from serial port.");
            }*/
        }

        private void appendMessage(string text)
        {
            if (txtReceived.InvokeRequired)
            {
                appendMessageCallback d = new appendMessageCallback(appendMessage);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                txtReceived.Text += text;
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            // Disable the automatic data handler
            spComm.DataReceived -= spComm_DataReceived;
            // Set up read and ask for preamble
            string channel = cmbChannel.Text.Replace(" ", "");
            spComm.WriteLine(":WAVEFORM:FORMAT byte;POINTS 100;SOURCE " + channel + ";Preamble?");
            spComm.ReadTimeout = 1000;
            string preamble = spComm.ReadLine();
            string[] preambles = preamble.Split(',');
            Console.WriteLine(preamble);

            // Ask for data
            spComm.WriteLine(":WAVEFORM:DATA?");
            // First byte should be a # to indicate fixed-length data
            byte data = (byte)spComm.ReadByte();
            if (data != '#')
            {
                MessageBox.Show("Error: Didn't receive correct format of data.");
                // Read the rest of the line and discard it. This ensures we're always in the right place
                spComm.DiscardInBuffer();
                return;
            }
            // Next byte tells how many bytes follow for size
            data = (byte)spComm.ReadByte();
            int size_length = Int32.Parse(((char)data).ToString());
            // Now, receive that many bytes in length
            byte[] baLength = new byte[size_length];
            int read = 0;
            while (read < size_length)
            {
                read += spComm.Read(baLength, read, size_length - read);
            }
            int length = baToInt(baLength);

            byte[] datab = new byte[length];
            read = 0;
            while (read < length)
            {
                read += spComm.Read(datab, read, length-read);
            }

            // We'll need to read one more byte -- the "end of line" marker.
            spComm.ReadByte();

            // Let's also try graphing
            DataPointCollection p = chrtOscope.Series[0].Points;

            for (int i = 0; i < datab.Length; i++)
            {
                //Console.WriteLine(String.Format("data[i]: {0} ; {0:X} ; {1} ; {2:X}", data[i], (int)data[i], datab[i]));
                float v = ((int)datab[i] - float.Parse(preambles[9])) * float.Parse(preambles[7]) + float.Parse(preambles[8]);
                float t = (i - float.Parse(preambles[6])) * float.Parse(preambles[4]) + float.Parse(preambles[5]);
                p.Add(new DataPoint(t, v));
                lvOscopeData.Items.Add(new ListViewItem(new string[] { (i).ToString(), String.Format("{0}", Convert.ToInt32(datab[i])), t.ToString(), v.ToString() }));
            }

            spComm.DataReceived += spComm_DataReceived;
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
