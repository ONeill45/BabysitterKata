using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabysitterKata.Models
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
        public double CalculateHourlyRate(TimeSpan time)
        {

            if (time > LatestEnd && time < EarliestStart)
            {
                return 0.0;
            }
            else if (time >= EarliestStart && time <= EndOfDay)
            {
                return 12.0;
            }
            else if (time >= Midnight && time <= LatestEnd)
            {
                return 16.0;
            }
            else
                return 0.0;
        }
        public double CalculateTotal(TimeSpan start, TimeSpan end)
        {
            double total = 0.0;
            TimeSpan hour = start;
            while(hour >= start && hour < end)
            {
                total += CalculateHourlyRate(hour);
                hour = hour.Add(new TimeSpan(1, 0, 0));
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
        
    }
}
