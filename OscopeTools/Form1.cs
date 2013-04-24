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
            txtReceived.Text += spComm.ReadExisting();
        }

        private void btnSpSend_Click(object sender, EventArgs e)
        {
            spComm.WriteLine(txtSend.Text);
        }
    }
}
