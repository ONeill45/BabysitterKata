using System;
using Xunit;
using BabysitterKata.Models;

namespace BabysitterKataTest
{
    public class BabysitterKataTest
    {
        [Fact]
        public void ShouldReturnCorrectRateByHour()
        {
            Babysitter babysitter = new Babysitter();
            Assert.Equal(12.0, babysitter.CalculateHourlyRate(new TimeSpan(20, 0, 0)));
        }
        [Fact]
        public void ShouldReturnCorrectTotal()
        {
            Babysitter babysitter = new Babysitter();
            Assert.Equal(36.0, babysitter.CalculateTotal(new TimeSpan(17, 0, 0), new TimeSpan(20, 0, 0)));
        }
        [Fact]
        public void ShouldValidateStart()
        {
            Babysitter babysitter = new Babysitter();
            Assert.True(babysitter.ValidateStart(new TimeSpan(20, 0, 0)));
            Assert.False(babysitter.ValidateStart(new TimeSpan(16, 0, 0)));
        }
    }
}
