using System;

namespace BabysitterKata
{
    public class Babysitter
    {
        #region properties
        public enum Times
        {
            Start,
            End,
            Bedtime
        }
        public string Name { get; set; }
        public TimeSpan EarliestStart { get; set; }
        public TimeSpan LatestEnd { get; set; }
        public static TimeSpan EndOfDay { get; set; }
        public static TimeSpan Midnight { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan BedTime { get; set; }
        public double Total { get; set; }
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
        public bool IsAValidTime(string time)
        {
            DateTime parsed = new DateTime();
            return DateTime.TryParse(time, out parsed);
        }
        public string Babysit()
        {
            Total = CalculateTotal();
            return "Sure I can babysit from "
                + DateTime.Today.Add(StartTime).ToString("hh:mm tt") + " to "
                + DateTime.Today.Add(EndTime).ToString("hh:mm tt")
                + ". That will be $" + Total;
        }
        public string Babysit(TimeSpan start, TimeSpan end, TimeSpan bedtime)
        {
            StartTime = start;
            EndTime = end;
            BedTime = bedtime;
            Total = CalculateTotal();
            return "Sure I can babysit from "
                + DateTime.Today.Add(StartTime).ToString("hh:mm tt") + " to "
                + DateTime.Today.Add(EndTime).ToString("hh:mm tt")
                + ". That will be $" + Total;
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
            else if (time >= Midnight && time < LatestEnd)
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
            while (hour != EndTime)
            {
                total += CalculateHourlyRate(hour);
                hour = DateTime.Today.Add(hour).AddHours(1).TimeOfDay;
            }
            return total;
        }
        #endregion
        public bool ValidateTimeByType(TimeSpan time, Times typeOfTime)
        {
            switch (typeOfTime)
            {
                case Times.Start:
                {
                    return (EarliestStart <= time && time <= EndOfDay);
                }
                case Times.End:
                {
                    return (StartTime < time && time <= EndOfDay)
                        || (Midnight <= time && time <= LatestEnd);
                }
                case Times.Bedtime:
                {
                    return (StartTime < time && time <= EndOfDay)
                        || (Midnight <= time && time <= EndTime);
                }
                default:
                    return false;
            }
        }
        public bool ValidateBedTime(TimeSpan bedTime)
        {
            return (StartTime < bedTime && bedTime < EndOfDay);
        }
    }
}
