using Software2.Repository;
using Software2.SharedMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Services
{
    public class AppointmentService
    {
        CalendarRepository _repo = new CalendarRepository();
        string username;

        public AppointmentService(string username)
        {
            this.username = username;
        }

        public appointment getAppointmentByID(int id)
        {
            return _repo.getAppointmentByID(id);
        }

        public void updateAppointment(appointment updatedAppointment)
        {
            updatedAppointment.lastUpdate = DateTimeMethods.ConvertToUniversalTime(DateTime.Now);
            updatedAppointment.lastUpdateBy = username;

            _repo.updateAppointment(updatedAppointment);
        }
    }
}
