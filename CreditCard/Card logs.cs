using Interfaces;
namespace Task_3_CreditCard
{

    public class BankLogger : IObserver
    {
        public List<string> log { get; private set; }
        public BankLogger()
        {
            log = new List<string>(); // Fixed initialization of the list
        }
        public void Update(string message, CreditCard card)
        {
            string formattedMessage = $"[Лог карты {card.CardNumber}] {message}";
            log.Add(formattedMessage);
            ShowLastUpdate(formattedMessage);
        }
        private static void ShowLastUpdate(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowAllLog()
        {
            Console.WriteLine("Лог карты:");
            foreach (var entry in log)
            {
                Console.WriteLine(entry);
            }
        }
        public void ClearLog()
        {
            log.Clear();
            Console.WriteLine("Лог карты очищен.");
        }
    }

}

