using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_CreditCard
{
    /*Задание 3
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
    internal class CreditCard
    {
        readonly long CardNumber; // В случае если номер карты хочется сменить - надо создавать новую карту
        public string OwnerName { get; }
        public DateTime ExpiryDate { get; }
        private int Pin;
        /*decimal — это тип данных в C#, предназначенный для хранения десятичных дробных чисел с высокой точностью. Он особенно полезен для финансовых и денежных расчётов, где важна точность до копейки и недопустимы ошибки округления.
          суффикс m - указывает что литерал относится к decimal*/
        public decimal CreditLimit { get; set; }
        private decimal Balance;

        public int pin
        {
            get => Pin;
            set
            {
                if (value.ToString().Length == 4)
                {
                    Pin = value;
                }
                else
                {
                    throw new ArgumentException("PIN должен состоять из 4 цифр");
                }
            }
        }
        public decimal balance
        {
            get => Balance;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Баланс не может быть отрицательным");
                }
                Balance = value;
            }
        }
////////////////////////////////////////////////
        public CreditCard(long cardNumber, string ownerName, DateTime expiryDate, int pin_, decimal creditLimit)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            ExpiryDate = expiryDate;
            pin = pin_;
            CreditLimit = creditLimit;
            Balance = 0;
        }
        /*
    Создайте необходимый набор методов класса. Реализуйте события для следующих ситуаций:
    ■ Пополнение счёта;
    ■ Расход денег со счёта;
    ■ Старт использования кредитных денег;
    ■ Достижение заданной суммы денег;
    ■ Смена PIN
        */
        AddMoney new AddingNewEventArgs
        {
            get => new AddMoney();
            set => AddingNewEventArgs = value;
        }



}
}
