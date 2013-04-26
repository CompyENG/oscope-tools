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

        private Oscope oscope;

        public Form1()
        {
            InitializeComponent();
            oscope = new Oscope();
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
            oscope.Disconnect();
        }

        private void btnSpConnect_Click(object sender, EventArgs e)
        {
            try
            {
                oscope.Connect((string)cmbSerialPort.SelectedItem);
                MessageBox.Show("Opened " + (string)cmbSerialPort.SelectedItem);
            }
            catch
            {
                MessageBox.Show("Could not open " + (string)cmbSerialPort.SelectedItem);
            }
        }

        private void btnSpSend_Click(object sender, EventArgs e)
        {
            oscope_id id = oscope.ID;
            txtReceived.Text = String.Format("Make: {0}\nModel: {1}\nVersion: {2}", id.make, id.model, id.version);
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
            oscope_data[] data = oscope.GetData(1, 100);

            DataPointCollection p = chrtOscope.Series[0].Points;
            int i = 0;

            foreach (oscope_data d in data)
            {
                p.Add(new DataPoint(d.time, d.voltage));
                lvOscopeData.Items.Add(new ListViewItem(new string[] { (i).ToString(), d.raw.ToString(), d.time.ToString(), d.voltage.ToString() }));
                i++;
            }
        }

        
    }
}
