using System;

namespace BabysitterKata
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            Babysitter babysitter = new Babysitter();
            Console.WriteLine("Hi! My name is Bee. I hear you're in need of a babysitter tonight?");

            string answer = Console.ReadLine();
            if(answer == "yes" || answer == "y")
            {
   
                    Console.WriteLine("Excellent! Well I'm the best. What time would you need me there?");
                    string startInput = Console.ReadLine();

                    Console.WriteLine("And what time would you be back?");
                    string endInput = Console.ReadLine();

                    TimeSpan start = DateTime.Parse(startInput).TimeOfDay;
                    TimeSpan end = DateTime.Parse(endInput).TimeOfDay;
                    bool checkStartAndEnd = babysitter.ValidateStartAndEnd(start, end);
                    if (checkStartAndEnd)
                    {
                        Console.WriteLine("Oh and what time is bedtime for the little one?");
                        string bedtimeInput = Console.ReadLine();
                        TimeSpan bedtime = DateTime.Parse(bedtimeInput).TimeOfDay;
                        bool checkBedTime = babysitter.ValidateBedTime(bedtime);
                        string response = babysitter.Babysit(start, end, bedtime);
                        Console.WriteLine(response);
                        Console.Read();
                    }
                    else
                    {
                        Console.WriteLine($"Sorry those times don't work for me. I'm available from { babysitter.EarliestStart } until { babysitter.LatestEnd }");
                    Console.WriteLine("Please try again.");
                    }
                
            }
            else
            {
                Console.WriteLine("Oh! Sorry my mistake. Have a nice day!");
                Console.Read();
            }
            Console.WriteLine("Hello World!");
        }
    }
}
