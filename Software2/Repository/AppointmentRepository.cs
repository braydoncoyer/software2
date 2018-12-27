using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repository
{
    public class AppointmentRepository
    {
        U04uzGEntities _db = new U04uzGEntities();

        public void addAppointment(appointment appointment)
        {
            _db.appointments.Add(appointment);
            _db.SaveChanges();
        }
    }
}
