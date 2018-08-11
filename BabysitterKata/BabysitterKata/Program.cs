using System;

namespace BabysitterKata
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            Babysitter babysitter = new Babysitter();
            Console.WriteLine("Hi! My name is Bee. I'm new to babysitting.\r\n" +
                       "I can work anytime between 5:00 PM and 4:00 AM.\r\n" +
                       "I charge $12/hour from start until bed time, $8/hour from then until midnight, and $16/hour for every hour after that.\r\n\r\n");
            Console.WriteLine("Do you need a babysitter for tonight?");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "y")
            {
                while (repeat)
                {
                    TimeSpan start = new TimeSpan();
                    TimeSpan end = new TimeSpan();
                    TimeSpan bedtime = new TimeSpan();                 
                    Console.WriteLine("What time would you need me there?");
                    string startInput = Console.ReadLine();
                    while (true)
                    {
                        if (!babysitter.IsAValidTime(startInput))
                        {
                            Console.WriteLine($"I'm sorry, I don't think { startInput } is a valid time. Can you try again?");
                            startInput = Console.ReadLine();
                        }
                        else
                        {
                            start = DateTime.Parse(startInput).TimeOfDay;
                            if (!babysitter.ValidateTimeByType(start, Babysitter.Times.Start))
                            {
                                Console.WriteLine($"That start time doesn't work for me. I can't start until { DateTime.Today.Add(babysitter.EarliestStart).ToString("hh:mm tt") }.");
                                startInput = Console.ReadLine();
                            }
                            else
                            {
                                babysitter.StartTime = start;
                                break;
                            }
                        }
                    }

                    Console.WriteLine("And what time would you be back?");
                    string endInput = Console.ReadLine();
                    while (true)
                    {
                        if (!babysitter.IsAValidTime(endInput))
                        {
                            Console.WriteLine($"I'm sorry, I don't think { endInput } is a valid time. Can you try again?");
                            endInput = Console.ReadLine();
                        }
                        else
                        {
                            end = DateTime.Parse(endInput).TimeOfDay;
                            if (!babysitter.ValidateTimeByType(end, Babysitter.Times.End))
                            {
                                if(babysitter.LatestEnd < end && end <= babysitter.StartTime)
                                    Console.WriteLine($"That end time doesn't work for me. You asked me to start at { DateTime.Today.Add(babysitter.StartTime).ToString("hh:mm tt") }.");
                                else
                                    Console.WriteLine($"That end time doesn't work for me. I can only work until { DateTime.Today.Add(babysitter.LatestEnd).ToString("hh:mm tt") }.");
                                endInput = Console.ReadLine();
                            }
                            else
                            {
                                babysitter.EndTime = end;
                                break;
                            }
                        }
                    }
                    Console.WriteLine("Oh and what time is bedtime for the little one?");
                    string bedtimeInput = Console.ReadLine();
                    while (true)
                    {
                        if (!babysitter.IsAValidTime(bedtimeInput))
                        {
                            Console.WriteLine($"I'm sorry, I don't think { bedtimeInput } is a valid time. Can you try again?");
                            bedtimeInput = Console.ReadLine();
                        }
                        else
                        {
                            bedtime = DateTime.Parse(bedtimeInput).TimeOfDay;
                            if (!babysitter.ValidateTimeByType(bedtime, Babysitter.Times.Bedtime))
                            {
                                Console.WriteLine("Shouldn't the bedtime be between when I arrive and when you return?");
                                bedtimeInput = Console.ReadLine();
                            }
                            else
                            {
                                babysitter.BedTime = bedtime;
                                break;
                            }
                        }
                    }
                    string response = babysitter.Babysit();
                    Console.WriteLine(response + "\r\n");

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
            }
            else if (answer == "no" || answer == "n")
            {
                Console.WriteLine("Oh! Sorry my mistake. Have a nice day!");
                Console.Read();
            }
            else
            {
                Console.WriteLine("I'm sorry I didn't get that. Please respond with yes or no");
            }
        }
    }
}
