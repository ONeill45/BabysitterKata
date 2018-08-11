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
            while (repeat)
            {
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "y")
                {
                    bool isTime = false;
                    Console.WriteLine("Excellent! Well I'm the best.\r\n" +
                        "I can work anytime between 5:00 PM and 4:00 AM.\r\n" +
                        "I charge $12/hour from start until bed time, $8/hour from then until midnight, and $16/hour for every hour after that.\r\n\r\n" +
                        "What time would you need me there?");
                    string startInput = Console.ReadLine();
                    while (!isTime)
                    {
                        if (babysitter.IsAValidTime(startInput))
                        {
                            isTime = true;
                        }
                        else
                        {
                            Console.WriteLine($"I'm sorry, I don't think { startInput } is a valid time. Can you try again?");
                            startInput = Console.ReadLine();
                        }
                    }
                    isTime = false;
                    Console.WriteLine("And what time would you be back?");
                    string endInput = Console.ReadLine();
                    while (!isTime)
                    {
                        if (babysitter.IsAValidTime(endInput))
                        {
                            isTime = true;
                        }
                        else
                        {
                            Console.WriteLine($"I'm sorry, I don't think { endInput } is a valid time. Can you try again?");
                            endInput = Console.ReadLine();
                        }
                    }
                    isTime = false;
                    TimeSpan start = DateTime.Parse(startInput).TimeOfDay;
                    TimeSpan end = DateTime.Parse(endInput).TimeOfDay;
                    bool checkStartAndEnd = babysitter.ValidateStartAndEnd(start, end);
                    if (checkStartAndEnd)
                    {
                        Console.WriteLine("Oh and what time is bedtime for the little one?");
                        string bedtimeInput = Console.ReadLine();
                        while (!isTime)
                        {
                            if (babysitter.IsAValidTime(bedtimeInput))
                            {
                                isTime = true;
                            }
                            else
                            {
                                Console.WriteLine($"I'm sorry, I don't think { bedtimeInput } is a valid time. Can you try again?");
                                bedtimeInput = Console.ReadLine();
                            }
                        }
                        isTime = false;
                        TimeSpan bedtime = DateTime.Parse(bedtimeInput).TimeOfDay;
                        bool checkBedTime = babysitter.ValidateBedTime(bedtime);

                        string response = babysitter.Babysit(start, end, bedtime);
                        Console.WriteLine(response);

                        Console.Read();
                        Console.WriteLine("Would you like to make a request for another night?");
                        string newRequest = Console.ReadLine().ToLower();
                        if (newRequest == "no" || newRequest == "n")
                        {
                            Console.WriteLine("Pleasure doing business with you!");
                            repeat = false;
                            Console.Read();
                        }
                        else if (newRequest == "yes" || newRequest == "y")
                            continue;
                        else
                        {
                            Console.WriteLine("I'm sorry I didn't get that. Please respond with yes or no");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sorry those times don't work for me. I'm available from { babysitter.EarliestStart } until { babysitter.LatestEnd }");
                        Console.WriteLine("Please try again.");
                    }
                }
                else if(answer == "no" || answer == "n")
                {
                    Console.WriteLine("Oh! Sorry my mistake. Have a nice day!");
                    Console.Read();
                    break;
                }
                else
                {
                    Console.WriteLine("I'm sorry I didn't get that. Please respond with yes or no");
                }
            }
        }
    }
}
