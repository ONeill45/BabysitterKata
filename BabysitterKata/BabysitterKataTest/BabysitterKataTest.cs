using System;
using Xunit;
using BabysitterKata;

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
            Assert.Equal(8.0, BabysitterUnderTest.CalculateHourlyRate(new TimeSpan(21, 0, 0)));
            Assert.Equal(16.0, BabysitterUnderTest.CalculateHourlyRate(new TimeSpan(0, 0, 0)));
            Assert.Equal(0.0, BabysitterUnderTest.CalculateHourlyRate(new TimeSpan(16, 0, 0)));
        }
        [Fact]
        public void ShouldReturnCorrectTotal()
        {
            BabysitterUnderTest.StartTime = new TimeSpan(22, 0, 0);
            BabysitterUnderTest.EndTime = new TimeSpan(2, 0, 0);
            BabysitterUnderTest.BedTime = new TimeSpan(23, 0, 0);
            Assert.Equal(52.0, BabysitterUnderTest.CalculateTotal());
        }
        [Fact]
        public void ShouldValidateTimeByType()
        {
            BabysitterUnderTest.StartTime = DateTime.Parse("5:00 PM").TimeOfDay;
            BabysitterUnderTest.EndTime = DateTime.Parse("4:00 AM").TimeOfDay;
            BabysitterUnderTest.BedTime = DateTime.Parse("9:00 PM").TimeOfDay;
            Assert.True(BabysitterUnderTest.ValidateTimeByType(BabysitterUnderTest.StartTime, Babysitter.Times.Start));
            Assert.True(BabysitterUnderTest.ValidateTimeByType(BabysitterUnderTest.EndTime, Babysitter.Times.End));
            Assert.True(BabysitterUnderTest.ValidateTimeByType(BabysitterUnderTest.BedTime, Babysitter.Times.Bedtime));

            Assert.False(BabysitterUnderTest.ValidateTimeByType(DateTime.Parse("4:00 PM").TimeOfDay, Babysitter.Times.Start));
            Assert.False(BabysitterUnderTest.ValidateTimeByType(DateTime.Parse("5:00 AM").TimeOfDay, Babysitter.Times.End));
            BabysitterUnderTest.StartTime = DateTime.Parse("10:00 PM").TimeOfDay;
            Assert.False(BabysitterUnderTest.ValidateTimeByType(DateTime.Parse("9:00 PM").TimeOfDay, Babysitter.Times.Bedtime));
        }
        [Fact]
        public void ShouldReturnCorrectMessage()
        {
            Babysitter babysitter = new Babysitter();
            string message = babysitter.Babysit(new TimeSpan(18, 0, 0), new TimeSpan(3, 0, 0), new TimeSpan(21, 0, 0));
            Assert.Equal("Sure I can babysit from 06:00 PM to 03:00 AM. That will be $108", message);
        }
        [Fact]
        public void ShouldValidateInputIsATime()
        {
            string time = "12:00 PM";
            Assert.True(BabysitterUnderTest.IsAValidTime(time));
            string notATime = "aldjgkql;g";
            Assert.False(BabysitterUnderTest.IsAValidTime(notATime));
        }
    }
}
