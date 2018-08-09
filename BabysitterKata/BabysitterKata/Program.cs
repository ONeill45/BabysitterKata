using System;

namespace BabysitterKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();
            Babysitter babysitter = new Babysitter();

            Console.WriteLine($"Hello {name}!");
            Console.WriteLine("My name is Bee. I heard you were in need of a babysitter tonight?");

            Console.WriteLine("What time would you need me to start?");
            string startInput = Console.ReadLine();
            
            Console.WriteLine("Okay and what time would you be home?");
            string endInput = Console.ReadLine();

            DateTime start = DateTime.Parse(startInput);
            DateTime end = DateTime.Parse(endInput);

            Console.Read();
        }
    }
}
