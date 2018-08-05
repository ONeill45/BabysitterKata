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
        public void ShouldValidateStartAndEnd()
        {
            Babysitter babysitter = new Babysitter();
            Assert.True(babysitter.ValidateStartAndEnd(DateTime.Parse("5:00 PM").TimeOfDay, DateTime.Parse("10:00 PM").TimeOfDay));
            Assert.False(babysitter.ValidateStartAndEnd(DateTime.Parse("5:00 PM").TimeOfDay, DateTime.Parse("5:00 PM").TimeOfDay));
            Assert.True(babysitter.ValidateStartAndEnd(DateTime.Parse("5:00 PM").TimeOfDay, DateTime.Parse("2:00 AM").TimeOfDay));
        }
        [Fact]
        public void ShouldReturnCorrectMessage()
        {
            Babysitter babysitter = new Babysitter();

        }
    }
}
