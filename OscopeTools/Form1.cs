using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // TODO: I think I'm going to have to do a byte-by-byte read. ReadLine() just isn't acting as I think it should
            string data = spComm.ReadLine();
            byte[] datab = new byte[data.Length * sizeof(char)];
            System.Buffer.BlockCopy(data.ToCharArray(), 0, datab, 0, datab.Length);
            if (data[0] != '#')
            {
                MessageBox.Show("Error: Didn't receive correct format of data.");
                return;
            }
            int start = int.Parse(data[1].ToString())+2;

            for (int i = start; i < data.Length; i++)
            {
                Console.WriteLine(String.Format("data[i]: {0} ; {0:X} ; {1} ; {2:X}", data[i], (int)data[i], datab[i]));
                float v = ((int)data[i] - float.Parse(preambles[9])) * float.Parse(preambles[7]) + float.Parse(preambles[8]);
                float t = (i - start - float.Parse(preambles[6])) * float.Parse(preambles[4]) + float.Parse(preambles[5]);
                lvOscopeData.Items.Add(new ListViewItem(new string[] { (i - start).ToString(), String.Format("{0}", Convert.ToInt32(data[i])), t.ToString(), v.ToString() }));
            }

            spComm.DataReceived += spComm_DataReceived;
        }
    }
}
