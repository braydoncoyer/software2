using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Software2UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReturnTrueIfDateFallsBetweenTwoDates()
        {
            string dateString1 = "1/1/2019 2:00:00 AM";
            DateTime date1 = DateTime.Parse(dateString1, System.Globalization.CultureInfo.InvariantCulture);

            string dateString2 = "1/5/2019 9:00:00 PM";
            DateTime date2 = DateTime.Parse(dateString2, System.Globalization.CultureInfo.InvariantCulture);

            string testDateString = "1/3/2019 2:00:00 AM";
            DateTime testDate = DateTime.Parse(testDateString, System.Globalization.CultureInfo.InvariantCulture);

            var isBetween = isDateBetween(date1, date2, testDate);

            Assert.IsTrue(isBetween);
        }

        [TestMethod]
        public void ReturnFalseIfDateFallsOutsideOfTwoDates()
        {
            string dateString1 = "1/1/2019 2:00:00 AM";
            DateTime date1 = DateTime.Parse(dateString1, System.Globalization.CultureInfo.InvariantCulture);

            string dateString2 = "1/5/2019 9:00:00 PM";
            DateTime date2 = DateTime.Parse(dateString2, System.Globalization.CultureInfo.InvariantCulture);

            string testDateString = "1/5/2019 9:01:00 PM";
            DateTime testDate = DateTime.Parse(testDateString, System.Globalization.CultureInfo.InvariantCulture);

            var isBetween = isDateBetween(date1, date2, testDate);

            Assert.IsFalse(isBetween);
        }

        [TestMethod]
        public void ReturnFalseIfDateSameAsBeginningOrEndDate()
        {
            string dateString1 = "1/1/2019 2:00:00 AM";
            DateTime date1 = DateTime.Parse(dateString1, System.Globalization.CultureInfo.InvariantCulture);

            string dateString2 = "1/5/2019 9:00:00 PM";
            DateTime date2 = DateTime.Parse(dateString2, System.Globalization.CultureInfo.InvariantCulture);

            string testDateString = "1/1/2019 2:00:00 AM";
            DateTime testDate = DateTime.Parse(testDateString, System.Globalization.CultureInfo.InvariantCulture);

            var isBetween = isDateBetween(date1, date2, testDate);

            Assert.IsFalse(isBetween);
        }


        private bool isDateBetween(DateTime date1, DateTime date2, DateTime testDate)
        {
            return testDate.Ticks > date1.Ticks && testDate.Ticks < date2.Ticks;
        }
    }
}
