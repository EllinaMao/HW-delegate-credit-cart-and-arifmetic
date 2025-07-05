using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    /*Задание 3
Создайте приложения для выполнения арифметических операций. Поддерживаемые операции:
■ Проверка числа на чётность;
■ Проверка числа на нечётность;
Практическое задание
1
■ Проверка является ли число простым;
■ Проверка является ли число числом Фибоначчи.
Обязательно используйте делегат типа Predicate.
Задание 4
Реализуйте приложение из второго практического
задания с использованием вызова Invoke*/

    /*Создайте набор методов для работы с массивами:
■ Метод для получения всех четных чисел в массиве;
■ Метод для получения всех нечетных чисел в массиве;
■ Метод для получения всех простых чисел в массиве;
■ Метод для получения всех чисел Фибоначчи в массиве.
Используйте механизмы делегатов.*/
    public static class Arifmetic
    {
        static public void IsNum(int number, Predicate<int> predicate, string checkName)
        {
            bool result = predicate(number);
            Console.WriteLine($"{checkName} для числа {number}: {result}");
        }

        static public List<int> IsInArray(List<int> source, Predicate<int> filter)
        {
            List<int> result = new List<int>();
            result.AddRange(source.Where(item => filter(item)));
            return result;
        }

        static public Predicate<int> IsPositive => n => n > 0;
        static public Predicate<int> IsNegative => n => n < 0;
        static public Predicate<int> IsEven => n => n % 2 == 0;
        static public Predicate<int> IsOdd => n => n % 2 != 0;
        static public Predicate<int> IsPrime => n =>
        {
            if (n <= 1) return false; // 0 и 1 не простые числа
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        };
        static public Predicate<int> IsFibonacci => n =>
        {
            int a = 0, b = 1;
            if (n < 0) return false; // отрицательные числа не могут быть Фибоначчи
            while (b < n)
            {
                int temp = b;
                b += a;
                a = temp;
            }
            return b == n;
        };
    }
}
