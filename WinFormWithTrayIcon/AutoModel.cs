using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormWithTrayIcon
{
    public class Environment
    {
        public string Variables { get; set; }
        public AutoWindow[] Windows { get; set; }
    }

    public class AutoWindow
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public SequenceBody[] Sequence { get; set; }
    }

    public class SequenceBody
    {
        public int Number { get; set; }
        //Что за объект мы ищем - может быть None если action wait и т.д.
        //Может быть AutomationId,Name и т.д.
        public string PointType { get; set; }
        //Имя объекта который мы ищем Название, Цифры автоматизации - все равно строка
        public string PointName { get; set; }
        //Пока доп поле, не знаю зачем
        public string PointValue { get; set; }
        //Действия которые мы проводим над объектом
        public Action[] PointActions { get; set; }
       
    }

    public class Action
    {
        //Условие при котором нужно выполнить действие
        public string ActionCondition { get; set; }
        //Тип действия
        public string ActionType { get; set; }
        //Значение действию
        public string ActionValue { get; set; }

    }
}
