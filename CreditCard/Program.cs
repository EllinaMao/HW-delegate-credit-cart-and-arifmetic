namespace Task_3_CreditCard
{/*Задание 3
Создайте класс «Кредитная карточка». Класс должен
содержать:
■ Номер карты;
■ ФИО владельца;
■ Срок действия карты;
■ PIN;
■ Кредитный лимит;
■ Сумма денег.

Создайте необходимый набор методов класса. Реализуйте события для следующих ситуаций:
■ Пополнение счёта;
■ Расход денег со счёта;
■ Старт использования кредитных денег;
■ Достижение заданной суммы денег;
■ Смена PIN*/
    internal static class Program
    {
        static void Main(string[] args)
        {
            /*https://metanit.com/sharp/patterns/3.2.php*/

            CreditCard card = new CreditCard(
                        1234567890123456,
                        "Марченко И.И.",
                        DateTime.Now.AddYears(3),
                        1234,
                        5000 
                    );

            BankLogger logger = new BankLogger();

            card.RegisterObserver(logger);
            Console.WriteLine(card);
            card.AddMoney(500);
            card.RemoveMoney(1200); // уходит в минус (используется кредит)
            card.CheckThreshold(); // проверка достижения суммы
            card.ChangePin(4321);
            Console.WriteLine(card);

            Console.ReadLine();
            Console.Clear();


            logger.ShowAllLog();

        }
    }
}
