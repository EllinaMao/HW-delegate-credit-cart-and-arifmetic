using DataFilter;
using AreaCalculator;
using System.Text.RegularExpressions;
namespace Task2
{
    /*Задание 2
Создайте набор методов:
■ Метод для отображения текущего времени;
■ Метод для отображения текущей даты;
■ Метод для отображения текущего дня недели;
■ Метод для подсчёта площади треугольника;
■ Метод для подсчёта площади прямоугольника.
Для реализации проекта используйте делегаты Action,
Predicate, Func.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Action showTime = DataWork.ShowCurrentTime;
            Action showDate = DataWork.ShowCurrentDate;
            Action showDayOfWeek = DataWork.ShowCurrentDayOfWeek;

            Action ThisTime; 
            ThisTime = showTime;
            ThisTime += showDate;
            ThisTime += showDayOfWeek;

            ThisTime.Invoke();

            Console.ReadLine();
            Console.Clear();

            Func<double, double, double, double> triangleArea = CountArea.AreaTriangle;
            double area1 = triangleArea(3, 4, 5);
            Console.WriteLine($"Triangle area: {area1}");
  
            Func<double, double, double> rectangleArea = CountArea.AreaRectangle;
            double area2 = rectangleArea(5, 10);
            Console.WriteLine($"Rectangle area: {area2}");
 
            Predicate<double> isLargeArea = area => area > 10;
            Console.WriteLine($"Is triangle area > 10? {isLargeArea(area1)}");

            Action<double> printArea = area => Console.WriteLine($"Area: {area}");
            printArea(area2);



        }
    }
}
