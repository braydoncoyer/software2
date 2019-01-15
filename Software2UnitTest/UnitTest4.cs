using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software2;

namespace Software2UnitTest
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void GrabAppointmentsComingUpWithinTheNext14MinutesOrAppointmentsOccuringNow()
        {
            var appointments = new List<appointment>();
            var Feb = DateTime.Parse("2/1/2019 9:00:00 AM", System.Globalization.CultureInfo.InvariantCulture);
            var Jan = DateTime.Parse("1/1/2019 11:00:00 AM", System.Globalization.CultureInfo.InvariantCulture);
            var now = DateTime.Parse("2/1/2019 8:45:00 AM", System.Globalization.CultureInfo.InvariantCulture);
            var currentUser = "test";
            var user2 = "test2";

            appointments.Add(new appointment { title = "Test1|Lunch", start = Feb, end = Feb.AddMinutes(15), createdBy = currentUser });
            appointments.Add(new appointment { title = "Test1|Meeting", start = Jan, end = Jan.AddMinutes(15), createdBy =  user2});

            var appointmentComingUp = getAppointmentsComingUp(appointments, now, currentUser);

            Assert.AreEqual("Test1|Lunch", appointmentComingUp.title);
        }

        [TestMethod]
        public void NoUpcommingAppointmentsShouldReturnNULL()
        {
            var appointments = new List<appointment>();
            var Feb = DateTime.Parse("2/1/2019 9:00:00 AM", System.Globalization.CultureInfo.InvariantCulture);
            var Jan = DateTime.Parse("1/1/2019 11:00:00 AM", System.Globalization.CultureInfo.InvariantCulture);
            var now = DateTime.Parse("2/1/2019 8:45:00 AM", System.Globalization.CultureInfo.InvariantCulture);
            var currentUser = "test";
            var user2 = "test2";

            appointments.Add(new appointment { title = "Test1|Lunch", start = Feb, end = Feb.AddMinutes(15), createdBy = currentUser });
            appointments.Add(new appointment { title = "Test1|Meeting", start = Jan, end = Jan.AddMinutes(15), createdBy = user2 });

            var appointmentComingUp = getAppointmentsComingUp(appointments, now, user2);

            Assert.IsNull(appointmentComingUp);
        }

        [TestMethod]
        public void getAppointmentsHappeningNow()
        {
            var appointments = new List<appointment>();
            var Feb = DateTime.Parse("2/1/2019 8:40:00 AM", System.Globalization.CultureInfo.InvariantCulture);
            var Jan = DateTime.Parse("1/1/2019 11:00:00 AM", System.Globalization.CultureInfo.InvariantCulture);
            var now = DateTime.Parse("2/1/2019 8:45:00 AM", System.Globalization.CultureInfo.InvariantCulture);
            var currentUser = "test";
            var user2 = "test2";

            appointments.Add(new appointment { title = "Test1|Lunch", start = Feb, end = Feb.AddMinutes(20), createdBy = currentUser });
            appointments.Add(new appointment { title = "Test1|Meeting", start = Jan, end = Jan.AddMinutes(15), createdBy = user2 });

            var appointmentComingUp = getAppointmentsComingUp(appointments, now, currentUser);

            Assert.AreEqual("Test1|Lunch", appointmentComingUp.title);
        }

        
    }
}
