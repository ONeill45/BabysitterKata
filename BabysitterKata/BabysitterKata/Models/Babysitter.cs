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

        #endregion
        #region constructors
        public Babysitter(string name = "Bee")
        {
            Name = name;
        }
        #endregion
        #region methods
        public double CalculateHourlyRate(TimeSpan time)
        {
            TimeSpan latest = new TimeSpan(4, 0, 0);
            TimeSpan earliest = new TimeSpan(17, 0, 0);
            TimeSpan endOfDay = new TimeSpan(23,59, 0);
            TimeSpan midnight = new TimeSpan(0, 0, 0);
            if (time > latest && time < earliest)
            {
                return 0.0;
            }
            else if (time >= earliest && time <= endOfDay)
            {
                return 12.0;
            }
            else if (time >= midnight && time <= latest)
            {
                return 16.0;
            }
            else
                return 0.0;
        }
        #endregion
    }
}
