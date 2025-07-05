using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
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
    internal static class Arifmetic
    {
        static public void IsNum(int number, Predicate<int> predicate, string checkName)
        {
            bool result = predicate(number);
            Console.WriteLine($"{checkName} для числа {number}: {result}");

        }

    
        static public bool IsEven(int n) => n % 2 == 0;

        static public bool IsOdd(int n) => n % 2 != 0;

        static public bool IsPrime(int n)
        {
            if (n <= 1) return false;// 0 и 1 не простые числа
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static public bool IsFibonacci(int number)
        {
            if (number < 0) { return false; }//ток подожительные

            int a = 0, b = 1;

            while (b < number)//Идем по числам Фибоначчи пока не дошлепаем до числа или выше его
            {
                int temp = b;
                b += a;
                a = temp;
            }
            return b == number;
        }












    }
}
