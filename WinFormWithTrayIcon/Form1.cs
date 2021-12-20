using FlaUI.Core.AutomationElements.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FlaUI.Core.AutomationElements;
using TextBox = FlaUI.Core.AutomationElements.TextBox;
using GuerrillaNtp;
using System.Net;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace WinFormWithTrayIcon
{
    public partial class Form1 : Form
    {
        private bool Terminating = false;
        private bool GlobalTimeAsked = false;
        private TimeSpan? offset = null;
        private Logger _log = Global._log;
        private List<Color> _logColors = Global._logColors;
        private int RichTextLength = 0;
        public Thread t;
        private ExThreadButton exThreadButton;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Items.Clear();
            this.contextMenuStrip1.Items.Add("&Restore");
            this.contextMenuStrip1.Items.Add("-");
            this.contextMenuStrip1.Items.Add("E&xit");
            timeUpdater.Start();
            logUpdater.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Terminating)
            {
                // the idle state has occurred, and the tray notification should be gone.
                // ok to shutdown now
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing && MessageBox.Show("Are you sure you want to close this form?",
                    "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                // only the user, selecting Cancel in a MessageBox, can do this.
                e.Cancel = true;
            }

            if (!e.Cancel)
            {
                // The application will shut down.
                // Проверяем не запущена ли автоматизация, если запущена остнавливаем
                if (Global.KeepCycleOn[0]) closeAutomatization();

                // We cancel the shutdown, because the timer will do the shutdown when it fires.
                // This will return to the app and allow the idle state to occur.
                e.Cancel = true;

                // Dispose of the tray icon this way.
                this.notifyIcon1.Dispose();

                // Set the termination flag so that the next entry into this event will
                // not be cancelled.
                Terminating = true;

                // Activate the timer to fire
                this.timer1.Interval = 100;
                this.timer1.Enabled = true;
                this.timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // the idle state is past.. at this point, the tray notification is gone from
            // the system tray.  

            // Deactivate the timer.. it is no longer needed.
            timer1.Stop();
            timer1.Enabled = false;

            // close the form, which will start the shutdown of the application.
            this.Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "&Restore")
            {
                Show();
                WindowState = FormWindowState.Normal;
                return;
            }

            else if (e.ClickedItem.Text == "E&xit")
            {
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Global.KeepCycleOn[0])
            {
                Global.KeepCycleOn[0] = true;
                exThreadButton = new ExThreadButton("ThreadButton ");
                this.button1.Text = "Stop!";
            }
            else
            {
                closeAutomatization();
            }
        }

        private void closeAutomatization()
        {
            Global.KeepCycleOn[0] = false;
            _log.AddToLog("Stopping automatization process...", _logColors[0]);
            exThreadButton.thr.Abort(100);
            exThreadButton.thr.Join();
            _log.AddToLog("Automatization process just stopped", _logColors[0]);
            this.button1.Text = "Start";
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!GlobalTimeAsked)
            {
                try
                {
                    using (var ntp = new NtpClient(Dns.GetHostAddresses("pool.ntp.org")[0]))
                        offset = ntp.GetCorrectionOffset();
                    GlobalTimeAsked = true;
                }
                catch (System.Net.Sockets.SocketException)
                {
                }
            }

            if (offset == null)
            {
                offset = TimeSpan.FromSeconds(-2);
            }

            // use the offset throughout your app
            var accurateTime = DateTime.UtcNow + offset;
            var localtime = DateTime.Now;
            this.txtLocalTime.Text = localtime.ToString();
            this.txtGlobalTime.Text = accurateTime.ToString();
            Global.timesSystem[0] = localtime;
            Global.timesSystem[1] = accurateTime.Value;
            //Global.times[2] = 
        }


        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void logUpdater_Tick(object sender, EventArgs e)
        {
            String LogValue = _log.GetLogAsRichText(false);
            if (LogValue != null && LogValue.Length != RichTextLength)
            {
                richTextBox1.Rtf = LogValue;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                // scroll it automatically
                richTextBox1.ScrollToCaret();
                RichTextLength = LogValue.Length;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var now = CSharpScript
                .EvaluateAsync<bool>("WinFormWithTrayIcon.Global.times[0] < new System.DateTime(2021,12,20,17,15,0,0)")
                .Result;
            MessageBox.Show(now.ToString());
        }

        private Environment GetEnvironment()
        {
            Action[] actions = new Action[2];

            actions[0] = new Action
            {
                ActionCondition = "None",
                ActionType = "LaunchApp",
                ActionValue = "C:\\Program Files (x86)\\ETCPlaza\\launcher.exe"
            };

            actions[1] = new Action
            {
                ActionCondition = "None",
                ActionType = "wait",
                ActionValue = "5000"
            };

            SequenceBody[] sequences = new SequenceBody[1];
            sequences[0] = new SequenceBody
            {
                Number = 0,
                PointType = "None",
                PointName = "",
                PointValue = "C:\\Program Files (x86)\\ETCPlaza",
                PointActions = actions
            };

            AutoWindow[] windows = new AutoWindow[1];
            windows[0] = new AutoWindow
            {
                Order = 100,
                Name = "NoneWindow",
                Sequence = sequences
            };

            var obj = new Environment
            {
                Variables = "me=1900;tpl=8090;fpl='dddddd';noway='80'",
                Windows = windows
            };

            return obj;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.time3.ReadOnly)
            {
                if (this.time3.Text.Length != 12)
                {
                    checkBox3.Checked = false;
                    MessageBox.Show("Необходимо ввести полное время запуска.", "Внимание");
                    return;
                }
                else
                {
                    string[] exactTime = this.time3.Text.Split(':');
                    int HH = int.Parse(exactTime[0]);
                    int mm = int.Parse(exactTime[1]);
                    int ss = int.Parse(exactTime[2]);
                    int msec = int.Parse(exactTime[3]);
                    
                    //Рубиконом является 11:00
                    TimeSpan start = new TimeSpan(11, 0, 0); //11 o'clock
                    TimeSpan now = DateTime.Now.TimeOfDay;
                    int plus = 0;
                    if (now > start) plus = 0;
                    try
                    {
                        DateTime runTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, HH, mm, ss, msec);
                        runTime = runTime.AddDays(plus);
                        Global.timesSet[2] = runTime;
                        _log.AddToLog("Program running time set to " + runTime.ToString("dd.MM.yyyy:HH.mm.ss.fff"),
                            _logColors[1]);
                        this.time3.ReadOnly = true;
                    }
                    catch (Exception)
                    {
                        checkBox3.Checked = false;
                        MessageBox.Show("Необходимо ввести корректное время запуска.", "Внимание");
                    }

                }
            }
            else this.time3.ReadOnly = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.time1.ReadOnly)
            {
                if (this.time1.Text.Length != 12)
                {
                    checkBox1.Checked = false;
                    MessageBox.Show("Необходимо ввести полное время запуска.", "Внимание");
                    return;
                }
                else
                {
                    string[] exactTime = this.time1.Text.Split(':');
                    int HH = int.Parse(exactTime[0]);
                    int mm = int.Parse(exactTime[1]);
                    int ss = int.Parse(exactTime[2]);
                    int msec = int.Parse(exactTime[3]);
                    
                    //Рубиконом является 11:00
                    TimeSpan start = new TimeSpan(11, 0, 0); //11 o'clock
                    TimeSpan now = DateTime.Now.TimeOfDay;
                    int plus = 0;
                    if (now > start) plus = 0;
                    try
                    {
                        DateTime runTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, HH, mm, ss, msec);
                        runTime = runTime.AddDays(plus);
                        Global.timesSet[0] = runTime;
                        _log.AddToLog("Local running time set to " + runTime.ToString("dd.MM.yyyy:HH.mm.ss.fff"),
                            _logColors[1]);
                        this.time1.ReadOnly = true;
                    }
                    catch (Exception)
                    {
                        checkBox1.Checked = false;
                        MessageBox.Show("Необходимо ввести корректное время запуска.", "Внимание");
                    }

                }
            }
            else this.time1.ReadOnly = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.time2.ReadOnly)
            {
                if (this.time2.Text.Length != 12)
                {
                    checkBox2.Checked = false;
                    MessageBox.Show("Необходимо ввести полное время запуска.", "Внимание");
                    return;
                }
                else
                {
                    string[] exactTime = this.time2.Text.Split(':');
                    int HH = int.Parse(exactTime[0]);
                    int mm = int.Parse(exactTime[1]);
                    int ss = int.Parse(exactTime[2]);
                    int msec = int.Parse(exactTime[3]);
                    
                    //Рубиконом является 11:00
                    TimeSpan start = new TimeSpan(11, 0, 0); //11 o'clock
                    TimeSpan now = DateTime.Now.TimeOfDay;
                    int plus = 0;
                    if (now > start) plus = 0;
                    try
                    {
                        DateTime runTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, HH, mm, ss, msec);
                        runTime = runTime.AddDays(plus);
                        Global.timesSet[1] = runTime;
                        _log.AddToLog("Global running time set to " + runTime.ToString("dd.MM.yyyy:HH.mm.ss.fff"),
                            _logColors[1]);
                        this.time2.ReadOnly = true;
                    }
                    catch (Exception)
                    {
                        checkBox2.Checked = false;
                        MessageBox.Show("Необходимо ввести корректное время запуска.", "Внимание");
                    }

                }
            }
            else this.time2.ReadOnly = false;
        }
    }
}