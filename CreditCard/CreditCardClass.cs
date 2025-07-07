using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

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
    public class CreditCard: IObservable//за ним наблюдает, каждое действие должно вызывать ивент передавая информацию о событии.
    {
        public long CardNumber { get; }
        public string OwnerName { get; }
        public DateTime ExpiryDate { get; }
        private int Pin;
        public int Threshold { get; set; }

        /*decimal — это тип данных в C#, предназначенный для хранения десятичных дробных чисел с высокой точностью. Он особенно полезен для финансовых и денежных расчётов, где важна точность до копейки и недопустимы ошибки округления.
          суффикс m - указывает что литерал относится к decimal*/
        public decimal CreditLimit { get; set; }
        private decimal Balance;
        private List<IObserver> observers;
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
        public CreditCard(long cardNumber, string ownerName, DateTime expiryDate, int pin_, decimal creditLimit, int threshold = 500)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            ExpiryDate = expiryDate;
            pin = pin_;
            CreditLimit = creditLimit;
            Threshold = threshold;
            Balance = 0;
            observers = new List<IObserver>();
        }
        /*
    Создайте необходимый набор методов класса. Реализуйте события для следующих ситуаций:
    ■ Пополнение счёта;
    ■ Расход денег со счёта;
    ■ Старт использования кредитных денег;
    ■ Достижение заданной суммы денег;
    ■ Смена PIN
        */
        //AddMoney new AddingNewEventArgs
        //{
        //    get => new AddMoney();
        //    set => AddingNewEventArgs = value;
        //}
        public void RegisterObserver(IObserver o) => observers.Add(o);
        public void RemoveObserver(IObserver o) => observers.Remove(o);
        public void NotifyObservers(string message)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(message, this);
            }
        }

        public void AddMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма пополнения должна быть положительной");
            }
            balance += amount;
            CheckThreshold();
            NotifyObservers($"Пополнение счёта на сумму {amount}. Текущий баланс: {Balance}");
        }

        public void RemoveMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма снятия должна быть положительной");
            }
            if (amount > Balance + CreditLimit)
            {
                throw new InvalidOperationException("Операция отклонена. Недостаточно средств на счёте и кредитном лимите");
            }
            if (amount > Balance)
            {
                decimal creditUsed = amount - Balance;
                balance = 0;
                CreditLimit -= creditUsed;
                NotifyObservers($"Начало использования кредитных денег. Снятие со счёта на сумму {amount}. Текущий баланс: {Balance}");
                return;
            }

            balance -= amount;
            NotifyObservers($"Снятие со счёта на сумму {amount}. Текущий баланс: {Balance}");
        }

        public void ChangePin(int newPin)
        {
            if (newPin.ToString().Length != 4)
            {
                throw new ArgumentException("Новый PIN должен состоять из 4 цифр");
            }
            Pin = newPin;
            NotifyObservers($"PIN успешно изменён на {newPin}");
        }

        public void CheckBalance()
        {
            NotifyObservers($"Текущий баланс: {Balance}, Кредитный лимит: {CreditLimit}");
        }

        public void CheckCreditLimit()
        {
            NotifyObservers($"Кредитный лимит: {CreditLimit}");
        }
        public void CheckCardDetails()
        {
            NotifyObservers($"Номер карты: {CardNumber}, Владелец: {OwnerName}, Срок действия: {ExpiryDate.ToShortDateString()}, PIN: {Pin}, Кредитный лимит: {CreditLimit}, Баланс: {Balance}");
        }

        public override string ToString()
        {
            return $"Кредитная карта: {CardNumber}, Владелец: {OwnerName}, Срок действия: {ExpiryDate.ToShortDateString()}, PIN: {Pin}, Кредитный лимит: {CreditLimit}, Баланс: {Balance}";
        }

        //    ■ Достижение заданной суммы денег;

        public void CheckThreshold()
        {
            if (Balance >= Threshold)
            {
                NotifyObservers($"Достигнута заданная сумма денег: {Threshold}. Текущий баланс: {Balance}");
            }
        }



    }
}
  