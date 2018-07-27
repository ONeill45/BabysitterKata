using System;
using Xunit;
using BabysitterKata.Models;

namespace BabysitterKataTest
{
    public class BabysitterKataTest
    {
        [Fact]
        public void ItShouldReturnCorrectRateByHour()
        {
            Babysitter babysitter = new Babysitter();
            Assert.Equal(12.0, babysitter.CalculateHourlyRate(new TimeSpan(20, 0, 0)));
        }
    }
}
