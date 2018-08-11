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
        //method to calculate total and return message 
        public string Babysit()
        {
            Total = CalculateTotal();
            return "Sure I can babysit from "
                + DateTime.Today.Add(StartTime).ToString("hh:mm tt") + " to "
                + DateTime.Today.Add(EndTime).ToString("hh:mm tt")
                + ". That will be $" + Total;
        }
        //overload babysit method to pass in start, end and bedtime values and setting properties
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
        //calculate how much babystiter would earn each hour
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
        //calculate total amount owed
        public double CalculateTotal()
        {
            double total = 0.0;
            TimeSpan hour = TruncateMinutes(StartTime);
            TimeSpan endForCalc = MakeEndFullHour();
            while (hour != endForCalc)
            {
                total += CalculateHourlyRate(hour);
                hour = DateTime.Today.Add(hour).AddHours(1).TimeOfDay;
            }
            return total;
        }
        //pass in time and type to ensure validity
        //checks that start isn't too soon, end isn't too late, and bedtime is between them
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
        //truncate minutes off of start for calculating total
        public TimeSpan TruncateMinutes(TimeSpan time)
        {
            return DateTime.Today.AddHours(time.Hours).TimeOfDay;
        }
        //method to add to next hour for end time for calculating total
        //since 2:30 would technically be the same as 3:00, we round up
        public TimeSpan MakeEndFullHour()
        {
            if (EndTime.Minutes == 0)
                return EndTime;
            else
                return DateTime.Today.AddHours(EndTime.Hours + 1).TimeOfDay;
        }
        #endregion


    }
}
