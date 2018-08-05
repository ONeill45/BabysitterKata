using System;
using Xunit;
using BabysitterKata.Models;

namespace BabysitterKataTest
{
    public class BabysitterKataTest
    {
        private Babysitter BabysitterUnderTest { get; set; }
        public BabysitterKataTest()
        {
            BabysitterUnderTest = new Babysitter();
        }
        [Fact]
        public void ShouldReturnCorrectRateByHour()
        {
            //bedtime must be defined to calculate hourly rate properly
            BabysitterUnderTest.BedTime = new TimeSpan(21, 0, 0);
            Assert.Equal(12.0, BabysitterUnderTest.CalculateHourlyRate(new TimeSpan(20, 0, 0)));
        }
        [Fact]
        public void ShouldReturnCorrectTotal()
        {
            BabysitterUnderTest.StartTime = new TimeSpan(17, 0, 0);
            BabysitterUnderTest.EndTime = new TimeSpan(20, 0, 0);
            BabysitterUnderTest.BedTime = new TimeSpan(19, 0, 0);
            Assert.Equal(32.0, BabysitterUnderTest.CalculateTotal());
        }
        [Fact]
        public void ShouldValidateStartAndEnd()
        {
            Assert.True(BabysitterUnderTest.ValidateStartAndEnd(DateTime.Parse("5:00 PM").TimeOfDay, DateTime.Parse("10:00 PM").TimeOfDay));
            Assert.False(BabysitterUnderTest.ValidateStartAndEnd(DateTime.Parse("5:00 PM").TimeOfDay, DateTime.Parse("5:00 PM").TimeOfDay));
            Assert.True(BabysitterUnderTest.ValidateStartAndEnd(DateTime.Parse("5:00 PM").TimeOfDay, DateTime.Parse("2:00 AM").TimeOfDay));
        }
        [Fact]
        public void ShouldReturnCorrectMessage()
        {
            Babysitter babysitter = new Babysitter();

        }
        [Fact]
        public void ShouldValidateBedTime()
        {
            BabysitterUnderTest.StartTime = new TimeSpan(17, 0, 0);
            Assert.True(BabysitterUnderTest.ValidateBedTime(new TimeSpan(21, 0, 0)));
        }
    }
}
