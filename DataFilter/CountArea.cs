using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator
{/*    Создайте набор методов:

Для реализации проекта используйте делегаты Action,
Predicate, Func.
  * ■ Метод для подсчёта площади треугольника;
■ Метод для подсчёта площади прямоугольника.*/
    internal static class CountArea
    {
        static public double AreaTriangle(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        static public double AreaRectangle(double width, double height)
        {
            return width * height;
        }


    }
}
