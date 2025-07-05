using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFilter
{    /*Задание 2
Создайте набор методов:
■ Метод для отображения текущего времени;
■ Метод для отображения текущей даты;
■ Метод для отображения текущего дня недели;

Для реализации проекта используйте делегаты Action,
Predicate, Func.*/
    public static class DataWork
    {

        public static void ShowCurrentTime()
        {
            DateTime time = DateTime.Now;
            Console.WriteLine($"Текущее время: {time.ToString("HH:mm:ss")}");
        }

        public static void ShowCurrentDate()
        {
            DateTime date = DateTime.Now;
            Console.WriteLine($"Текущая дата: {date.ToString("dd.MM.yyyy")}");
        }
        public static void ShowCurrentDayOfWeek ()
        {
            DateTime date = DateTime.Now;
            Console.WriteLine($"Текущий день недели: {date.DayOfWeek}");
        }



    }
}
