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
    }
}
