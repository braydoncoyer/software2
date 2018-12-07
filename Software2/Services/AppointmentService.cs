using Software2.Repository;
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

        public appointment getAppointmentByID(int id)
        {
            return _repo.getAppointmentByID(id);
        }
    }
}
