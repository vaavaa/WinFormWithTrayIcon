using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormWithTrayIcon
{
    public static class Global
    {
        public static Logger _log = new Logger(500u);
        public static List<Color> _logColors = new List<Color> { Color.Red, Color.SkyBlue, Color.Green };
        public static bool[] KeepCycleOn = { false };
        //Время систем
        public static List<DateTime> timesSystem = new List<DateTime> {
            new DateTime(2021, 12, 19, 21, 33, 0, 0), //Локальное время - 0
            new DateTime(2021, 12, 19, 21, 33, 0, 0), //Глобальное время - 1
            new DateTime(2021, 12, 19, 21, 33, 0, 0)  //Время программы - 2
        };
        public static List<DateTime> timesSet = new List<DateTime> {
            new DateTime(2021, 12, 19, 21, 33, 0, 0), //Локальное время - 0
            new DateTime(2021, 12, 19, 21, 33, 0, 0), //Глобальное время - 1
            new DateTime(2021, 12, 19, 21, 33, 0, 0)  //Время программы - 2
        };
        public static void GetProgrammTime() {
        
        }
    }
}