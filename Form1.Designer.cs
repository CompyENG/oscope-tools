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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.btnSpConnect = new System.Windows.Forms.Button();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSpSend = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.cmbChannel = new System.Windows.Forms.ComboBox();
            this.lvOscopeData = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chrtOscope = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chrtOscope)).BeginInit();
            this.SuspendLayout();
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
            this.btnSpSend.Click += new System.EventHandler(this.btnSpSend_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(177, 256);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(124, 23);
            this.btnGetData.TabIndex = 7;
            this.btnGetData.Text = "Get Oscope Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // cmbChannel
            // 
            this.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannel.FormattingEnabled = true;
            this.cmbChannel.Items.AddRange(new object[] {
            "Channel 1",
            "Channel 2",
            "Channel 3",
            "Channel 4"});
            this.cmbChannel.Location = new System.Drawing.Point(12, 258);
            this.cmbChannel.Name = "cmbChannel";
            this.cmbChannel.Size = new System.Drawing.Size(159, 21);
            this.cmbChannel.TabIndex = 8;
            // 
            // lvOscopeData
            // 
            this.lvOscopeData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvOscopeData.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvOscopeData.GridLines = true;
            this.lvOscopeData.Location = new System.Drawing.Point(307, 8);
            this.lvOscopeData.Name = "lvOscopeData";
            this.lvOscopeData.ShowGroups = false;
            this.lvOscopeData.Size = new System.Drawing.Size(454, 271);
            this.lvOscopeData.TabIndex = 9;
            this.lvOscopeData.UseCompatibleStateImageBehavior = false;
            this.lvOscopeData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "X Data";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Y Data";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Time";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Voltage";
            // 
            // chrtOscope
            // 
            chartArea1.Name = "ChartArea1";
            this.chrtOscope.ChartAreas.Add(chartArea1);
            this.chrtOscope.Location = new System.Drawing.Point(13, 286);
            this.chrtOscope.Name = "chrtOscope";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chrtOscope.Series.Add(series1);
            this.chrtOscope.Size = new System.Drawing.Size(748, 276);
            this.chrtOscope.TabIndex = 10;
            this.chrtOscope.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 574);
            this.Controls.Add(this.chrtOscope);
            this.Controls.Add(this.lvOscopeData);
            this.Controls.Add(this.cmbChannel);
            this.Controls.Add(this.btnGetData);
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
            ((System.ComponentModel.ISupportInitialize)(this.chrtOscope)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSerialPort;
        private System.Windows.Forms.Button btnSpConnect;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSpSend;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ComboBox cmbChannel;
        private System.Windows.Forms.ListView lvOscopeData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtOscope;
    }
}

