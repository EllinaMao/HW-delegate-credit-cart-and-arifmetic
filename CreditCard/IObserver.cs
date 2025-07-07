using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3_CreditCard;

namespace Interfaces
{
    public interface IObserver//Кдасс который смотрит на изменения
    {
        void Update(string message, CreditCard card);
    }
}
