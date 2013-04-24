namespace OscopeTools
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.spComm = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.btnSpConnect = new System.Windows.Forms.Button();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSpSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // spComm
            // 
            this.spComm.Handshake = System.IO.Ports.Handshake.XOnXOff;
            this.spComm.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spComm_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial Port:";
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(77, 10);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(121, 21);
            this.cmbSerialPort.TabIndex = 1;
            // 
            // btnSpConnect
            // 
            this.btnSpConnect.Location = new System.Drawing.Point(204, 8);
            this.btnSpConnect.Name = "btnSpConnect";
            this.btnSpConnect.Size = new System.Drawing.Size(90, 23);
            this.btnSpConnect.TabIndex = 2;
            this.btnSpConnect.Text = "Connect";
            this.btnSpConnect.UseVisualStyleBackColor = true;
            this.btnSpConnect.Click += new System.EventHandler(this.btnSpConnect_Click);
            // 
            // txtReceived
            // 
            this.txtReceived.Location = new System.Drawing.Point(13, 43);
            this.txtReceived.Multiline = true;
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.Size = new System.Drawing.Size(288, 169);
            this.txtReceived.TabIndex = 3;
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(13, 229);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(207, 20);
            this.txtSend.TabIndex = 4;
            // 
            // btnSpSend
            // 
            this.btnSpSend.Location = new System.Drawing.Point(226, 226);
            this.btnSpSend.Name = "btnSpSend";
            this.btnSpSend.Size = new System.Drawing.Size(75, 23);
            this.btnSpSend.TabIndex = 5;
            this.btnSpSend.Text = "Send";
            this.btnSpSend.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 261);
            this.Controls.Add(this.btnSpSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.btnSpConnect);
            this.Controls.Add(this.cmbSerialPort);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort spComm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSerialPort;
        private System.Windows.Forms.Button btnSpConnect;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSpSend;
    }
}

