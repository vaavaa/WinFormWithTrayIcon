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
    class ExThread
    {
        public Thread thr;
        private Logger _log = Global._log;
        private List<Color> _logColors = Global._logColors;
        public FlaUI.UIA3.UIA3Automation automation = new FlaUI.UIA3.UIA3Automation();
        public AutomationElement desktop;
        public Environment Auto;
        public List<string> queriesWindows = new List<string>();

        public ExThread(string name, Environment AutoObject)
        {
            _log.AddToLog("Starting automation process ...", _logColors[0]);
            thr = new Thread(this.RunThread);
            thr.Name = name;
            Auto = AutoObject;
            thr.Start();
        }

        // Enetring point for thread
        void RunThread()
        {
            int i = 0;
            try
            {
                _log.AddToLog("Automation process just started", _logColors[0]);
                queriesWindows.Clear();

                while (Global.KeepCycleOn[0])
                {
                    //Обновили информацию об открытых окнах
                    AutomationElement desktop = automation.GetDesktop();
                    AutoWindow[] windowsOrdered =
                        Auto.Windows.OrderBy(node => node.Order).ToArray();
                    foreach (AutoWindow window in windowsOrdered)
                    {
                        if (window == null) break;
                        var nameWindow = window.Name;
                        switch (nameWindow)
                        {
                            case "NoneWindow":
                                if (queriesWindows.Any(nameWindow.Contains)) break;
                                if (window.Sequence == null) break;
                                SequenceBody[] noneOrder =
                                    window.Sequence.OrderBy(node => node.Number).ToArray();
                                HandleSequences(noneOrder);
                                queriesWindows.Add(nameWindow);
                                break;
                            default:
                                try
                                {
                                    var window64 = desktop.FindFirstDescendant(f => f.ByName(nameWindow)).AsWindow();
                                    if (window.Sequence != null) break;
                                    SequenceBody[] rightOrder =
                                        window.Sequence.OrderBy(node => node.Number).ToArray();
                                    HandleSequences(rightOrder);
                                    queriesWindows.Add(nameWindow);
                                }
                                catch (ThreadAbortException ex)
                                {
                                    ex.Data.Clear();
                                }
                                catch (NullReferenceException ex)
                                {
                                    ex.Data.Clear();
                                }
                                break;
                        }
                    }

                    //Спим 50 мск
                    Thread.Sleep(50);
                    if (i == 15)
                    {
                        _log.AddToLog("Internal cycle complete", _logColors[1]);
                        i = 0;
                    }

                    i++;
                }
            }
            catch (ThreadAbortException)
            {
                queriesWindows.Clear();
                _log.AddToLog("Stopping automation process in progress...", _logColors[0]);
            }
        }

        private void HandleSequences(SequenceBody[] sequences)
        {
            foreach (SequenceBody sBody in sequences)
            {
                switch (sBody.PointType.ToLower())
                {
                    case "none":
                        HandleActions(sBody.PointActions);
                        break;
                    default:
                        break;
                }
            }
        }

        private void HandleActions(Action[] pointActions)
        {
            if (pointActions == null) return;
            foreach (Action action in pointActions)
            {
                switch (action.ActionType.ToLower())
                {
                    case "wait":
                        Thread.Sleep(Int32.Parse(action.ActionValue));
                        break;
                    case "launchapp":
                        _log.AddToLog("Starting application...", _logColors[2]);
                        var appFolderName = Path.GetDirectoryName(action.ActionValue);
                        ProcessStartInfo processInfo = new ProcessStartInfo(action.ActionValue)
                        {
                            WorkingDirectory = appFolderName
                        };
                        Process.Start(processInfo);
                        _log.AddToLog("Application started", _logColors[2]);

                        break;
                    default:
                        break;
                }
            }
        }
    }
}