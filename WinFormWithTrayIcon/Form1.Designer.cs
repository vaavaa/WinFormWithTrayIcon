namespace WinFormWithTrayIcon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOK = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.timeUpdater = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.time3 = new System.Windows.Forms.MaskedTextBox();
            this.time2 = new System.Windows.Forms.MaskedTextBox();
            this.time1 = new System.Windows.Forms.MaskedTextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtProgramTime = new System.Windows.Forms.TextBox();
            this.txtGlobalTime = new System.Windows.Forms.TextBox();
            this.txtLocalTime = new System.Windows.Forms.TextBox();
            this.logUpdater = new System.Windows.Forms.Timer(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(396, 41);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Exit";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 10);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(57, 6);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon) (resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "WinFormWithTrayIcon";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(396, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timeUpdater
            // 
            this.timeUpdater.Interval = 50;
            this.timeUpdater.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.time3);
            this.groupBox1.Controls.Add(this.time2);
            this.groupBox1.Controls.Add(this.time1);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.txtProgramTime);
            this.groupBox1.Controls.Add(this.txtGlobalTime);
            this.groupBox1.Controls.Add(this.txtLocalTime);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 97);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time Flag";
            // 
            // time3
            // 
            this.time3.Location = new System.Drawing.Point(202, 67);
            this.time3.Mask = "00:00:00:000";
            this.time3.Name = "time3";
            this.time3.Size = new System.Drawing.Size(141, 20);
            this.time3.TabIndex = 11;
            // 
            // time2
            // 
            this.time2.Location = new System.Drawing.Point(202, 41);
            this.time2.Mask = "00:00:00:000";
            this.time2.Name = "time2";
            this.time2.Size = new System.Drawing.Size(141, 20);
            this.time2.TabIndex = 10;
            // 
            // time1
            // 
            this.time1.Location = new System.Drawing.Point(202, 16);
            this.time1.Mask = "00:00:00:000";
            this.time1.Name = "time1";
            this.time1.Size = new System.Drawing.Size(141, 20);
            this.time1.TabIndex = 9;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(16, 67);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(65, 17);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "Program";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(16, 44);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(56, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Global";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(52, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Local";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtProgramTime
            // 
            this.txtProgramTime.Location = new System.Drawing.Point(86, 67);
            this.txtProgramTime.Name = "txtProgramTime";
            this.txtProgramTime.ReadOnly = true;
            this.txtProgramTime.Size = new System.Drawing.Size(110, 20);
            this.txtProgramTime.TabIndex = 8;
            // 
            // txtGlobalTime
            // 
            this.txtGlobalTime.Location = new System.Drawing.Point(86, 41);
            this.txtGlobalTime.Name = "txtGlobalTime";
            this.txtGlobalTime.ReadOnly = true;
            this.txtGlobalTime.Size = new System.Drawing.Size(110, 20);
            this.txtGlobalTime.TabIndex = 7;
            // 
            // txtLocalTime
            // 
            this.txtLocalTime.Location = new System.Drawing.Point(86, 16);
            this.txtLocalTime.Name = "txtLocalTime";
            this.txtLocalTime.ReadOnly = true;
            this.txtLocalTime.Size = new System.Drawing.Size(110, 20);
            this.txtLocalTime.TabIndex = 6;
            // 
            // logUpdater
            // 
            this.logUpdater.Tick += new System.EventHandler(this.logUpdater_Tick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlText;
            this.richTextBox1.Location = new System.Drawing.Point(12, 115);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(484, 367);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 494);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SilkDragon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button1;

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timeUpdater;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtProgramTime;
        private System.Windows.Forms.TextBox txtGlobalTime;
        private System.Windows.Forms.TextBox txtLocalTime;
        private System.Windows.Forms.Timer logUpdater;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MaskedTextBox time3;
        private System.Windows.Forms.MaskedTextBox time2;
        private System.Windows.Forms.MaskedTextBox time1;
    }
}

