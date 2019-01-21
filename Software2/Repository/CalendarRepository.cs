using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Software2.Services;

namespace Software2.Repository
{
    public class CalendarRepository
    {
        U04uzGEntities _db = new U04uzGEntities();
        public user findUser(int id)
        {
            return _db.users.Find(id);
        }

        public user findByUsername(String username)
        {
            // Finds the user where the username equals the username passed in
            return _db.users.FirstOrDefault(p => p.userName.Equals(username));
        }

        public appointment getAppointmentByID(int id)
        {
            var appointment = _db.appointments.FirstOrDefault(a => a.appointmentId == id);
            return appointment;
        }

        public void addUser(user user)
        {
            _db.users.Add(user);
            _db.SaveChanges();
        }

        public void updateAppointment(appointment updatedAppointment)
        {
            var appointmentToUpdate = getAppointmentByID(updatedAppointment.appointmentId);
            appointmentToUpdate = updatedAppointment;
            _db.SaveChanges();
        }

        public List<appointment> getAppointments()
        {
            return _db.appointments.ToList();
        }

        public void updateUser(user updateUser, int id)
        {
            var _user = this.findUser(id);
            _user = updateUser;
            _db.SaveChanges();
        }

        public List<user> getUsers()
        {
            return _db.users.ToList();
        }

        public void deleteUser(int id)
        {
            var _deleteUser = this.findUser(id);
            _db.users.Remove(_deleteUser);
            _db.SaveChanges();
        }

        public List<appointment> getAppointmentsByMonth(int month, string username)
        {
            var appointments = _db.appointments.Where(a => (a.start.Month == month || a.end.Month == month) && String.Equals(a.createdBy, username));
            return appointments.ToList();
        }

        public List<appointment> getAppointmentsByWeek(int weekNum, string username)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            var appointments = getallAppointmentsForAUser(username);
            List<appointment> appointmentsThisWeek = new List<appointment>();
            
            for (var i = 0; i < appointments.Count; i ++)
            {
                if(ciCurr.Calendar.GetWeekOfYear(appointments[i].start, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday) == weekNum)
                {
                    appointmentsThisWeek.Add(appointments[i]);
                }
            }
            return appointmentsThisWeek.ToList();
        }

        public void addAppointment(appointment appointment)
        {
            appointment.appointmentId = (_db.appointments.OrderByDescending(a => a.appointmentId).FirstOrDefault().appointmentId) + 1;
            _db.appointments.Add(appointment);
            _db.SaveChanges();
        }

        public void deleteAppointment(int appointmentID)
        {
            var appointment = getAppointmentByID(appointmentID);
            _db.appointments.Remove(appointment);
            _db.SaveChanges();
        }

        public string getUserNameByID(int dataID)
        {
            var user = _db.users.FirstOrDefault(u => u.userId == dataID);
            return user.userName;
        }

        public List<AppointmentDate> getAllAppointmentDatesForAUser(string username)
        {
            // This lambda finds all appointments that were created by the current logged in user.
            var appointments = _db.appointments.Where(a => String.Equals(a.createdBy, username))
                .Select(a => new AppointmentDate { Start = a.start, End = a.end, id = a.appointmentId }).ToList();
            return appointments;
        }

        public List<appointment> getallAppointmentsForAUser(string username)
        {
            var appointments = _db.appointments.Where(a => String.Equals(a.createdBy, username));
            return appointments.ToList();
        }

        public List<appointment> getAllAppointmentsForACustomer(int customerID)
        {
            var appointments = _db.appointments.Where(a => a.customerId == customerID);
            return appointments.ToList();
        }
    }
}
