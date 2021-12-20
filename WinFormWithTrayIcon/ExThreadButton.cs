using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.AutomationElements;
using System.Diagnostics;
using System.IO;

namespace WinFormWithTrayIcon
{
    class ExThreadButton
    {
        public Thread thr;
        private Logger _log = Global._log;
        private List<Color> _logColors = Global._logColors;
        private FlaUI.UIA3.UIA3Automation automation = new FlaUI.UIA3.UIA3Automation();
        private AutomationElement desktop;

        public ExThreadButton(string name)
        {
            _log.AddToLog("Starting automation process ...", _logColors[0]);
            thr = new Thread(this.RunThread);
            thr.Name = name;
            thr.Start();
        }

        // Enetring point for thread
        void RunThread()
        {
            int i = 0;
            try
            {
                _log.AddToLog("Automation process just started", _logColors[0]);
                //Обновили информацию об открытых окнах
                desktop = automation.GetDesktop();

                while (Global.KeepCycleOn[0])
                {
                    try
                    {
                        Window window = desktop.FindFirstDescendant(f => f.ByClassName("RTS Plaza Workstation 1.96.1.15")).AsWindow();
                        var bar = window.FindAllDescendants(f => f.ByClassName("RTS Plaza Workstation 1.96.1.15"));
                        Global.timesSystem[2] = DateTime.Now;
                    }
                    catch (NullReferenceException ex)
                    {
                        ex.Data.Clear();
                    }

                    //Спим 5 мск
                    Thread.Sleep(5);
                    if (i == 1)
                    {
                        _log.AddToLog("Internal cycle complete", _logColors[1]);
                        i = 0;
                    }
                    i++;
                }
            }
            catch (ThreadAbortException ex)
            {
                ex.Data.Clear();
                _log.AddToLog("Stopping automation process in progress...", _logColors[0]);
            }
            catch (NullReferenceException ex)
            {
                ex.Data.Clear();
            }
        }
    }
}