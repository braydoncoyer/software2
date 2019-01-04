using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Software2UnitTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void ShouldConvertToLocalTime()
        {
            string dateString1 = "1/1/2019 8:00:00 AM";
            DateTime expectedDate = DateTime.Parse("1/1/2019 2:00:00 AM", System.Globalization.CultureInfo.InvariantCulture);
            DateTime utcDate = DateTime.Parse(dateString1, System.Globalization.CultureInfo.InvariantCulture);

            DateTime localDate = utcDate.ToLocalTime();
            
            Assert.AreEqual(expectedDate, localDate);
        }

        [TestMethod]
        public void ShouldSetToPreviousDay()
        {
            string dateString1 = "1/1/2019 1:00:00 AM";
            DateTime expectedDate = DateTime.Parse("12/31/2018 7:00:00 PM", System.Globalization.CultureInfo.InvariantCulture);
            DateTime utcDate = DateTime.Parse(dateString1, System.Globalization.CultureInfo.InvariantCulture);

            DateTime localDate = utcDate.ToLocalTime();

            Assert.AreEqual(expectedDate, localDate);
        }
    }
}
