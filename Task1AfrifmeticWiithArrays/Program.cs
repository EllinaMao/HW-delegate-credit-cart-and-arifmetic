using Delegates;
namespace Task1AfrifmeticWiithArrays
{
    /*
     Создайте набор методов для работы с массивами:
■ Метод для получения всех четных чисел в массиве;
■ Метод для получения всех нечетных чисел в массиве;
■ Метод для получения всех простых чисел в массиве;
■ Метод для получения всех чисел Фибоначчи в массиве.
Используйте механизмы делегатов.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 21, 34, 55 };
            List<int> evenNumbers = Arifmetic.IsInArray(numbers, Arifmetic.IsEven);
            Console.WriteLine("Четные числа: " + string.Join(", ", evenNumbers));
            List<int> oddNumbers = Arifmetic.IsInArray(numbers, Arifmetic.IsOdd);
            Console.WriteLine("Нечетные числа: " + string.Join(", ", oddNumbers));
            List<int> primeNumbers = Arifmetic.IsInArray(numbers, Arifmetic.IsPrime);
            Console.WriteLine("Простые числа: " + string.Join(", ", primeNumbers));
            List<int> fibonacciNumbers = Arifmetic.IsInArray(numbers, Arifmetic.IsFibonacci);
            Console.WriteLine("Числа Фибоначчи: " + string.Join(", ", fibonacciNumbers));

        }
    }
}
