namespace ClientWin
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.displayTextBox = new System.Windows.Forms.TextBox();
            this.COM = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btTest = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.info = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbOpenCOM = new System.Windows.Forms.CheckBox();
            this.cbSN = new System.Windows.Forms.CheckBox();
            this.cbAZ = new System.Windows.Forms.CheckBox();
            this.cbEL = new System.Windows.Forms.CheckBox();
            this.cbDN = new System.Windows.Forms.CheckBox();
            this.cbUP = new System.Windows.Forms.CheckBox();
            this.cbDM = new System.Windows.Forms.CheckBox();
            this.cbUM = new System.Windows.Forms.CheckBox();
            this.tbWrite = new System.Windows.Forms.TrackBar();
            this.lbT = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.cbEL0 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_180 = new System.Windows.Forms.CheckBox();
            this.tbPortName = new System.Windows.Forms.DomainUpDown();
            this.tbBaudRate = new System.Windows.Forms.DomainUpDown();
            this.cb_Predict500ms = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer_500 = new System.Windows.Forms.Timer(this.components);
            this.lb_minus = new System.Windows.Forms.Label();
            this.lb_plus = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbWrite)).BeginInit();
            this.SuspendLayout();
            // 
            // displayTextBox
            // 
            this.displayTextBox.Location = new System.Drawing.Point(11, 15);
            this.displayTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.ReadOnly = true;
            this.displayTextBox.Size = new System.Drawing.Size(707, 22);
            this.displayTextBox.TabIndex = 0;
            this.displayTextBox.TabStop = false;
            this.displayTextBox.DoubleClick += new System.EventHandler(this.displayTextBox_DoubleClick);
            // 
            // COM
            // 
            this.COM.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.COM_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "BaudRate:";
            // 
            // btTest
            // 
            this.btTest.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btTest.Location = new System.Drawing.Point(191, 64);
            this.btTest.Margin = new System.Windows.Forms.Padding(4);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(51, 25);
            this.btTest.TabIndex = 5;
            this.btTest.Text = "Test";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.info});
            this.statusStrip1.Location = new System.Drawing.Point(11, 165);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(707, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // info
            // 
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 17);
            // 
            // cbOpenCOM
            // 
            this.cbOpenCOM.AutoSize = true;
            this.cbOpenCOM.Enabled = false;
            this.cbOpenCOM.Location = new System.Drawing.Point(299, 65);
            this.cbOpenCOM.Margin = new System.Windows.Forms.Padding(4);
            this.cbOpenCOM.Name = "cbOpenCOM";
            this.cbOpenCOM.Size = new System.Drawing.Size(63, 21);
            this.cbOpenCOM.TabIndex = 1;
            this.cbOpenCOM.Text = "Write";
            this.cbOpenCOM.UseVisualStyleBackColor = true;
            // 
            // cbSN
            // 
            this.cbSN.AutoSize = true;
            this.cbSN.Checked = true;
            this.cbSN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSN.Location = new System.Drawing.Point(299, 94);
            this.cbSN.Margin = new System.Windows.Forms.Padding(4);
            this.cbSN.Name = "cbSN";
            this.cbSN.Size = new System.Drawing.Size(49, 21);
            this.cbSN.TabIndex = 6;
            this.cbSN.Text = "SN";
            this.cbSN.UseVisualStyleBackColor = true;
            // 
            // cbAZ
            // 
            this.cbAZ.AutoSize = true;
            this.cbAZ.Checked = true;
            this.cbAZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAZ.Location = new System.Drawing.Point(361, 94);
            this.cbAZ.Margin = new System.Windows.Forms.Padding(4);
            this.cbAZ.Name = "cbAZ";
            this.cbAZ.Size = new System.Drawing.Size(48, 21);
            this.cbAZ.TabIndex = 7;
            this.cbAZ.Text = "AZ";
            this.cbAZ.UseVisualStyleBackColor = true;
            // 
            // cbEL
            // 
            this.cbEL.AutoSize = true;
            this.cbEL.Checked = true;
            this.cbEL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEL.Location = new System.Drawing.Point(421, 94);
            this.cbEL.Margin = new System.Windows.Forms.Padding(4);
            this.cbEL.Name = "cbEL";
            this.cbEL.Size = new System.Drawing.Size(47, 21);
            this.cbEL.TabIndex = 8;
            this.cbEL.Text = "EL";
            this.cbEL.UseVisualStyleBackColor = true;
            // 
            // cbDN
            // 
            this.cbDN.AutoSize = true;
            this.cbDN.Checked = true;
            this.cbDN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDN.Location = new System.Drawing.Point(476, 94);
            this.cbDN.Margin = new System.Windows.Forms.Padding(4);
            this.cbDN.Name = "cbDN";
            this.cbDN.Size = new System.Drawing.Size(50, 21);
            this.cbDN.TabIndex = 9;
            this.cbDN.Text = "DN";
            this.cbDN.UseVisualStyleBackColor = true;
            // 
            // cbUP
            // 
            this.cbUP.AutoSize = true;
            this.cbUP.Checked = true;
            this.cbUP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUP.Location = new System.Drawing.Point(539, 94);
            this.cbUP.Margin = new System.Windows.Forms.Padding(4);
            this.cbUP.Name = "cbUP";
            this.cbUP.Size = new System.Drawing.Size(49, 21);
            this.cbUP.TabIndex = 10;
            this.cbUP.Text = "UP";
            this.cbUP.UseVisualStyleBackColor = true;
            // 
            // cbDM
            // 
            this.cbDM.AutoSize = true;
            this.cbDM.Location = new System.Drawing.Point(607, 94);
            this.cbDM.Margin = new System.Windows.Forms.Padding(4);
            this.cbDM.Name = "cbDM";
            this.cbDM.Size = new System.Drawing.Size(51, 21);
            this.cbDM.TabIndex = 11;
            this.cbDM.Text = "DM";
            this.cbDM.UseVisualStyleBackColor = true;
            // 
            // cbUM
            // 
            this.cbUM.AutoSize = true;
            this.cbUM.Location = new System.Drawing.Point(671, 94);
            this.cbUM.Margin = new System.Windows.Forms.Padding(4);
            this.cbUM.Name = "cbUM";
            this.cbUM.Size = new System.Drawing.Size(51, 21);
            this.cbUM.TabIndex = 12;
            this.cbUM.Text = "UM";
            this.cbUM.UseVisualStyleBackColor = true;
            // 
            // tbWrite
            // 
            this.tbWrite.AutoSize = false;
            this.tbWrite.Location = new System.Drawing.Point(361, 48);
            this.tbWrite.Margin = new System.Windows.Forms.Padding(4);
            this.tbWrite.Maximum = 20;
            this.tbWrite.Minimum = 1;
            this.tbWrite.Name = "tbWrite";
            this.tbWrite.Size = new System.Drawing.Size(192, 38);
            this.tbWrite.TabIndex = 2;
            this.tbWrite.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbWrite.Value = 2;
            this.tbWrite.ValueChanged += new System.EventHandler(this.tbWrite_ValueChanged);
            // 
            // lbT
            // 
            this.lbT.AutoSize = true;
            this.lbT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbT.Location = new System.Drawing.Point(553, 63);
            this.lbT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbT.Name = "lbT";
            this.lbT.Size = new System.Drawing.Size(35, 17);
            this.lbT.TabIndex = 17;
            this.lbT.Text = "2 [s]";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 8000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // cbEL0
            // 
            this.cbEL0.AutoSize = true;
            this.cbEL0.Checked = true;
            this.cbEL0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEL0.Location = new System.Drawing.Point(421, 121);
            this.cbEL0.Margin = new System.Windows.Forms.Padding(4);
            this.cbEL0.Name = "cbEL0";
            this.cbEL0.Size = new System.Drawing.Size(54, 21);
            this.cbEL0.TabIndex = 13;
            this.cbEL0.Text = ">=0";
            this.cbEL0.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(678, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "v. 3,54";
            // 
            // cb_180
            // 
            this.cb_180.AutoSize = true;
            this.cb_180.Location = new System.Drawing.Point(361, 121);
            this.cb_180.Margin = new System.Windows.Forms.Padding(4);
            this.cb_180.Name = "cb_180";
            this.cb_180.Size = new System.Drawing.Size(54, 21);
            this.cb_180.TabIndex = 20;
            this.cb_180.Text = "180";
            this.cb_180.UseVisualStyleBackColor = true;
            // 
            // tbPortName
            // 
            this.tbPortName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbPortName.Items.Add("COM1");
            this.tbPortName.Items.Add("COM2");
            this.tbPortName.Items.Add("COM3");
            this.tbPortName.Items.Add("COM4");
            this.tbPortName.Items.Add("COM5");
            this.tbPortName.Items.Add("COM6");
            this.tbPortName.Items.Add("COM7");
            this.tbPortName.Items.Add("COM8");
            this.tbPortName.Items.Add("COM9");
            this.tbPortName.Items.Add("COM10");
            this.tbPortName.Items.Add("COM11");
            this.tbPortName.Items.Add("COM12");
            this.tbPortName.Items.Add("COM13");
            this.tbPortName.Items.Add("COM14");
            this.tbPortName.Items.Add("COM15");
            this.tbPortName.Items.Add("COM16");
            this.tbPortName.Items.Add("COM17");
            this.tbPortName.Items.Add("COM18");
            this.tbPortName.Items.Add("COM19");
            this.tbPortName.Items.Add("COM20");
            this.tbPortName.Items.Add("COM21");
            this.tbPortName.Items.Add("COM22");
            this.tbPortName.Items.Add("COM23");
            this.tbPortName.Items.Add("COM24");
            this.tbPortName.Items.Add("COM25");
            this.tbPortName.Items.Add("COM26");
            this.tbPortName.Items.Add("COM27");
            this.tbPortName.Items.Add("COM28");
            this.tbPortName.Items.Add("COM29");
            this.tbPortName.Items.Add("COM30");
            this.tbPortName.Location = new System.Drawing.Point(91, 64);
            this.tbPortName.Margin = new System.Windows.Forms.Padding(4);
            this.tbPortName.Name = "tbPortName";
            this.tbPortName.ReadOnly = true;
            this.tbPortName.Size = new System.Drawing.Size(92, 22);
            this.tbPortName.TabIndex = 21;
            this.tbPortName.TabStop = false;
            this.tbPortName.Text = "COM1";
            this.tbPortName.SelectedItemChanged += new System.EventHandler(this.tbPortName_SelectedItemChanged);
            // 
            // tbBaudRate
            // 
            this.tbBaudRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbBaudRate.Items.Add("4800");
            this.tbBaudRate.Items.Add("9600");
            this.tbBaudRate.Items.Add("19200");
            this.tbBaudRate.Items.Add("38400");
            this.tbBaudRate.Location = new System.Drawing.Point(91, 96);
            this.tbBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.tbBaudRate.Name = "tbBaudRate";
            this.tbBaudRate.ReadOnly = true;
            this.tbBaudRate.Size = new System.Drawing.Size(92, 22);
            this.tbBaudRate.TabIndex = 22;
            this.tbBaudRate.TabStop = false;
            this.tbBaudRate.Text = "9600";
            this.tbBaudRate.SelectedItemChanged += new System.EventHandler(this.tbBaudRate_SelectedItemChanged);
            // 
            // cb_Predict500ms
            // 
            this.cb_Predict500ms.AutoSize = true;
            this.cb_Predict500ms.Location = new System.Drawing.Point(607, 62);
            this.cb_Predict500ms.Margin = new System.Windows.Forms.Padding(4);
            this.cb_Predict500ms.Name = "cb_Predict500ms";
            this.cb_Predict500ms.Size = new System.Drawing.Size(65, 21);
            this.cb_Predict500ms.TabIndex = 23;
            this.cb_Predict500ms.Text = "0.5[s]";
            this.toolTip1.SetToolTip(this.cb_Predict500ms, "Write on read \"GET\" chars");
            this.cb_Predict500ms.UseVisualStyleBackColor = true;
            this.cb_Predict500ms.CheckedChanged += new System.EventHandler(this.cb_WriteOnRead_CheckedChanged);
            // 
            // timer_500
            // 
            this.timer_500.Enabled = true;
            this.timer_500.Interval = 470;
            this.timer_500.Tick += new System.EventHandler(this.timer_500_Tick);
            // 
            // lb_minus
            // 
            this.lb_minus.AutoSize = true;
            this.lb_minus.Location = new System.Drawing.Point(384, 136);
            this.lb_minus.Name = "lb_minus";
            this.lb_minus.Size = new System.Drawing.Size(13, 17);
            this.lb_minus.TabIndex = 24;
            this.lb_minus.Text = "-";
            this.lb_minus.Click += new System.EventHandler(this.lb_minus_Click);
            // 
            // lb_plus
            // 
            this.lb_plus.AutoSize = true;
            this.lb_plus.Location = new System.Drawing.Point(397, 136);
            this.lb_plus.Name = "lb_plus";
            this.lb_plus.Size = new System.Drawing.Size(16, 17);
            this.lb_plus.TabIndex = 25;
            this.lb_plus.Text = "+";
            this.lb_plus.Click += new System.EventHandler(this.lb_plus_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(729, 197);
            this.Controls.Add(this.lb_plus);
            this.Controls.Add(this.lb_minus);
            this.Controls.Add(this.cb_Predict500ms);
            this.Controls.Add(this.tbBaudRate);
            this.Controls.Add(this.tbPortName);
            this.Controls.Add(this.cb_180);
            this.Controls.Add(this.displayTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbEL0);
            this.Controls.Add(this.lbT);
            this.Controls.Add(this.tbWrite);
            this.Controls.Add(this.cbUM);
            this.Controls.Add(this.cbDM);
            this.Controls.Add(this.cbUP);
            this.Controls.Add(this.cbDN);
            this.Controls.Add(this.cbEL);
            this.Controls.Add(this.cbAZ);
            this.Controls.Add(this.cbSN);
            this.Controls.Add(this.cbOpenCOM);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.Text = "MyDDE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbWrite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox displayTextBox;
        private System.IO.Ports.SerialPort COM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel info;
        private System.Windows.Forms.CheckBox cbOpenCOM;
        private System.Windows.Forms.CheckBox cbSN;
        private System.Windows.Forms.CheckBox cbAZ;
        private System.Windows.Forms.CheckBox cbEL;
        private System.Windows.Forms.CheckBox cbDN;
        private System.Windows.Forms.CheckBox cbUP;
        private System.Windows.Forms.CheckBox cbDM;
        private System.Windows.Forms.CheckBox cbUM;
        private volatile System.Windows.Forms.TrackBar tbWrite;
        private System.Windows.Forms.Label lbT;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox cbEL0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb_180;
        private System.Windows.Forms.DomainUpDown tbPortName;
        private System.Windows.Forms.DomainUpDown tbBaudRate;
        private System.Windows.Forms.CheckBox cb_Predict500ms;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer_500;
        private System.Windows.Forms.Label lb_minus;
        private System.Windows.Forms.Label lb_plus;
    }
}

