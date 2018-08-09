using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BabysitterKata
{
    public class Babysitter
    {
        #region properties
        public string Name { get; set; }
        public TimeSpan EarliestStart { get; set; }
        public TimeSpan LatestEnd { get; set; }
        public static TimeSpan EndOfDay { get; set; }
        public static TimeSpan Midnight { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan BedTime { get; set; }
        #endregion
        #region constructors
        public Babysitter(string name = "Bee")
        {
            Name = name;
            EarliestStart = new TimeSpan(17, 0, 0);
            LatestEnd = new TimeSpan(4, 0, 0);
            Midnight = new TimeSpan(0, 0, 0);
            EndOfDay = new TimeSpan(23, 59, 0);
        }
        #endregion
        #region methods 
        public string Babysit(TimeSpan start, TimeSpan end, TimeSpan bedtime)
        {
            if(ValidateStartAndEnd(start, end))
            {
                StartTime = start;
                EndTime = end;
                if (ValidateBedTime(bedtime))
                {
                    BedTime = bedtime;
                    double total = CalculateTotal();
                    return "Sure I can babysit from " 
                        + DateTime.Today.Add(StartTime).ToString("hh:mm tt") + " to " 
                        + DateTime.Today.Add(EndTime).ToString("hh:mm tt") 
                        + ". That will be $" + total;
                }
                else
                {
                    return "Are you sure about that bedtime?";
                }

            }
            else
            {
                return "I'm sorry, that doesn't work. I can babysit between "
                    + DateTime.Today.Add(EarliestStart).ToString("hh:mm tt")
                    + " and "
                    + DateTime.Today.Add(LatestEnd).ToString("hh:mm tt");
            }
        }
        public double CalculateHourlyRate(TimeSpan time)
        {

            if (time >= EarliestStart && time < BedTime)
            {
                return 12.0;
            }
            if (time >= BedTime && time <= EndOfDay)
            {
                return 8.0;
            }
            else if (time >= Midnight && time <= LatestEnd)
            {
                return 16.0;
            }
            else
                return 0.0;
        }
        public double CalculateTotal()
        {
            double total = 0.0;
            TimeSpan hour = DateTime.Today.Add(StartTime).TimeOfDay;
            while(hour != EndTime)
            {
                total += CalculateHourlyRate(hour);
                hour = DateTime.Today.Add(hour).AddHours(1).TimeOfDay;
            }
            return total;
        }
        #endregion
        public bool ValidateStartAndEnd(TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime == endTime)
                return false;
            else if (startTime < endTime)
            {
                return (EarliestStart <= startTime && startTime <= EndOfDay)
                    && (startTime < endTime && endTime <= EndOfDay);
            }
            else
            {
                return (EarliestStart <= startTime && startTime <= EndOfDay)
                    && (Midnight <= endTime && endTime <= EndOfDay);
            }
        }
        public bool ValidateBedTime(TimeSpan bedTime)
        {
            return (StartTime < bedTime && bedTime < EndOfDay);
        }
    }
}
